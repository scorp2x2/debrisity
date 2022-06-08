using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanController : MonoBehaviour
{
    public Vector4 margin;
    public Vector2 sizeSity;
    public float speed;
    float _speed;
    public Vector3 pointMove;
    public RectTransform rect;

    // Start is called before the first frame update
    void Start()
    {
        rect = GetComponent<RectTransform>();
        var sity = GameObject.FindWithTag("Sity").GetComponent<RectTransform>();
        sizeSity = new Vector2(sity.rect.width, sity.rect.height);

        rect.localPosition = RandomzePoint();

        pointMove = RandomzePoint();
    }

    float time = 0;

    // Update is called once per frame
    void FixedUpdate()
    {
        rect.localPosition = Vector3.Lerp(rect.localPosition, pointMove, time / _speed);

        if (Vector3.Distance(rect.localPosition, pointMove) < 1)
            pointMove = RandomzePoint();

        time += Time.deltaTime;
    }

    Vector3 RandomzePoint()
    {
        var x = Random.Range(-sizeSity.x / 2 + margin.x, sizeSity.x / 2 - margin.z);
        var y = Random.Range(-sizeSity.y / 2 + margin.y, sizeSity.y / 2 - margin.w);
        var pointMove = new Vector3(x, y, 0);

        _speed = speed * Random.Range(.8f, 1.2f);
        time = 0;

        return pointMove;
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}