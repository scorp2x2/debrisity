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

    //PanelCardsController _panelCardsController;

    //[Inject]
    //public void Construct(PanelCardsController panelCardsController)
    //{
    //    _panelCardsController = panelCardsController;
    //}

    public void Complete(ManagerResources managerResources)
    {
        foreach (var element in CardPrizes) {
    		element.Complete(managerResources);
        }

        //_panelCardsController.End();
    }
}

