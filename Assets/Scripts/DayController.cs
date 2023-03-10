using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DayController : MonoBehaviour
{

    public Text dayText;

    PanelFarmController _panelFarmController;
    ManagerResources _managerResources;
    GameController _gameController;
    SityController _sityController;
    PanelStatsController _panelStatsController;

    [Inject]
    public void Construct(PanelFarmController panelFarmController, ManagerResources managerResources, GameController gameController, SityController sityController, PanelStatsController panelStatsController)
    {
        _panelFarmController = panelFarmController;
        _managerResources = managerResources;
        _gameController = gameController;
        _sityController = sityController;
        _panelStatsController = panelStatsController;
    }

    public void ReDrawDayCount()
    {
        dayText.text = _managerResources.days.Count.ToString();
    }

    public void NextDay()
    {
        _panelFarmController.Show();
    }

    public void EndDay()
    {
        _managerResources.AddDay();
        ////Resources.GenerateRandomValue();
        Debug.Log("CalcEconomicDay");
        _managerResources.CalcEconomicDay();
        Debug.Log("WorkFactorys");
        _sityController.WorkFactorys();

        Debug.Log("CalcPeople");
        _managerResources.CalcPeople();

        Debug.Log("UpdateResourcesUI");
        _gameController.UpdateResourcesUi(true);
        _sityController.UpdateInfoFactorys();
        Debug.Log("UpdateCountPeople");
        _sityController.UpdateCountPeople();
        ReDrawDayCount();

        _panelStatsController.Show();
    }
}