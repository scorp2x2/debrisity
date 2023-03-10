using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class PanelFactorysController : MonoBehaviour
{
    public GameObject panelCards;
    public List<PanelFactoryUpgradeController> PanelFactory;

    GameController _gameController;
    PanelCardsController _panelCardsController;

    [Inject]
    public void Construct(GameController gameController, PanelCardsController panelCardsController)
    {
        _gameController = gameController;
        _panelCardsController = panelCardsController;
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
        _gameController.UpdateResourcesUi(true);
        _panelCardsController.Show();
    }
}