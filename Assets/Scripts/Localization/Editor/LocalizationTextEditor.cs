using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CustomEditor(typeof(LocalizationText))]
[CanEditMultipleObjects]
public class LocalizationTextEditor : Editor
{
    Localization Localization;
    LocalizationText LocalizationText;
    string newField = "";

    int indexSelected;
    KeyValuePair<string, string> nameField;
    public override void OnInspectorGUI()
    {

        if (Localization == null) LoadLocalizations();
        LocalizationText = target as LocalizationText;
        if (LocalizationText.TMP == null) LocalizationText.TMP = LocalizationText.GetComponent<TextMeshProUGUI>();
        if (LocalizationText.Text == null) LocalizationText.Text = LocalizationText.GetComponent<Text>(); ;
        EditorGUILayout.LabelField($"Текущее название: {LocalizationText.NameField}");

        //serializedObject.Update();
        //EditorGUILayout.PropertyField(lookAtPoint);
        //serializedObject.ApplyModifiedProperties();
        //if (lookAtPoint.vector3Value.y > (target as LookAtPoint).transform.position.y)
        //{
        if (GUILayout.Button("Обновить список полей"))
        {
            LoadLocalizations();
        }
        if (LocalizationText.NameField != null)
        {
            var locale = Localization.Localizations.Find(a => a.Key == "russian");
            indexSelected = locale.Value.FindIndex(a => a.Key == LocalizationText.NameField);
        }
        indexSelected = EditorGUILayout.Popup("Название поля:", indexSelected, Localization.Localizations.Find(a => a.Key == "russian").Value.Select(a => a.Key).ToArray());
        nameField = Localization.Localizations.Find(a => a.Key == "russian").Value[indexSelected];

        LocalizationText.NameField = nameField.Key;
        if (LocalizationText.TMP != null) LocalizationText.TMP.text = nameField.Value;
        if (LocalizationText.Text != null) LocalizationText.Text.text = nameField.Value;

        foreach (var item in Localization.Localizations)
        {
            var index = item.Value.FindIndex(a => a.Key == nameField.Key);
            if (index == -1)
            {
                item.Value.Add(new KeyValuePair<string, string>(nameField.Key, "НЕ ПЕРЕВЕДЕНО!!!"));
                index = item.Value.FindIndex(a => a.Key == nameField.Key);
            }

            var key = item.Value[index].Key;
            var value = item.Value[index].Value;

            item.Value[index] = new KeyValuePair<string, string>(item.Value[index].Key, EditorGUILayout.TextField(item.Key, value));
        }
        EditorGUILayout.Separator();
        newField = EditorGUILayout.TextField("Новое поле", newField);
        if (GUILayout.Button("Добавить поле"))
            Localization.AddFiled(newField);

        SaveLocalizations();
    }

    private void SaveLocalizations()
    {
        Localization.SaveLocalizations();
    }

    void LoadLocalizations()
    {
        Localization = FindObjectOfType<Localization>();
        Localization.LoadJson();
    }
}
