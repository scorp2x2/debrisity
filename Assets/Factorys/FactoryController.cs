using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryController : MonoBehaviour
{
    public Factory factory;

    public Text textLevelCapacity;

    public Text textLevelEfficiency;

    public void LoadInfo()
    {
        textLevelCapacity.text = $"Lvl: {factory.FactoryData.LevelEfficiency}\n+{factory.GetProduction()}";
        textLevelEfficiency.text = $"Lvl: {factory.FactoryData.LevelCapacity}\nmax:{factory.GetMaxStorage()}";
    }

    public void UpLevelCapacity()
    {
        factory.UpLevelCapacity();
        LoadInfo();
    }

    public void SetLevelCapacity(int level)
    {
        factory.SetLevelCapacity(level);
        LoadInfo();
    }
    
    public void UpLevelEfficiency()
    {
        factory.UpLevelEfficiency();
        LoadInfo();
    }
    
    public void SetLevelEfficiency(int level)
    {
        factory.SetLevelEfficiency(level);
        LoadInfo();
    }
    
    public void Work()
    {
        factory.Work();
    }
}