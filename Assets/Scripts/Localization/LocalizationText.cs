using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

public class LocalizationText : MonoBehaviour
{
    public string NameField;
    public TextMeshProUGUI TMP;

    Localization _localization;

    [Inject]
    void Construct(Localization localization, SignalBus signalBus)
    {
        _localization = localization;
        signalBus.Subscribe<ChangeLanguage>(OnChangeLanguage);
        UpdateText();
    }

    private void OnChangeLanguage()
    {
        UpdateText();
    }

    void UpdateText()
    {
        TMP.text = _localization.GetText(NameField);
    }
}
