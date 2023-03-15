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
    public PlayerSaveData PlayerSaveData;
    public GameSaveData GameSaveData;

    Production _lamp;
    Production Lamp
    {
        get
        {
            if (_lamp == null)
            {
                _lamp = Resources.LoadAll<Production>("").First(a => a.name == "Лампочки");
            }
            return _lamp;
        }
        set => _lamp = value;
    }

    public string pathSave
    {
        get => Application.persistentDataPath;
    }

    public string pathGameSave = "DSGameData.ds";
    public string pathPlayerSave = "DSPlayerData.ds";

    public SavedController()
    {
        LoadGame();
        PlayerLoad();
    }

    public void SaveGame()
    {
        //BinaryFormatter bf = new BinaryFormatter();
        //FileStream file = File.Create(pathSave);

        //bf.Serialize(file, PlayerData.PlayerStaticData);
        //file.Close();
        var path = Path.Combine(pathSave, pathGameSave);

        using (var writer = File.CreateText(path))
        {
            var serializer = new JsonSerializer();
            serializer.Serialize(writer, GameSaveData);
            Debug.Log("Game data saved! - " + path);
        }
    }

    public void LoadGame()
    {
        var path = Path.Combine(pathSave, pathGameSave);

        if (File.Exists(path))
        {
            //BinaryFormatter bf = new BinaryFormatter();
            //FileStream file = File.Open(pathSave, FileMode.Open);
            //var data = (PlayerStaticData) bf.Deserialize(file);
            //file.Close();

            var reader = File.ReadAllText(path);
            GameSaveData = JsonConvert.DeserializeObject<GameSaveData>(reader);
            GameSaveData.Synchronization();
            
            Debug.Log("Game data loaded! - " + path);
        }
        else
            NewGame();
    }

    public void NewGame()
    {
        GameSaveData = GameSaveData.GetDefault();
        SaveGame();
    }

    public void PlayerSave()
    {
        using (var writer = File.CreateText(Path.Combine(pathSave, pathPlayerSave)))
        {
            PlayerSaveData.LampCount = (uint)Lamp.Count;

            var serializer = new JsonSerializer();
            serializer.Serialize(writer, PlayerSaveData);
        }
    }

    public void PlayerLoad()
    {
        var path = Path.Combine(pathSave, pathPlayerSave);

        if (!File.Exists(path))
        {
            PlayerSaveData = PlayerSaveData.GetDefault();
            Lamp.ProductionData.count = (int)PlayerSaveData.LampCount;
            PlayerSave();
        }
        else
        {
            var reader = File.ReadAllText(path);
            PlayerSaveData = JsonConvert.DeserializeObject<PlayerSaveData>(reader);
            PlayerSaveData.Synchronization();
            Lamp.ProductionData.count = (int)PlayerSaveData.LampCount;
        }

    }
}