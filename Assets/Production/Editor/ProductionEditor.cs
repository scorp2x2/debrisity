using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

[CustomEditor(typeof(Production))]
public class ProductionEditor : Editor
{
    Production _production;
    SerializedProperty icon;
    SerializedProperty _name;
    SerializedProperty productionData;

    Localization Localization;

    int indexSelected;
    KeyValuePair<string, string> nameField;

    public void OnEnable()
    {
        _production = (Production)target;
        icon = serializedObject.FindProperty("Icon");
        productionData = serializedObject.FindProperty("ProductionData");
        _name = serializedObject.FindProperty("name");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(icon);
        EditorGUILayout.PropertyField(productionData);
        EditorGUILayout.PropertyField(_name);

        //_factory.Name = EditorGUILayout.TextField("Имя", _factory.Name);
        //_factory.Price = EditorGUILayout.IntField("Цена в лампах", _factory.Price);
        //EditorGUILayout.Space(20);
        //EditorGUILayout.LabelField("HumanSkinData");
        //_factory.HumanSkinData.IsBuy = EditorGUILayout.Toggle("Куплен у игрока", _factory.HumanSkinData.IsBuy);
        //_factory.HumanSkinData.IsSelected = EditorGUILayout.Toggle("Выбран у игрока", _factory.HumanSkinData.IsSelected);
        //EditorGUILayout.LabelField("Название в дате: " + _factory.HumanSkinData.Name);


        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("Перевод");

        if (Localization == null) LoadLocalizations();

        if (GUILayout.Button("Обновить список полей"))
        {
            LoadLocalizations();
        }
        if (_production.name != null)
        {
            var locale = Localization.Localizations.Find(a => a.Key == "russian");
            indexSelected = locale.Value.FindIndex(a => a.Key == _production.FieldName);
        }

        if (indexSelected == -1)
        {
            Localization.AddFiled(_production.FieldName);
            var locale = Localization.Localizations.Find(a => a.Key == "russian");
            indexSelected = locale.Value.FindIndex(a => a.Key == _production.FieldName);
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
        serializedObject.ApplyModifiedProperties();

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