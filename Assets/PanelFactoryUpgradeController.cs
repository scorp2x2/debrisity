using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelFactoryUpgradeController : MonoBehaviour
{
    public FactoryType FactoryType;
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
    
    Factory factory;

    public void Load()
    {
        switch (FactoryType)
        {
            case FactoryType.Food:
                Load(Factorys.FactoryFood);
                break;
            case FactoryType.Water:
                Load(Factorys.FactoryWater);
                break;
            case FactoryType.Debris:
                Load(Factorys.FactoryStorage);
                break;
            case FactoryType.People:
                Load(Factorys.FactoryBaracs);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void Load(Factory factory)
    {
    	this.factory=factory;
        levelEfficiency.text = factory.LevelEfficiency.ToString();
        levelCapacity.text = factory.LevelCapacity.ToString();

        textEfficiency.text = $"+{factory.GetProduction(factory.LevelEfficiency)}(+{factory.GetProduction(factory.LevelEfficiency+1)})";
        textCapacity.text = $"+{factory.GetMaxStorage()}(+{factory.GetMaxStorage(factory.LevelCapacity+1)})";
        
        var countGold = factory.GetGoldPriceUpgradeEfficiency();
        var countDebris = factory.GetDebrisPriceUpgradeEfficiency();
        priceGoldEfficiency.text = factory.GetGoldPriceUpgradeEfficiency().ToString();
        priceGoldCapacity.text = factory.GetGoldPriceUpgradeCapacity().ToString();
        panelEfficiency.SetActive(Resources.Gold< countGold || Resources.Debris<countDebris);
        
        countGold = factory.GetGoldPriceUpgradeCapacity();
        countDebris = factory.GetDebrisPriceUpgradeCapacity();
        priceDebrisEfficiency.text = factory.GetDebrisPriceUpgradeEfficiency().ToString();
        priceDebrisCapacity.text = factory.GetDebrisPriceUpgradeCapacity().ToString();
        panelCapacity.SetActive(Resources.Gold< countGold || Resources.Debris<countDebris);
    }
    
    public void ButtonUpgradeEfficiency()
    {
    	var countGold = factory.GetGoldPriceUpgradeEfficiency();
        var countDebris = factory.GetDebrisPriceUpgradeEfficiency();
        
        if(Resources.Gold< countGold || Resources.Debris<countDebris) return;
        
        Resources.EatResource(ProductionType.Gold, countGold);
        Resources.EatResource(ProductionType.Debris, countDebris);
    	
        switch (FactoryType)
        {
            case FactoryType.Food:
                Factorys.FactoryFood.UpLevelEfficiency();
                break;
            case FactoryType.Water:
                Factorys.FactoryWater.UpLevelEfficiency();
                break;
            case FactoryType.Debris:
                Factorys.FactoryStorage.UpLevelEfficiency();
                break;
            case FactoryType.People:
                Factorys.FactoryBaracs.UpLevelEfficiency();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        PanelFactorysController.Instantiate.End();
    }

    public void ButtonUpgradeCapacity()
    {
    	var countGold = factory.GetGoldPriceUpgradeCapacity();
        var countDebris = factory.GetDebrisPriceUpgradeCapacity();
        
        if(Resources.Gold< countGold || Resources.Debris<countDebris) return;
        
        Resources.EatResource(ProductionType.Gold, countGold);
        Resources.EatResource(ProductionType.Debris, countDebris);
    	
        switch (FactoryType)
        {
            case FactoryType.Food:
                Factorys.FactoryFood.UpLevelCapacity();
                break;
            case FactoryType.Water:
                Factorys.FactoryWater.UpLevelCapacity();
                break;
            case FactoryType.Debris:
                Factorys.FactoryStorage.UpLevelCapacity();
                break;
            case FactoryType.People:
                Factorys.FactoryBaracs.UpLevelCapacity();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        PanelFactorysController.Instantiate.End();
    }
}
