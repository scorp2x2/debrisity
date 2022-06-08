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

        Resources.SetStart();
        SityController.Instantiate.UpdateCountPeople();
        SityController.Instantiate.SetFactoryLevelEfficiency();
        SityController.Instantiate.SetFactoryLevelCapacity();

        UpdateResourcesUI(false);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void UpdateResourcesUI(bool isUpdateArrow)
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