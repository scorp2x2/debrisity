using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerFactorys : MonoBehaviour
{
    public static ManagerFactorys Instantiate;

    private void Awake()
    {
        Instantiate = this;
    }

    public Factory food;
    public Factory water;
    public Factory people;
    public Factory gold;
    public Factory debris;
}
