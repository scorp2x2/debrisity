using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class HumanController : MonoBehaviour, IPoolable<SityController, ManagerResources, IMemoryPool>
{
    public Vector4 margin;
    public Vector2 sizeSity;
    public float speed;
    float _speed;
    public Vector3 pointMove;
    public RectTransform rect;

    public int spawnLampDay;

    public LampController lamp;

    [Inject]
    public SityController _sityController;
    [Inject]
    public ManagerResources _managerResources;

    public void OnDespawned()
    {

    }

    public void OnSpawned(SityController p1, ManagerResources p2, IMemoryPool p3)
    {
        _sityController = p1;
        _managerResources = p2;
    }

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();

        var s = GameObject.FindWithTag("Sity");
        if (s == null) return;
        var sity = s.GetComponent<RectTransform>();
        sizeSity = new Vector2(sity.rect.width, sity.rect.height);

        GenerateLamp();

        rect.localPosition = RandomzePoint();

        pointMove = RandomzePoint();
    }


    void GenerateLamp()
    {
        var r = Random.Range(.000f, 1.000f);
        var p = 2f / (float)_sityController.peoples.Count;
        if (r <= p)
        {
            spawnLampDay = _managerResources.days.Count + Random.Range(1, GameConstant.CountDaysFromDiamond);
        }
        else
            spawnLampDay = -1;
    }


    float distantion = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        rect.localPosition = Vector3.MoveTowards(rect.localPosition, pointMove, distantion * Time.deltaTime * _speed);

        if (Vector3.Distance(rect.localPosition, pointMove) < 1)
            pointMove = RandomzePoint();
    }

    Vector3 RandomzePoint()
    {
        var x = Random.Range(-sizeSity.x / 2 + margin.x, sizeSity.x / 2 - margin.z);
        var y = Random.Range(-sizeSity.y / 2 + margin.y, sizeSity.y / 2 - margin.w);
        var pointMove = new Vector3(x, y, 0);

        _speed = speed * Random.Range(.8f, 1.2f);
        distantion = Vector3.Distance(rect.localPosition, pointMove);

        if (lamp != null)
            if (spawnLampDay == _managerResources.days.Count)
            {
                lamp.Spawn();
                GenerateLamp();
            }

        return pointMove;
    }

    public void Die()
    {
        Destroy(gameObject);
    }

    public class Factory : PlaceholderFactory<SityController, ManagerResources, HumanController>
    {

    }
}