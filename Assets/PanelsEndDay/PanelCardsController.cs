using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class PanelCardsController : MonoBehaviour
{
    public static PanelCardsController Instantiate;

    void Awake()
    {
        Instantiate = this;
    }

    public GameObject panel;
    public Transform panelCards;
    public GameObject prefabCard;

    public Text countLampReset;
    public Button buttonLampReset;

    private List<Card> _card;

    public List<Card> Cards
    {
        get
        {
            if (_card == null)
            {
                _card = new List<Card>();
                _card = UnityEngine.Resources.LoadAll<Card>(@"Cards").ToList();
            }

            return _card;
        }
    }

    public List<CardController> CardControllers;


    public void ResetCards()
    {
        var c = int.Parse(countLampReset.text);

        if (ManagerResources.Instantiate.diamonds.Eat(c))
        {
            GenerateCard();
        }
    }

    void GenerateCard(int count = 3)
    {
        var newC = Mathf.RoundToInt(int.Parse(countLampReset.text) * GameConstant.CountUpDiamondFromResetCards);
        countLampReset.text = newC.ToString();
        if (ManagerResources.Instantiate.diamonds.Count >= newC)
        {
            buttonLampReset.interactable = true;
        }
        else
            buttonLampReset.interactable = false;
        
        panelCards.ClearChilds();
        CardControllers.Clear();

        while (CardControllers.Count != count)
        {
            var card = Cards[Random.Range(0, Cards.Count)];

            if (CardControllers.Any(a => a.Card == card))
                continue;

            var c = Instantiate(prefabCard, panelCards).GetComponent<CardController>();
            c.Load(card, this);
            CardControllers.Add(c);
        }

        if (CardControllers.All(a => a.imageBlock.activeSelf == true))
            GenerateCard(3);
    }

    public void Show()
    {
        panel.SetActive(true);
        countLampReset.text = GameConstant.CountDiamondFromResetCards.ToString();

        GenerateCard(3);
    }

    public void Hide()
    {
        panel.SetActive(false);
    }

    public void End()
    {
        Hide();
        GameController.Instantiate.UpdateResourcesUi(true);
        DayController.Instantiate.EndDay();
    }
}