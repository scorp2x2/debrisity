using System;
using UnityEngine;

[Serializable]
public class ProductionData
{
    [SerializeField] public int count;

    internal void Load(ProductionData productionData)
    {
        count = productionData.count;
    }
}