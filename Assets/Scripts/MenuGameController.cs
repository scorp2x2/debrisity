using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class MenuGameController : MonoBehaviour
{
    public Button buttonContinue;
    public Transform humanPanel;
    public List<HumanSkin> HumanSkins;

    SavedController _savedController;

    // Start is called before the first frame update
    [Inject]
    void Construct(SavedController savedController)
    {
        _savedController = savedController;

        buttonContinue.interactable = !savedController.GameSaveData.IsNewGame;
        HumanSkins = Resources.LoadAll<HumanSkin>("HumanSkins").ToList();

        UpdateHumanSkins();
    }

    public void NewGame()
    {
        _savedController.NewGame();
    }

    public void UpdateHumanSkins()
    {
        humanPanel.ClearChilds();
        var h = Instantiate(HumanSkins.GetRandomElement().Prefab, humanPanel).GetComponent<HumanController>();
        h.enabled = false;
    }
}