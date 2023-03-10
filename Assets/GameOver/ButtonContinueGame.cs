using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ButtonContinueGame : MonoBehaviour
{
    public Text textCountD;
    public GameObject panelD;
    public GameObject panelM;

    public int countReset = 1;

    ManagerResources _managerResources;

    [Inject]
    public void Construct(ManagerResources managerResources)
    {
        _managerResources = managerResources;
    }

    public void ReDraw()
    {
        panelD.SetActive(true);
        panelM.SetActive(false);
        var c = Mathf.RoundToInt(GameConstant.CountDiamondContinue *
                                 Mathf.Pow(GameConstant.CountUpDiamondFromResetCards, countReset - 1));
        textCountD.text = c.ToString();

        GetComponent<Button>().interactable = _managerResources.diamonds.Count >= c;
    }

    public void ButtonContinue()
    {
        var c = Mathf.RoundToInt(GameConstant.CountDiamondContinue *
                                 Mathf.Pow(GameConstant.CountUpDiamondFromResetCards, countReset - 1));
        if (_managerResources.diamonds.Eat(c))
        {
            countReset++;
            FindObjectOfType<GameOverPanel>()?.ButtonContinue();
        }
    }
}