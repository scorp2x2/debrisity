using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    public void Load(Card card, PanelCardsController panelCardsController)
    {
        this.Card = card;
        PanelCardsController = panelCardsController;

        textName.text = card.Name;
        textInfo.text = card.Text;
        if (card.Sprite == null) imageFon.gameObject.SetActive(false);
        imageFon.sprite = card.Sprite;

        Instruments.ClearChilds(panelPrize);
        CardPrizeControllers.Clear();
        ShowBlock(false);

        foreach (var prize in card.CardPrizes)
        {
            var p = Instantiate(prefabPanel, panelPrize).GetComponent<CardPrizeController>();
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
        Card.Complete();
        PanelCardsController.Hide();
    }
}