using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using Zenject;

public class Localization : MonoBehaviour
{
    public List<KeyValuePair<string, List<KeyValuePair<string, string>>>> Localizations;

    SignalBus _signalBus;
    SavedController _saveController;

    TextAsset[] _textAssets;

    [Inject]
    void Construct(SignalBus signalBus, SavedController saveController)
    {
        _signalBus = signalBus;
        _saveController = saveController;
        LoadLocalizations();
    }

    public void LoadLocalizations()
    {
        Localizations = new List<KeyValuePair<string, List<KeyValuePair<string, string>>>>();

        _textAssets = Resources.LoadAll<TextAsset>("Localization");
        foreach (var localization in _textAssets)
        {
            var text = JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(localization.text);
            Localizations.Add(new KeyValuePair<string, List<KeyValuePair<string, string>>>(localization.name, text));
        }
    }

    public void LoadJson()
    {
        Localizations = new List<KeyValuePair<string, List<KeyValuePair<string, string>>>>();

        _textAssets = Resources.LoadAll<TextAsset>("Localization");
        foreach (var localization in _textAssets)
        {
            var text = JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(File.ReadAllText(Path.Combine("Assets/Resources/Localization", localization.name + ".json")));
            Localizations.Add(new KeyValuePair<string, List<KeyValuePair<string, string>>>(localization.name, text));
        }
    }

    internal string GetText(string nameField)
    {
        var localization = Localizations.Find(a => a.Key == _saveController.PlayerSaveData.Language);

        if (localization.Value == null)
        {
            Debug.LogError("ﬂÁ˚Í ÌÂ Ì‡È‰ÂÌ");
            return Localizations.Find(a => a.Key == "english").Value.Find(a => a.Key == nameField).Value;
        }

        var pare = localization.Value.Find(a => a.Key == nameField);
        if (pare.Value != null)
            return pare.Value;
        else
            return Localizations.Find(a => a.Key == "english").Value.Find(a => a.Key == nameField).Value;
    }

    public void ChangeLanguage(string language)
    {
        _saveController.PlayerSaveData.Language = language;
        _signalBus.Fire<ChangeLanguage>();
        _saveController.PlayerSave();
    }

    public void SaveLocalizations()
    {
        foreach (var item in _textAssets)
            Resources.UnloadAsset(item);
        
        for (int i = 0; i < Localizations.Count; i++)
        {
            var item = Localizations[i];
            File.WriteAllText(Path.Combine("Assets/Resources/Localization", item.Key + ".json"), JsonConvert.SerializeObject(item.Value, Formatting.Indented));
        }

        LoadJson();
    }

    public void AddFiled(string newField)
    {
        foreach (var item in Localizations)
            item.Value.Add(new KeyValuePair<string, string>(newField, "Õ≈ œ≈–≈¬≈ƒ≈ÕŒ!!!"));
    }
}
