using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HumanSkin", menuName = "Skins/Human")]
public class HumanSkin : ScriptableObject
{
    public GameObject Prefab;
    public string Name;
    public int Price;
    public HumanSkinData HumanSkinData;

    public string FieldName { get => $"{name}_{Name}"; }
}