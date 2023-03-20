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
    public Transform PanelLanguages;

    SavedController _savedController;
    Localization _localization;

    // Start is called before the first frame update
    [Inject]
    void Construct(SavedController savedController, Localization localization)
    {
        _savedController = savedController;
        _localization = localization;

        buttonContinue.interactable = !savedController.GameSaveData.IsNewGame;
        HumanSkins = Resources.LoadAll<HumanSkin>("HumanSkins").ToList();

        UpdateHumanSkins();
        DrawFlagsLanguages();
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

    public void ButtonChangeLanguage(string language)
    {
        _localization.ChangeLanguage(language);
        DrawFlagsLanguages();
    }

    void DrawFlagsLanguages()
    {
        for (int i = 0; i < PanelLanguages.childCount; i++)
        {
            var flag = PanelLanguages.GetChild(i);
            if (flag.name == _savedController.PlayerSaveData.Language)
                flag.GetComponent<Image>().enabled = true;
            else
                flag.GetComponent<Image>().enabled = false;
        }
    }
}