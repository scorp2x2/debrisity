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

        var localizations = Resources.LoadAll<TextAsset>("Localization");
        foreach (var localization in localizations)
        {
            var text = JsonConvert.DeserializeObject<List<KeyValuePair<string, string>>>(localization.text);
            Localizations.Add(new KeyValuePair<string, List<KeyValuePair<string, string>>>(localization.name, text));
        }
    }

    internal string GetText(string nameField)
    {
        var localization = Localizations.Find(a => a.Key == _saveController.PlayerSaveData.Language);

        if (localization.Value == null)
        {
            Debug.LogError("язык не найден");
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
        var localizationsFiles = Resources.LoadAll<TextAsset>("Localization");

        for (int i = 0; i < Localizations.Count; i++)
        {
            var item = Localizations[i];
            File.WriteAllText(Path.Combine("Assets/Resources/Localization", item.Key+".json"), JsonConvert.SerializeObject(item.Value, Formatting.Indented));
        }
    }
}
