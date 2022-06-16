using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PanelFactorysController : MonoBehaviour
{
    public static PanelFactorysController Instantiate;

    void Awake()
    {
        Instantiate = this;
    }

    public GameObject panelCards;
    public List<PanelFactoryUpgradeController> PanelFactory;

    private void Start()
    {
        //PanelFactory = GameObject.FindObjectsOfType<PanelFactoryUpgradeController>().ToList();
    }

    public void Show()
    {
        panelCards.SetActive(true);
        foreach (var item in PanelFactory)
            item.Load();
    }

    public void Hide()
    {
        panelCards.SetActive(false);
    }

    public void End()
    {
        Hide();
        GameController.Instantiate.UpdateResourcesUi(true);
        PanelCardsController.Instantiate.Show();
    }
}