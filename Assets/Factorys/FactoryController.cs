using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class FactoryController : MonoBehaviour
{
    public Factory factory;
    public Text textLevelCapacity;
    public Text textLevelEfficiency;

    Localization _localization;

    [Inject]
    public void Construct(Localization localization)
    {
        _localization = localization;
    }

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

    public void Work(ManagerResources managerResources)
    {
        factory.Work(managerResources, _localization);
    }
}