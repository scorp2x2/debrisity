using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class GameSaveData
{
    public List<FactoryData> FactoryDatas;
    public List<ProductionData> ProductionDatas;

    public bool IsNewGame;

    public static GameSaveData GetDefault()
    {
        var productions = Resources.LoadAll<Production>("Productions").ToList();
        var factories = Resources.LoadAll<Factory>("Factories").ToList();
        productions.ForEach(a => a.SetDefault());
        factories.ForEach(a => a.SetDefault());

        GameSaveData playerSaveData = new()
        {
            ProductionDatas = productions.Select(a => a.ProductionData).ToList(),
            FactoryDatas = factories.Select(a => a.FactoryData).ToList(),
            IsNewGame = true
        };

        return playerSaveData;
    }

    public void Synchronization()
    {
        var productions = Resources.LoadAll<Production>("Productions").ToList();
        var factories = Resources.LoadAll<Factory>("Factories").ToList();

        for (int i = 0; i < factories.Count; i++)
        {
            factories[i].FactoryData.Load(FactoryDatas[i]);
            FactoryDatas[i] = factories[i].FactoryData;
        }    
        for (int i = 0; i < productions.Count; i++)
        {
            productions[i].ProductionData.Load(ProductionDatas[i]);
            ProductionDatas[i] = productions[i].ProductionData;
        }

        IsNewGame = productions.First(a => a.name == "Äíè").Count == 0;

    }
}