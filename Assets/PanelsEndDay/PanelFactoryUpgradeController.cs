using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void Load()
    {
        levelEfficiency.text = factory.FactoryData.LevelEfficiency.ToString();
        levelCapacity.text = factory.FactoryData.LevelCapacity.ToString();

        textEfficiency.text =
            $"+{factory.GetProduction(factory.FactoryData.LevelEfficiency)}(+{factory.GetProduction(factory.FactoryData.LevelEfficiency + 1)})";
        textCapacity.text =
            $"+{factory.GetMaxStorage()}(+{factory.GetMaxStorage(factory.FactoryData.LevelCapacity + 1)})";

        var countGold = factory.GetGoldPriceUpgradeEfficiency();
        var countDebris = factory.GetDebrisPriceUpgradeEfficiency();
        priceGoldEfficiency.text = factory.GetGoldPriceUpgradeEfficiency().ToString();
        priceGoldCapacity.text = factory.GetGoldPriceUpgradeCapacity().ToString();
        panelEfficiency.SetActive(ManagerResources.Instantiate.gold.Count < countGold ||
                                  ManagerResources.Instantiate.debris.Count < countDebris);

        countGold = factory.GetGoldPriceUpgradeCapacity();
        countDebris = factory.GetDebrisPriceUpgradeCapacity();
        priceDebrisEfficiency.text = factory.GetDebrisPriceUpgradeEfficiency().ToString();
        priceDebrisCapacity.text = factory.GetDebrisPriceUpgradeCapacity().ToString();
        panelCapacity.SetActive(ManagerResources.Instantiate.gold.Count < countGold ||
                                ManagerResources.Instantiate.debris.Count < countDebris);
    }

    public void ButtonUpgradeEfficiency()
    {
        var countGold = factory.GetGoldPriceUpgradeEfficiency();
        var countDebris = factory.GetDebrisPriceUpgradeEfficiency();

        if (ManagerResources.Instantiate.gold.Count < countGold ||
            ManagerResources.Instantiate.debris.Count < countDebris) return;

        ManagerResources.Instantiate.gold.Eat(countGold);
        ManagerResources.Instantiate.WriteStatistic(
            ManagerResources.Instantiate.gold, "Траты на улучшение", countGold,false);
        ManagerResources.Instantiate.debris.Eat(countDebris);
        ManagerResources.Instantiate.WriteStatistic(
            ManagerResources.Instantiate.debris, "Траты на улучшение", countDebris, false);

        factory.UpLevelEfficiency();
        PanelFactorysController.Instantiate.End();
    }

    public void ButtonUpgradeCapacity()
    {
        var countGold = factory.GetGoldPriceUpgradeCapacity();
        var countDebris = factory.GetDebrisPriceUpgradeCapacity();

        if (ManagerResources.Instantiate.gold.Count < countGold ||
            ManagerResources.Instantiate.debris.Count < countDebris) return;

        ManagerResources.Instantiate.gold.Eat(countGold);
        ManagerResources.Instantiate.WriteStatistic(
            ManagerResources.Instantiate.gold, "Траты на улучшение", countGold, false);
        ManagerResources.Instantiate.debris.Eat(countDebris);
        ManagerResources.Instantiate.WriteStatistic(
            ManagerResources.Instantiate.debris, "Траты на улучшение", countDebris, false);

        factory.UpLevelCapacity();
        PanelFactorysController.Instantiate.End();
    }
}