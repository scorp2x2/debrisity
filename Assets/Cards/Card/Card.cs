using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using Zenject;

[CreateAssetMenu(menuName = "Card", fileName = "Card")]
public class Card : ScriptableObject
{
    public string Name;
    public string Text;
    public Sprite Sprite;

    [FormerlySerializedAs("Cards")] public List<CardPrize> CardPrizes;

    public string FieldNameCaption { get => $"{this.GetInstanceID()}_caption"; }
    public string FieldNameInfo { get => $"{this.GetInstanceID()}_info"; }

    public void Complete(ManagerResources managerResources, Localization localization)
    {
        foreach (var element in CardPrizes)
        {
            element.Complete(managerResources, localization);
        }
    }
}

