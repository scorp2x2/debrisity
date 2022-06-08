using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelCardsController : MonoBehaviour
{
	public static PanelCardsController Instantiate;
	
	void Awake(){
		Instantiate=this;
	}
	
    public GameObject panel;
    public Transform panelCards;
    public GameObject prefabCard;

    private List<Card> _card;

    public List<Card> Cards
    {
        get
        {
            if (_card==null)
            {
                _card = new List<Card>();
                _card = UnityEngine.Resources.LoadAll<Card>(@"Cards").ToList();
            }

            return _card;
        }
    }

    public List<CardController> CardControllers;


    private void Start()
    {
    }

    public void GenerateCard(int count = 3)
    {
        panel.SetActive(true);
        Instruments.ClearChilds(panelCards);

        CardControllers.Clear();
        for (int i = 0; i < count; i++)
        {
            var card = Cards[Random.Range(0, Cards.Count)];

            var c = Instantiate(prefabCard, panelCards).GetComponent<CardController>();
            c.Load(card, this);
            CardControllers.Add(c);
        }
    }

    public void Hide()
    {
        panel.SetActive(false);
    }
    
    public void End(){
    	Hide();
    	DayController.Instantiate.EndDay();
    }
}