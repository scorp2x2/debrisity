using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CardPrize))]
public class CardPrizeEditor : Editor
{
    CardPrize _cardPrize;
    SerializedProperty prizeCount;
    SerializedProperty cardPrizeVector;
    SerializedProperty text;

    Localization Localization;

    int indexSelected;
    KeyValuePair<string, string> nameField;

    public void OnEnable()
    {
        _cardPrize = (CardPrize)target;
        prizeCount = serializedObject.FindProperty("prizeCount");
        cardPrizeVector = serializedObject.FindProperty("CardPrizeVector");
        text = serializedObject.FindProperty("Text");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        EditorGUILayout.PropertyField(prizeCount);
        EditorGUILayout.PropertyField(cardPrizeVector);
        EditorGUILayout.PropertyField(text);

        //_factory.Name = EditorGUILayout.TextField("���", _factory.Name);
        //_factory.Price = EditorGUILayout.IntField("���� � ������", _factory.Price);
        //EditorGUILayout.Space(20);
        //EditorGUILayout.LabelField("HumanSkinData");
        //_factory.HumanSkinData.IsBuy = EditorGUILayout.Toggle("������ � ������", _factory.HumanSkinData.IsBuy);
        //_factory.HumanSkinData.IsSelected = EditorGUILayout.Toggle("������ � ������", _factory.HumanSkinData.IsSelected);
        //EditorGUILayout.LabelField("�������� � ����: " + _factory.HumanSkinData.Name);


        EditorGUILayout.Space(30);
        EditorGUILayout.LabelField("�������");

        if (Localization == null) LoadLocalizations();

        if (GUILayout.Button("�������� ������ �����"))
        {
            LoadLocalizations();
        }
        if (_cardPrize.Text != null)
        {
            var locale = Localization.Localizations.Find(a => a.Key == "russian");
            indexSelected = locale.Value.FindIndex(a => a.Key == _cardPrize.FieldName);
        }

        if (indexSelected == -1)
        {
            Localization.AddFiled(_cardPrize.FieldName);
            var locale = Localization.Localizations.Find(a => a.Key == "russian");
            indexSelected = locale.Value.FindIndex(a => a.Key == _cardPrize.FieldName);
        }
        indexSelected = EditorGUILayout.Popup("�������� ����:", indexSelected, Localization.Localizations.Find(a => a.Key == "russian").Value.Select(a => a.Key).ToArray());
        nameField = Localization.Localizations.Find(a => a.Key == "russian").Value[indexSelected];

        foreach (var item in Localization.Localizations)
        {
            var index = item.Value.FindIndex(a => a.Key == nameField.Key);
            if (index == -1)
            {
                item.Value.Add(new KeyValuePair<string, string>(nameField.Key, "�� ����������!!!"));
                index = item.Value.FindIndex(a => a.Key == nameField.Key);
            }

            var key = item.Value[index].Key;
            var value = item.Value[index].Value;

            item.Value[index] = new KeyValuePair<string, string>(item.Value[index].Key, EditorGUILayout.TextField(item.Key, value));
        }

        //EditorGUILayout.Separator();
        //newField = EditorGUILayout.TextField("����� ����", newField);
        //if (GUILayout.Button("�������� ����"))
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