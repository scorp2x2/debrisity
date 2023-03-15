using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(LocalizationText))]
[CanEditMultipleObjects]
public class LocalizationTextEditor : Editor
{
    Localization Localization;
    LocalizationText LocalizationText;

    int indexSelected;
    KeyValuePair<string, string> nameField;
    public override void OnInspectorGUI()
    {

        if (Localization == null) LoadLocalizations();
        LocalizationText = target as LocalizationText;
        if (LocalizationText.TMP == null)
        {
            LocalizationText.TMP = LocalizationText.GetComponent<TextMeshProUGUI>();
        }

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
            indexSelected = Localization.Localizations.Find(a => a.Key == "russian").Value.FindIndex(a => a.Key == LocalizationText.NameField);
        }
        indexSelected = EditorGUILayout.Popup("Название поля:", indexSelected, Localization.Localizations.Find(a => a.Key == "russian").Value.Select(a => a.Key).ToArray());
        nameField = Localization.Localizations.Find(a => a.Key == "russian").Value[indexSelected];

        LocalizationText.NameField = nameField.Key;
        LocalizationText.TMP.text = nameField.Value;

        foreach (var item in Localization.Localizations)
        {
            var value = item.Value.Find(a => a.Key == nameField.Key);
            if (value.Value != null)
            {
                EditorGUILayout.LabelField($"{item.Key}: {value.Value}");
            }
            else
            {
                EditorGUILayout.LabelField($"{item.Key}: Не переведено");
            }
        }


    }

    void LoadLocalizations()
    {
        Localization = FindObjectOfType<Localization>();
        Localization.LoadLocalizations();
    }
}
