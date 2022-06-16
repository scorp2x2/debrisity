using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Instantiate;

    public GameOverPanel gameOverPanel;
    public List<ResourceController> resourceControllers;

    void Awake()
    {
        Instantiate = this;

        resourceControllers = FindObjectsOfType<ResourceController>().ToList();
        StartGame();
    }

    public void StartGame()
    {
        gameOverPanel.gameObject.SetActive(false);
        SityController.Instantiate.UpdateCountPeople();
        ManagerResources.Instantiate?.ClearStatistic();
        DayController.Instantiate.ReDrawDayCount();
        PanelStatsController.Instantiate?.Hide();
        SityController.Instantiate.UpdateInfoFactorys();

        UpdateResourcesUi(false);
    }

    public void NewGame()
    {
        SavedController.Instantiate.NewGame();
        StartGame();
    }

    public void UpdateResourcesUi(bool isUpdateArrow)
    {
        foreach (var element in resourceControllers)
        {
            element.UpdateValue(isUpdateArrow);
        }
    }

    public void GameOver()
    {
        gameOverPanel.GameOver();
    }
}