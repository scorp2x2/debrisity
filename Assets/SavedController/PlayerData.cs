using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class PlayerData : MonoBehaviour
{
    []
    public PlayerStaticData PlayerStaticData;
    public static PlayerData Instantiate;

    public List<Production> Productions;
    public List<Factory> Factories;

    public List<HumanSkin> HumanSkins;
    //public PlayerData PlayerData { get; private set; }

    private void Awake()
    {
        Instantiate = this;

        Productions = Resources.LoadAll<Production>("Productions").OrderBy(a => a.name).ToList();
        Factories = Resources.LoadAll<Factory>("Factories").OrderBy(a => a.name).ToList();
        HumanSkins = Resources.LoadAll<HumanSkin>("HumanSkins").OrderBy(a => a.name).ToList();

        PlayerStaticData = new PlayerStaticData()
        {
            FactoryDatas = Factories.Select(a => a.FactoryData).ToList(),
            ProductionDatas = Productions.Select(a => a.ProductionData).ToList(),
            HumanSkinDatas = HumanSkins.Select(a => a.HumanSkinData).ToList()
        };
    }

    public void Save()
    {
    }
}