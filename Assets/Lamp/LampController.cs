using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class LampController : MonoBehaviour
{
    private float time;
    private bool isSpawn;

    SavedController _savedController;
    ManagerResources _managerResources;

    [Inject]
    public void Construct(SavedController savedController, ManagerResources managerResources)
    {
        _savedController = savedController;
        _managerResources = managerResources;
    }

    public void Spawn()
    {
        gameObject.SetActive(true);
        Debug.Log("Spawn Lamp");

        time = Time.time + Random.Range(0, 30);
        isSpawn = true;
    }

    private void Update()
    {
        if (isSpawn && Time.time > time)
            Destroy(gameObject);
    }

    private void OnMouseDown()
    {
        _managerResources.diamonds.Add(1);
        Debug.Log("AddLamp");
        _savedController.PlayerSave();
        gameObject.SetActive(false);
        isSpawn = false;
    }
}