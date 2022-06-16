using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonContinueGame : MonoBehaviour
{
    public Text textCountD;
    public GameObject panelD;
    public GameObject panelM;

    public int countReset = 1;


    public void ReDraw()
    {
        panelD.SetActive(true);
        panelM.SetActive(false);
        var c = Mathf.RoundToInt(GameConstant.CountDiamondContinue *
                                 Mathf.Pow(GameConstant.CountUpDiamondFromResetCards, countReset - 1));
        textCountD.text = c.ToString();

        GetComponent<Button>().interactable = ManagerResources.Instantiate.diamonds.Count >= c;
    }

    public void ButtonContinue()
    {
        var c = Mathf.RoundToInt(GameConstant.CountDiamondContinue *
                                 Mathf.Pow(GameConstant.CountUpDiamondFromResetCards, countReset - 1));
        if (ManagerResources.Instantiate.diamonds.Eat(c))
        {
            countReset++;
            FindObjectOfType<GameOverPanel>()?.ButtonContinue();
        }
    }
}