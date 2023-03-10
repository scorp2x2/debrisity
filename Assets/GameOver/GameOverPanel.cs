using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameOverPanel : MonoBehaviour
{
    public Text countDays;
    public GameObject panelDiamonds;
    public Text countPriseD;

    public ButtonContinueGame ButtonContinueGame;

    SavedController _savedController;
    ManagerResources _managerResources;
    GameController _gameController;

    [Inject]
    public void Construct(SavedController savedController, ManagerResources managerResources, GameController gameController, SignalBus signalBus)
    {
        _savedController = savedController;
        _managerResources = managerResources;
        _gameController = gameController;

        signalBus.Subscribe<GameOverSignal>(GameOver);
    }

    public void GameOver()
    {
        gameObject.SetActive(true);

        int count = _managerResources.days.Count;
        countDays.text = count.ToString();

        int d = count / GameConstant.CountDaysFromDiamond;
        if (d != 0)
        {
            countPriseD.text = d.ToString();
            panelDiamonds.SetActive(true);
            _managerResources.diamonds.Add(d);
        }
        else
            panelDiamonds.SetActive(false);

        ButtonContinueGame.ReDraw();
        //SavedController.Instantiate.NewGame();
    }

    public void ButtonNewGame()
    {
        var c = int.Parse(ButtonContinueGame.textCountD.text);
        if (c != 0) _managerResources.diamonds.Add(c);

        _gameController.NewGame();
    }

    public void ButtonContinue()
    {
        _managerResources.food.SetDefault();
        _managerResources.water.SetDefault();
        _managerResources.people.SetDefault();

        _gameController.StartGame();
        gameObject.SetActive(false);
    }

    public void ButtonMainMenu()
    {
        var c = int.Parse(ButtonContinueGame.textCountD.text);
        if (c != 0) _managerResources.diamonds.Add(c);

        _savedController.NewGame();
    }
}