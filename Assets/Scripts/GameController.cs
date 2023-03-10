using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    public GameOverPanel gameOverPanel;
    public List<ResourceController> resourceControllers;

    SavedController _savedController;
    ManagerResources _managerResources;
    PanelStatsController _panelStatsController;
    DayController _dayController;
    SityController _sityController;

    [Inject]
    public void Construct(SavedController savedController, ManagerResources managerResources, PanelStatsController panelStatsController, DayController dayController, SityController sityController)
    {
        _savedController = savedController;
        _managerResources = managerResources;
        _panelStatsController = panelStatsController;
        _dayController = dayController;
        _sityController = sityController;
    }

    void Awake()
    {
        resourceControllers = FindObjectsOfType<ResourceController>().ToList();
        StartGame();
    }

    public void StartGame()
    {
        gameOverPanel.gameObject.SetActive(false);
        _sityController.UpdateCountPeople();
        _managerResources.ClearStatistic();
        _dayController.ReDrawDayCount();
        _panelStatsController.Hide();
        _sityController.UpdateInfoFactorys();

        UpdateResourcesUi(false);
    }

    public void NewGame()
    {
        _savedController.NewGame();
        StartGame();
    }

    public void UpdateResourcesUi(bool isUpdateArrow)
    {
        foreach (var element in resourceControllers)
        {
            element.UpdateValue(isUpdateArrow);
        }
    }
}