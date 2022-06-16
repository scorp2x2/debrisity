using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MenuGameController : MonoBehaviour
{
    public Button buttonContinue;
    public Transform humanPanel;
    public List<HumanSkin> HumanSkins;

    // Start is called before the first frame update
    void Start()
    {
        buttonContinue.interactable = File.Exists(SavedController.Instantiate.pathSave);
        HumanSkins = Resources.LoadAll<HumanSkin>("HumanSkins").ToList();
        
        SavedController.Instantiate.LoadGame();
        UpdateHumanSkins();
    }

    public void UpdateHumanSkins()
    {
        humanPanel.ClearChilds();
        var h=Instantiate(HumanSkins.GetRandomElement().Prefab, humanPanel).GetComponent<HumanController>();
        h.enabled = false;
    }
    
    // Update is called once per frame
    void Update()
    {
    }
}