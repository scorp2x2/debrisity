using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PanelFactoryUpgradeController : MonoBehaviour
{
    public Factory factory;
    public Text levelEfficiency;
    public Text levelCapacity;

    public Text textEfficiency;
    public Text textCapacity;

    public GameObject panelEfficiency;
    public GameObject panelCapacity;

    public Text priceGoldEfficiency;
    public Text priceDebrisEfficiency;
    public Text priceGoldCapacity;
    public Text priceDebrisCapacity;

    ManagerResources _managerResources;
    PanelFactorysController _panelFactoriesController;

    [Inject]
    public void Construct(ManagerResources managerResources, PanelFactorysController panelFactorysController)
    {
        _managerResources = managerResources;
        _panelFactoriesController = panelFactorysController;
    }

    public void Load()
    {
        levelEfficiency.text = factory.FactoryData.LevelEfficiency.ToString();
        levelCapacity.text = factory.FactoryData.LevelCapacity.ToString();

        textEfficiency.text = String.Format("+{0} ({1})",
            factory.GetProduction(factory.FactoryData.LevelEfficiency + 1) - factory.GetProduction(),
            factory.GetProduction(factory.FactoryData.LevelEfficiency + 1));
        textCapacity.text = String.Format("+{0} ({1})",
            factory.GetMaxStorage(factory.FactoryData.LevelCapacity + 1) - factory.GetMaxStorage(),
            factory.GetMaxStorage(factory.FactoryData.LevelCapacity + 1));

        var countGold = factory.GetGoldPriceUpgradeEfficiency();
        var countDebris = factory.GetDebrisPriceUpgradeEfficiency();
        priceGoldEfficiency.text = factory.GetGoldPriceUpgradeEfficiency().ToString();
        priceGoldCapacity.text = factory.GetGoldPriceUpgradeCapacity().ToString();
        panelEfficiency.SetActive(_managerResources.gold.Count < countGold ||
                                  _managerResources.debris.Count < countDebris);

        countGold = factory.GetGoldPriceUpgradeCapacity();
        countDebris = factory.GetDebrisPriceUpgradeCapacity();
        priceDebrisEfficiency.text = factory.GetDebrisPriceUpgradeEfficiency().ToString();
        priceDebrisCapacity.text = factory.GetDebrisPriceUpgradeCapacity().ToString();
        panelCapacity.SetActive(_managerResources.gold.Count < countGold ||
                                _managerResources.debris.Count < countDebris);
    }

    public void ButtonUpgradeEfficiency()
    {
        var countGold = factory.GetGoldPriceUpgradeEfficiency();
        var countDebris = factory.GetDebrisPriceUpgradeEfficiency();

        if (_managerResources.gold.Count < countGold ||
            _managerResources.debris.Count < countDebris) return;

        _managerResources.gold.Eat(countGold);
        _managerResources.WriteStatistic(
            _managerResources.gold, "Траты на улучшение", countGold,false);
        _managerResources.debris.Eat(countDebris);
        _managerResources.WriteStatistic(
            _managerResources.debris, "Траты на улучшение", countDebris, false);

        factory.UpLevelEfficiency();
        _panelFactoriesController.End();
    }

    public void ButtonUpgradeCapacity()
    {
        var countGold = factory.GetGoldPriceUpgradeCapacity();
        var countDebris = factory.GetDebrisPriceUpgradeCapacity();

        if (_managerResources.gold.Count < countGold ||
            _managerResources.debris.Count < countDebris) return;

        _managerResources.gold.Eat(countGold);
        _managerResources.WriteStatistic(
            _managerResources.gold, "Траты на улучшение", countGold, false);
        _managerResources.debris.Eat(countDebris);
        _managerResources.WriteStatistic(
            _managerResources.debris, "Траты на улучшение", countDebris, false);

        factory.UpLevelCapacity();
        _panelFactoriesController.End();
    }
}