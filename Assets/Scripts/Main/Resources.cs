using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Resources
{
    public static int People { get; private set; }
    public static int Water { get; private set; }
    public static int Food { get; private set; }
    public static int Debris { get; private set; }
    public static int Gold { get; private set; }
    public static int Day { get; private set; }

    public static int MaxPeople
    {
        get { return Factorys.FactoryBaracs.GetMaxStorage(); }
    }

    public static int MaxWater
    {
        get { return Factorys.FactoryWater.GetMaxStorage(); }
    }

    public static int MaxFood
    {
        get { return Factorys.FactoryFood.GetMaxStorage(); }
    }

    public static int MaxDebris
    {
        get { return Factorys.FactoryStorage.GetMaxStorage(); }
    }


    public static void GenerateRandomValue(int range = 10)
    {
        People += Random.Range(-range, range);
        Water += Random.Range(-range, range);
        Food += Random.Range(-range, range);
        Debris += Random.Range(-range, range);
        Gold += Random.Range(-range, range);
    }

    public static void AddDay()
    {
        Day++;
    }

    public static void SetStart()
    {
        People = 10;
        Water = 5;
        Food = 5;
        Debris = 5;
        Gold = 10;
        Day = 0;
    }

    public static bool AddResource(ProductionType productionType, int count)
    {
        switch (productionType)
        {
            case ProductionType.Gold:
                Gold += count;
                break;
            case ProductionType.Food:
                Food += count;
                if (Food > MaxFood) Food = MaxFood;
                break;
            case ProductionType.Water:
                Water += count;
                if (Water > MaxWater) Water = MaxWater;
                break;
            case ProductionType.Debris:
                Debris += count;
                if (Debris > MaxDebris) Debris = MaxDebris;
                break;
            case ProductionType.People:
                People += count;
                //if (People > MaxPeople) People = MaxPeople;
                break;
        }

        Debug.Log("Add: " + productionType + " " + count);
        return true;
    }

    public static bool EatResource(ProductionType productionType, int count)
    {
        switch (productionType)
        {
            case ProductionType.Gold:
                if (count > Gold) return false;
                Gold -= count;
                break;
            case ProductionType.Food:
                Food -= count;
                break;
            case ProductionType.Water:
                Water -= count;
                break;
            case ProductionType.Debris:
                if (count > Debris) return false;
                Debris -= count;
                break;
            case ProductionType.People:
                KillPeople(count);
                break;
        }

        Debug.Log("Eat: " + productionType + " " + count);
        return true;
    }


    public static void KillPeople(int count)
    {
        Debug.Log("Kill people: " + count);
    	
        People -= count;
        if (People <= 0)
        {
            GameController.Instantiate.GameOver();
        }

        if (Food < 0)
            Food = 0;
        if (Water < 0)
            Water = 0;
    }
}