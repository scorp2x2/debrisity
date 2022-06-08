using System;
using System.Collections.Generic;
using UnityEngine;

public class Factory
{
    public FactoryType FactoryType { get; private set; }

    public int LevelCapacity { get; private set; }
    public int LevelEfficiency { get; private set; }

    public List<Boost> Boosts;

    public Factory(FactoryType factoryType)
    {
        FactoryType = factoryType;
        LevelCapacity = 1;
        LevelEfficiency = 1;
        Boosts = new List<Boost>();
    }

    public void UpLevelCapacity() => LevelCapacity++;
    public void UpLevelEfficiency() => LevelEfficiency++;

    public void SetLevelEfficiency(int level) => LevelEfficiency = level;
    public void SetLevelCapacity(int level) => LevelCapacity = level;

    public void AddBoost(Boost boost)
    {
        if (Boosts == null) Boosts = new List<Boost>();

        Boosts.Add(boost);
    }

    public int GetGoldPriceUpgradeCapacity()
    {
    	int p=0;
    	 switch (FactoryType)
        {
            case FactoryType.Food:
                p = GameConstant.GoldPriceFactoryFoodCapacity;
                break;
            case FactoryType.Water:
                p = GameConstant.GoldPriceFactoryWaterCapacity;
                break;
            case FactoryType.Debris:
                p = GameConstant.GoldPriceFactoryStorageCapacity;
                break;
            case FactoryType.People:
                p = GameConstant.GoldPriceFactoryBaracsCapacity;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    	
    	 return Mathf.RoundToInt((1+(LevelCapacity-1)*0.2f)*p);
    }
    
    public int GetGoldPriceUpgradeEfficiency()
    {
        int p=0;
    	 switch (FactoryType)
        {
            case FactoryType.Food:
                p = GameConstant.GoldPriceFactoryFoodEfficiency;
                break;
            case FactoryType.Water:
                p = GameConstant.GoldPriceFactoryWaterEfficiency;
                break;
            case FactoryType.Debris:
                //p = GameConstant.PriceFactoryStorageEfficiency;
                break;
            case FactoryType.People:
               // p = GameConstant.PriceFactoryBaracsEfficiency;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    	
    	 return Mathf.RoundToInt((1+(LevelEfficiency-1)*0.2f)*p);
    }
    
    public int GetDebrisPriceUpgradeCapacity()
    {
    	int p=0;
    	 switch (FactoryType)
        {
            case FactoryType.Food:
                p = GameConstant.DebrisPriceFactoryFoodCapacity;
                break;
            case FactoryType.Water:
                p = GameConstant.DebrisPriceFactoryWaterCapacity;
                break;
            case FactoryType.Debris:
                p = GameConstant.DebrisPriceFactoryStorageCapacity;
                break;
            case FactoryType.People:
                p = GameConstant.DebrisPriceFactoryBaracsCapacity;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    	
    	 return Mathf.RoundToInt((1+(LevelCapacity-1)*0.2f)*p);
    }
    
    public int GetDebrisPriceUpgradeEfficiency()
    {
        int p=0;
    	 switch (FactoryType)
        {
            case FactoryType.Food:
                p = GameConstant.DebrisPriceFactoryFoodEfficiency;
                break;
            case FactoryType.Water:
                p = GameConstant.DebrisPriceFactoryWaterEfficiency;
                break;
            case FactoryType.Debris:
                //p = GameConstant.PriceFactoryStorageEfficiency;
                break;
            case FactoryType.People:
               // p = GameConstant.PriceFactoryBaracsEfficiency;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    	
    	 return Mathf.RoundToInt((1+(LevelEfficiency-1)*0.2f)*p);
    }
    
    public int GetMaxStorage()
    {
        return GetMaxStorage(LevelCapacity);
    }
    
    public int GetMaxStorage(int level)
    {
        int p = 0;
        switch (FactoryType)
        {
            case FactoryType.Food:
                p = level * GameConstant.FactoryFoodCapacity;
                break;
            case FactoryType.Water:
                p = level * GameConstant.FactoryWaterCapacity;
                break;
            case FactoryType.Debris:
                p = level * GameConstant.FactoryStorageCapacity;
                break;
            case FactoryType.People:
                p = level * GameConstant.FactoryBaracsCapacity;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return p;
    }

    public int GetProduction()
    {
        int p = 0;
        switch (FactoryType)
        {
            case FactoryType.Food:
                p = LevelEfficiency * GameConstant.FactoryFoodEfficiency;
                break;
            case FactoryType.Water:
                p = LevelEfficiency * GameConstant.FactoryWaterEfficiency;
                break;
            case FactoryType.Debris:
                break;
            case FactoryType.People:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        float increase = 0;
        for (int i = 0; i < Boosts.Count; i++)
        {
            increase += Boosts[i].Increase;
            if (!Boosts[i].CheckBoost())
            {
                Boosts.RemoveAt(i);
                i--;
            }
        }

        if (increase != 0)
            p = Mathf.RoundToInt(p * increase);

        return p;
    }

    public int GetProduction(int level)
    {
        switch (FactoryType)
        {
            case FactoryType.Food:
                return level * GameConstant.FactoryFoodEfficiency;
                break;
            case FactoryType.Water:
                return level * GameConstant.FactoryWaterEfficiency;
                break;
            case FactoryType.Debris:
                break;
            case FactoryType.People:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        return 0;
    }
}