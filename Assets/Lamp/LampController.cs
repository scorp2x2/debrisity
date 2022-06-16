using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampController : MonoBehaviour
{
    private float time;
    private bool isSpawn;

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
        ManagerResources.Instantiate.diamonds.Add(1);
        Debug.Log("AddLamp");
        SavedController.Instantiate.SaveGame();
        gameObject.SetActive(false);
        isSpawn = false;
    }
}