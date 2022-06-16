using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelFarmController : MonoBehaviour
{
    public static PanelFarmController Instantiate;

    void Awake()
    {
        Instantiate = this;
    }

    public GameObject panelFarms;
    public List<CardFarmController> CardsFarm;

    public void Show()
    {
        panelFarms.SetActive(true);
        foreach (var item in CardsFarm)
            item.UpdateValue();
    }

    public void Hide()
    {
        panelFarms.SetActive(false);
    }

    public void End()
    {
        Hide();
        GameController.Instantiate.UpdateResourcesUi(true);
        PanelFactorysController.Instantiate.Show();
    }
}