using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class PlayerSaveData
{
    public List<HumanSkinData> HumanSkinDatas;

    readonly int maxCountRecords = 30;
    public List<float> ScoreRecords;

    public float MusicVolume;
    public float SoundsVolume;
    public uint LampCount;
    public string Language;
    public bool IsBuySkipADS;
    public DateTime[] TimeViewAds;

    public static PlayerSaveData GetDefault()
    {
        PlayerSaveData playerSaveData = new PlayerSaveData();

        playerSaveData.ScoreRecords = new List<float>();
        playerSaveData.TimeViewAds = new DateTime[3];

        playerSaveData.IsBuySkipADS = false;

        playerSaveData.Language = "english";
        playerSaveData.LampCount = 5;
        playerSaveData.IsBuySkipADS = false;

        playerSaveData.HumanSkinDatas = Resources.LoadAll<HumanSkin>("HumanSkins").OrderBy(a => a.name).Select(a => a.HumanSkinData).ToList();
        playerSaveData.HumanSkinDatas.ForEach(a => a.Load(new HumanSkinData() { IsBuy = false, IsSelected = false }));

        playerSaveData.HumanSkinDatas.First(a => a.Name == "Обычный").Load(new HumanSkinData() { IsBuy = true, IsSelected = true });

        //playerSaveData.BuySkins = new List<string>()
        //{
        //    "0 Skin_Default"
        //};
        //playerSaveData.NameSkin = "0 Skin_Default";

        return playerSaveData;
    }

    public void AddRecords(float record)
    {
        ScoreRecords.Add(record);
        ScoreRecords.Sort();

        if (ScoreRecords.Count > maxCountRecords)
            ScoreRecords.RemoveAt(ScoreRecords.Count - 1);
    }

    public void Synchronization()
    {
        var datas = Resources.LoadAll<HumanSkin>("HumanSkins").OrderBy(a => a.name).ToList();

        for (int i = 0; i < datas.Count; i++)
        {
            int j = HumanSkinDatas.FindIndex(a => a.Name == datas[i].Name);
            datas[i].HumanSkinData.Load(HumanSkinDatas[j]);
            HumanSkinDatas[j] = datas[i].HumanSkinData;
        }
    }
}
