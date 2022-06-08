using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{
    public Text textName;
    public Text textInfo;
    public Image imageFon;
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
        imageFon.sprite = card.Sprite;

        Instruments.ClearChilds(panelPrize);
        CardPrizeControllers.Clear();
        foreach (var prize in card.CardPrizes)
        {
            var p = Instantiate(prefabPanel, panelPrize).GetComponent<CardPrizeController>();
            p.LoadInfo(prize);
            CardPrizeControllers.Add(p);
        }
    }

    public void OnMouseUpAsButton()
    {
        Card.Complete();
        PanelCardsController.Hide();
    }
}
