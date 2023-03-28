using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

[CreateAssetMenu(menuName = "Production", fileName = "Production")]
public class Production : ScriptableObject
{
    public Sprite Icon;
    public string name;
    public ProductionData ProductionData;

    public int Count
    {
        get => ProductionData.count;
        private set => ProductionData.count = value;
    }

    public Factory Factory;

    public bool limitMax;
    public bool limitMin;

    public int MaxCount
    {
        get => Factory.GetMaxStorage();
    }
    public string FieldName { get => base.name; }

    public int DefaultCount;

    public Vector2 DeadPeopleInRaid;
    public Vector2 FindResInRaid;

    public bool Add(int count)
    {
        Count += count;
        if (limitMax && Count > MaxCount)
            Count = MaxCount;
        return true;
    }

    public bool Eat(int count)
    {
        if (limitMin && Count - count < 0)
            return false;

        Count -= count;
        return true;
    }

    public void GenerateRandomValue(int range = 10)
    {
        Add(Random.Range(-range, range));
    }

    public void SetDefault()
    {
        if (DefaultCount == -1) return;
        Count = DefaultCount;
    }
}