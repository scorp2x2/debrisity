using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;
using Zenject;
using Newtonsoft.Json;

public class SavedController
{
    public PlayerData PlayerData;

    [Inject]
    private void Construct(PlayerData playerData)
    {
        PlayerData = playerData;
        LoadGame();
    }


    public string pathSave
    {
        get => Application.persistentDataPath + "/DSSaveData.ds";
    }

    public void SaveGame()
    {
        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create(pathSave);

        //bf.Serialize(file, PlayerData.PlayerStaticData);
        //file.Close();

        using (var writer = File.CreateText(pathSave))
        {
            var serializer = new JsonSerializer();
            serializer.Serialize(writer, PlayerData.PlayerStaticData);
            Debug.Log("Game data saved! - " + pathSave);
        }
    }

    public void LoadGame()
    {
        if (File.Exists(pathSave))
        {
            //BinaryFormatter bf = new BinaryFormatter();
            //FileStream file = File.Open(pathSave, FileMode.Open);
            //var data = (PlayerStaticData) bf.Deserialize(file);
            //file.Close();

            var reader = File.ReadAllText(pathSave);
            var data = JsonConvert.DeserializeObject<PlayerStaticData>(reader);

            for (int i = 0; i < data.FactoryDatas.Count; i++)
                PlayerData.Factories[i].FactoryData.Load(data.FactoryDatas[i]);
            for (int i = 0; i < data.ProductionDatas.Count; i++)
                PlayerData.Productions[i].ProductionData.Load(data.ProductionDatas[i]);
            for (int i = 0; i < data.HumanSkinDatas.Count; i++)
                PlayerData.HumanSkins.Find(a => a.HumanSkinData.Name == data.HumanSkinDatas[i].Name).HumanSkinData.Load(data.HumanSkinDatas[i]);



            Debug.Log("Game data loaded! - " + pathSave);
        }
        else
            NewGame();
    }

    public void NewGame()
    {
        PlayerData.Factories.ForEach(a => a.SetDefault());
        PlayerData.Productions.ForEach(a=>a.SetDefault());
        Debug.Log("New game!");
        SaveGame();
    }
}