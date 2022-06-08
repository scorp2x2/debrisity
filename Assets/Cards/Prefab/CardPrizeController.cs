using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardPrizeController : MonoBehaviour
{
    public Text textCount;
    public Image spitePrize;
    public Text textInfo;

    public Sprite spriteFood;
	 public Sprite spriteWater;
	 public Sprite spriteGold;
	 public Sprite spriteDebris;
	 public Sprite spritePeople;
	 
	 public Sprite spriteFactoryFood;
	 public Sprite spriteFactoryWater;
	 public Sprite spriteFactoryPeople;
	 public Sprite spriteFactoryDebris;
    
    public CardPrize CardPrize;
    
    public void LoadInfo(CardPrize cardPrize)
    {
        this.CardPrize = cardPrize;
        
        textCount.color = cardPrize.CardPrizeVector == CardPrizeVector.Positive ? Color.green : Color.red;

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
        textInfo.text = cardProduction.Text;
        textCount.text = cardProduction.prizeCount.ToString();

        switch (cardProduction.ProductionType)
        {
            case ProductionType.Food:
                spitePrize.sprite=spriteFood;
                break;
            case ProductionType.Water:
                spitePrize.sprite=spriteWater;
                break;
            case ProductionType.Debris:
                spitePrize.sprite=spriteDebris;
                break;
            case ProductionType.Gold:
                spitePrize.sprite=spriteGold;
                break;
            case ProductionType.People:
                spitePrize.sprite=spritePeople;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void LoadInfo(CardFactory cardFactory)
    {
        textCount.text = cardFactory.Text;

        switch (cardFactory.FactoryType)
        {
            case FactoryType.Food:
                spitePrize.sprite=spriteFactoryFood;
                textInfo.text = "Эффективность столовой";
                break;
            case FactoryType.Water:
                spitePrize.sprite=spriteFactoryWater;
                textInfo.text = "Эффективность водокачки";
                break;
            case FactoryType.Debris:
                spitePrize.sprite=spriteFactoryDebris;
                textInfo.text = "Эффективность добычи хлама";
                break;
            case FactoryType.People:
                spitePrize.sprite=spriteFactoryPeople;
                textInfo.text = "Эффективность появления людей";
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
    public void LoadInfo(CardEffect cardEffect)
    {

    }
}
