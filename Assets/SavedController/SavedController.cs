using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Linq;

public class SavedController : MonoBehaviour
{
    public static SavedController Instantiate;

    public string pathSave
    {
        get => Application.persistentDataPath + "/DSSaveData.ds";
    }

    private void Awake()
    {
        Instantiate = this;
    }
    
    public void SaveGame()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(pathSave);

        bf.Serialize(file, PlayerData.Instantiate.PlayerStaticData);
        file.Close();
        Debug.Log("Game data saved!");
    }

    public void LoadGame()
    {
        if (File.Exists(pathSave))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
                File.Open(pathSave, FileMode.Open);
            PlayerData data = (PlayerData) bf.Deserialize(file);
            file.Close();

            for (int i = 0; i < data.FactoryDatas.Count; i++)
                Factories[i].FactoryData = data.FactoryDatas[i];
            for (int i = 0; i < data.ProductionDatas.Count; i++)
                Productions[i].ProductionData = data.ProductionDatas[i];
            for (int i = 0; i < data.HumanSkinDatas.Count; i++)
                HumanSkins[i].HumanSkinData = data.HumanSkinDatas[i];
            
            

            Debug.Log("Game data loaded!");
        }
        else
            NewGame();
    }

    public void NewGame()
    {
        Factories.ForEach(a => a.SetDefault());
        Productions.ForEach(a=>a.SetDefault());
        SaveGame();
    }
}