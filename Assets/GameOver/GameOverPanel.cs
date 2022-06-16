using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverPanel : MonoBehaviour
{
    public Text countDays;
    public GameObject panelDiamonds;
    public Text countPriseD;

    public ButtonContinueGame ButtonContinueGame;

    
    public void GameOver()
    {
        gameObject.SetActive(true);

        int count = ManagerResources.Instantiate.days.Count;
        countDays.text = count.ToString();

        int d = count / GameConstant.CountDaysFromDiamond;
        if (d != 0)
        {
            countPriseD.text = d.ToString();
            panelDiamonds.SetActive(true);
            ManagerResources.Instantiate.diamonds.Add(d);
        }
        else
            panelDiamonds.SetActive(false);

        ButtonContinueGame.ReDraw();
        //SavedController.Instantiate.NewGame();
    }

    public void ButtonNewGame()
    {
        var c=int.Parse(ButtonContinueGame.textCountD.text);
        if (c != 0) ManagerResources.Instantiate.diamonds.Add(c);
        
        GameController.Instantiate.NewGame();
    }

    public void ButtonContinue()
    {
        ManagerResources.Instantiate.food.SetDefault();
        ManagerResources.Instantiate.water.SetDefault();
        ManagerResources.Instantiate.people.SetDefault();

        GameController.Instantiate.StartGame();
        gameObject.SetActive(false);
    }

    public void ButtonMainMenu()
    {
        var c=int.Parse(ButtonContinueGame.textCountD.text);
        if (c != 0) ManagerResources.Instantiate.diamonds.Add(c);
        
        SavedController.Instantiate.NewGame();
    }
}