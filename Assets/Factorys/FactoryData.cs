using System;
using System.Collections.Generic;

[Serializable]
public class FactoryData
{
    public int LevelCapacity;
    public int LevelEfficiency;
    public List<Boost> Boosts;

    internal void Load(FactoryData factoryData)
    {
        LevelCapacity = factoryData.LevelCapacity;
        LevelEfficiency = factoryData.LevelEfficiency;
        Boosts = factoryData.Boosts;
    }
}