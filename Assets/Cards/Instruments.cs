﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Instruments 
{
    public static void ClearChilds(Transform transform)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject.Destroy(transform.GetChild(i).gameObject);
        }
    }
}
