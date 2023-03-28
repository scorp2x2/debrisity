using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Factory", fileName = "Factory")]
public class Factory : ScriptableObject
{
    public Sprite Icon;
    public string messageStatistic;

    public Production production;

    public Vector2 Efficiency;
    public float multiplayEfficiency;
    public float multiplayCapacity;
    public float multiplayLVLEfficiency;
    public float multiplayLVLCapacity;
    public int Capacity;
    public int GoldPriceUpgradeEfficiency;
    public int GoldPriceUpgradeCapacity;
    public int DebrisPriceUpgradeEfficiency;
    public int DebrisPriceUpgradeCapacity;

    public FactoryData FactoryData;

    public string FieldName { get => $"{name}"; }

    public void UpLevelCapacity() => FactoryData.LevelCapacity++;
    public void UpLevelEfficiency() => FactoryData.LevelEfficiency++;

    public void SetLevelEfficiency(int level) => FactoryData.LevelEfficiency = level;
    public void SetLevelCapacity(int level) => FactoryData.LevelCapacity = level;

    public void SetDefault()
    {
        SetLevelCapacity(1);
        SetLevelEfficiency(1);
    }

    public void AddBoost(Boost boost)
    {
        if (FactoryData.Boosts == null) FactoryData.Boosts = new List<Boost>();

        FactoryData.Boosts.Add(boost);
    }

    public int GetGoldPriceUpgradeCapacity()
    {
        var p = Instruments.CalcMultiplay(FactoryData.LevelCapacity, multiplayLVLCapacity,
            GoldPriceUpgradeCapacity); // GoldPriceUpgradeCapacity;
        return Mathf.RoundToInt(p);
    }

    public int GetGoldPriceUpgradeEfficiency()
    {
        var p = Instruments.CalcMultiplay(FactoryData.LevelEfficiency, multiplayLVLEfficiency,
            GoldPriceUpgradeEfficiency); // GoldPriceUpgradeCapacity;
        return Mathf.RoundToInt(p);
    }

    public int GetDebrisPriceUpgradeCapacity()
    {
        var p = Instruments.CalcMultiplay(FactoryData.LevelCapacity, multiplayLVLCapacity * 1.1f,
            DebrisPriceUpgradeCapacity); // GoldPriceUpgradeCapacity;
        return Mathf.RoundToInt(p);
    }

    public int GetDebrisPriceUpgradeEfficiency()
    {
        var p = Instruments.CalcMultiplay(FactoryData.LevelEfficiency, multiplayLVLEfficiency * 1.1f,
            DebrisPriceUpgradeEfficiency); // GoldPriceUpgradeCapacity;
        return Mathf.RoundToInt(p);
    }

    public int GetMaxStorage()
    {
        return GetMaxStorage(FactoryData.LevelCapacity);
    }

    public int GetMaxStorage(int level)
    {
        if (Capacity == Int32.MaxValue) return Capacity;

        var p = Instruments.CalcMultiplay(level, multiplayCapacity,
            Capacity);
        return Mathf.RoundToInt(p);
    }

    public int GetProduction()
    {
        return GetProduction(FactoryData.LevelEfficiency);
    }

    public int GetProduction(int level)
    {
        int p = Mathf.RoundToInt(Instruments.CalcMultiplay(level, multiplayEfficiency,
            Random.Range(Efficiency.x, Efficiency.y)));

        float increase = GetIncrease();

        if (increase != 0)
            p = Mathf.RoundToInt(p * increase);

        return p;
    }

    public float GetIncrease()
    {
        float increase = 0;
        for (int i = 0; i < FactoryData.Boosts.Count; i++)
        {
            increase += FactoryData.Boosts[i].Increase;
            if (!FactoryData.Boosts[i].CheckBoost())
            {
                FactoryData.Boosts.RemoveAt(i);
                i--;
            }
        }

        return increase;
    }

    public void Work(ManagerResources managerResources, Localization localization)
    {
        int count = GetProduction();
        production.Add(count);
        managerResources.WriteStatistic(production, localization.GetText(FieldName), count);
    }
}