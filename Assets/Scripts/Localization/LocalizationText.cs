using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class LocalizationText : MonoBehaviour
{
    public string NameField;
    public TextMeshProUGUI TMP;
    public Text Text;

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
        if (TMP != null) TMP.text = _localization.GetText(NameField);
        if (Text != null) Text.text = _localization.GetText(NameField);
    }
}
