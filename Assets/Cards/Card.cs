using System.Collections;
using System.Collections.Generic;
using UnityEngine;
  using UnityEditor;
using UnityEditor.UI;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName = "Card", fileName = "Card")]
public class Card : ScriptableObject
{
    public string Name;
    public string Text;
    public Sprite Sprite;

    [FormerlySerializedAs("Cards")] public List<CardPrize> CardPrizes;


    public void Complete()
    {
        foreach (var element in CardPrizes) {
    		element.Complete();
        }
    	
    	PanelCardsController.Instantiate.End();
    }
}

