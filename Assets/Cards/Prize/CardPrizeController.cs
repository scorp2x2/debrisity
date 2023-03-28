using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CardPrizeController : MonoBehaviour
{
    public Text textCount;
    public Image spitePrize;
    public Text textInfo;

    public CardPrize CardPrize;

    Localization _localization;

    [Inject]
    public void Construct(Localization localization)
    {
        _localization = localization;
    }

    public void LoadInfo(CardPrize cardPrize)
    {
        this.CardPrize = cardPrize;

        textCount.color = cardPrize.CardPrizeVector == CardPrizeVector.Positive
            ? new Color(0.2705882f, 0.5254902f, 0)
            : Color.red;

        switch (cardPrize)
        {
            case CardEffect cardEffect:
                LoadInfo(cardEffect);
                break;
            case CardFactory cardFactory:
                LoadInfo(cardFactory);
                break;
            case CardProduction cardProduction:
                LoadInfo(cardProduction);
                break;
        }
    }

    public void LoadInfo(CardProduction cardProduction)
    {
        textInfo.text = _localization.GetText(cardProduction.FieldName);
        textCount.text = $"{(cardProduction.CardPrizeVector == CardPrizeVector.Positive ? "+" : "-")}{cardProduction.GetPrizeCount()}";

        spitePrize.sprite = cardProduction.production.Icon;
    }

    public void LoadInfo(CardFactory cardFactory)
    {
        textCount.text = cardFactory.Text;
        spitePrize.sprite = cardFactory.Factory.Icon;
        textInfo.text = "Эффективность добычи"; ////TODO: Разные надписи для разных типов производства
    }

    public void LoadInfo(CardEffect cardEffect)
    {
    }
}