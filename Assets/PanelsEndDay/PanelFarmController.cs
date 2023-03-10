using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PanelFarmController : MonoBehaviour
{
    public GameObject panelFarms;
    public List<CardFarmController> CardsFarm;

    GameController _gameController;
    PanelFactorysController _panelFactorysController;

    [Inject]
    public void Construct(GameController gameController, PanelFactorysController panelFactorysController)
    {
        _gameController = gameController;
        _panelFactorysController = panelFactorysController;
    }

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
        _gameController.UpdateResourcesUi(true);
        _panelFactorysController.Show();
    }
}