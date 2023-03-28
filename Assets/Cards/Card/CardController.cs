using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CardController : MonoBehaviour
{
    public Text textName;
    public Text textInfo;
    public Image imageFon;
    public GameObject imageBlock;
    public Transform panelPrize;
    public GameObject prefabPanel;

    public List<CardPrizeController> CardPrizeControllers;
    public PanelCardsController PanelCardsController;

    public Card Card;

    ManagerResources _managerResources;
    Localization _localization;
    DiContainer _container;

    [Inject]
    public void Construct(ManagerResources managerResources, Localization localization, DiContainer container)
    {
        _localization = localization;
        _managerResources = managerResources;
        _container = container;
    }

    public void Load(Card card, PanelCardsController panelCardsController)
    {
        this.Card = card;
        PanelCardsController = panelCardsController;

        textName.text = _localization.GetText(card.FieldNameCaption);
        textInfo.text = _localization.GetText(card.FieldNameInfo);
        if (card.Sprite == null) imageFon.gameObject.SetActive(false);
        imageFon.sprite = card.Sprite;

        Instruments.ClearChilds(panelPrize);
        CardPrizeControllers.Clear();
        ShowBlock(false);

        foreach (var prize in card.CardPrizes)
        {
            var p = _container.InstantiatePrefab(prefabPanel, panelPrize).GetComponent<CardPrizeController>();
            p.LoadInfo(prize);
            CardPrizeControllers.Add(p);

            if (prize is CardProduction cardProduction)
                if (cardProduction.CardPrizeVector == CardPrizeVector.Negative)
                {
                    ////TODO: надо проверять не все типы ресурсов
                    int count = cardProduction.production.Count;

                    if (count < cardProduction.GetPrizeCount())
                        ShowBlock(true);
                }
        }
    }

    public void ShowBlock(bool isShow)
    {
        imageBlock.SetActive(isShow);
    }

    public void OnMouseUpAsButton()
    {
        Card.Complete(_managerResources, _localization);
        PanelCardsController.End();
    }
}