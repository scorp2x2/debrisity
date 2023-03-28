using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(HumanSkin))]
public class HumanSkinEditor : Editor
{
    HumanSkin _humanSkin;
    SerializedProperty prefab;

    Localization Localization;

    int indexSelected;
    KeyValuePair<string, string> nameField;

    public void OnEnable()
    {
        _humanSkin = (HumanSkin)target;
        prefab = serializedObject.FindProperty("Prefab");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(prefab);
        serializedObject.ApplyModifiedProperties();

        _humanSkin.Name = EditorGUILayout.TextField("Имя", _humanSkin.Name);
        _humanSkin.Price = EditorGUILayout.IntField("Цена в лампах", _humanSkin.Price);
        EditorGUILayout.Space(20);
        EditorGUILayout.LabelField("HumanSkinData");
        _humanSkin.HumanSkinData.IsBuy = EditorGUILayout.Toggle("Куплен у игрока", _humanSkin.HumanSkinData.IsBuy);
        _humanSkin.HumanSkinData.IsSelected = EditorGUILayout.Toggle("Выбран у игрока", _humanSkin.HumanSkinData.IsSelected);
        EditorGUILayout.LabelField("Название в дате: " + _humanSkin.HumanSkinData.Name);


        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("Перевод");

        if (Localization == null) LoadLocalizations();

        if (GUILayout.Button("Обновить список полей"))
        {
            LoadLocalizations();
        }
        if (_humanSkin.Name != null)
        {
            var locale = Localization.Localizations.Find(a => a.Key == "russian");
            indexSelected = locale.Value.FindIndex(a => a.Key == _humanSkin.FieldName);
        }

        if (indexSelected == -1)
        {
            Localization.AddFiled(_humanSkin.FieldName);
            var locale = Localization.Localizations.Find(a => a.Key == "russian");
            indexSelected = locale.Value.FindIndex(a => a.Key == _humanSkin.FieldName);
        }
        indexSelected = EditorGUILayout.Popup("Название поля:", indexSelected, Localization.Localizations.Find(a => a.Key == "russian").Value.Select(a => a.Key).ToArray());
        nameField = Localization.Localizations.Find(a => a.Key == "russian").Value[indexSelected];

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

        //EditorGUILayout.Separator();
        //newField = EditorGUILayout.TextField("Новое поле", newField);
        //if (GUILayout.Button("Добавить поле"))
        //    Localization.AddFiled(newField);

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

