using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

[CustomEditor(typeof(Factory))]
public class FactoryEditor : Editor
{
    Factory _factory;
    SerializedProperty icon;
    SerializedProperty messageStatistic;
    SerializedProperty production;
    SerializedProperty efficiency;
    SerializedProperty multiplayEfficiency;
    SerializedProperty multiplayCapacity;
    SerializedProperty multiplayLVLEfficiency;
    SerializedProperty multiplayLVLCapacity;
    SerializedProperty capacity;
    SerializedProperty goldPriceUpgradeEfficiency;
    SerializedProperty goldPriceUpgradeCapacity;
    SerializedProperty debrisPriceUpgradeEfficiency;
    SerializedProperty debrisPriceUpgradeCapacity;
    SerializedProperty factoryData;


    Localization Localization;

    int indexSelected;
    KeyValuePair<string, string> nameField;

    public void OnEnable()
    {
        _factory = (Factory)target;
        icon = serializedObject.FindProperty("Icon");
        messageStatistic = serializedObject.FindProperty("messageStatistic");
        production = serializedObject.FindProperty("production");
        efficiency = serializedObject.FindProperty("Efficiency");
        multiplayEfficiency = serializedObject.FindProperty("multiplayEfficiency");
        multiplayCapacity = serializedObject.FindProperty("multiplayCapacity");
        multiplayLVLEfficiency = serializedObject.FindProperty("multiplayLVLEfficiency");
        multiplayLVLCapacity = serializedObject.FindProperty("multiplayLVLCapacity");
        capacity = serializedObject.FindProperty("Capacity");
        goldPriceUpgradeEfficiency = serializedObject.FindProperty("GoldPriceUpgradeEfficiency");
        goldPriceUpgradeCapacity = serializedObject.FindProperty("GoldPriceUpgradeCapacity");
        debrisPriceUpgradeEfficiency = serializedObject.FindProperty("DebrisPriceUpgradeEfficiency");
        debrisPriceUpgradeCapacity = serializedObject.FindProperty("DebrisPriceUpgradeCapacity");
        factoryData = serializedObject.FindProperty("FactoryData");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        //EditorGUILayout.PropertyField(icon);
        //EditorGUILayout.PropertyField(messageStatistic);
        //EditorGUILayout.PropertyField(production);
        //EditorGUILayout.PropertyField(efficiency);
        //EditorGUILayout.PropertyField(multiplayEfficiency);
        //EditorGUILayout.PropertyField(multiplayCapacity);
        //EditorGUILayout.PropertyField(multiplayLVLEfficiency);
        //EditorGUILayout.PropertyField(multiplayLVLCapacity);
        //EditorGUILayout.PropertyField(capacity);
        //EditorGUILayout.PropertyField(goldPriceUpgradeEfficiency);
        //EditorGUILayout.PropertyField(goldPriceUpgradeCapacity);
        //EditorGUILayout.PropertyField(debrisPriceUpgradeEfficiency);
        //EditorGUILayout.PropertyField(debrisPriceUpgradeCapacity);
        //EditorGUILayout.PropertyField(factoryData);

        DrawDefaultInspector();




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
        if (_factory.messageStatistic != null)
        {
            var locale = Localization.Localizations.Find(a => a.Key == "russian");
            indexSelected = locale.Value.FindIndex(a => a.Key == _factory.FieldName);
        }

        if (indexSelected == -1)
        {
            Localization.AddFiled(_factory.FieldName);
            var locale = Localization.Localizations.Find(a => a.Key == "russian");
            indexSelected = locale.Value.FindIndex(a => a.Key == _factory.FieldName);
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