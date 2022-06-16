using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class HumanSkinMagazin : MonoBehaviour
{
    public Transform panelSkin;
    public Text nameSkin;
    public Text priceText;
    public Button buy;
    public GameObject btBuy;
    public GameObject btSelected;
    public GameObject btUnSelected;
    public Button unSelect;

    public HumanSkin humanSkin;

    public void Load(HumanSkin humanSkin)
    {
        this.humanSkin = humanSkin;

        panelSkin.ClearChilds();
        var h = Instantiate(humanSkin.Prefab, panelSkin).GetComponent<HumanController>();
        h.enabled = false;

        LoadInfo();
    }

    public void LoadInfo()
    {
        nameSkin.text = humanSkin.Name;
        if (!humanSkin.HumanSkinData.IsBuy)
        {
            priceText.text = humanSkin.Price.ToString();
            btBuy.SetActive(true);
            buy.interactable = ManagerResources.Instantiate.diamonds.Count >= humanSkin.Price;
        }
        else
        {
            btBuy.SetActive(false);
            btSelected.SetActive(humanSkin.HumanSkinData.IsSelected);
            btUnSelected.SetActive(!humanSkin.HumanSkinData.IsSelected);
            unSelect.interactable = MagazinController.Instantiate.HumanSkins.Count(a => a.HumanSkinData.IsSelected) > 1;
        }
    }

    public void Buy()
    {
        if (ManagerResources.Instantiate.diamonds.Eat(humanSkin.Price))
        {
            humanSkin.HumanSkinData.IsBuy = true;
            MagazinController.Instantiate.UpdateInfoSkin();
            SavedController.Instantiate.SaveGame();
        }
    }

    public void Select()
    {
        if (!humanSkin.HumanSkinData.IsBuy) return;

        humanSkin.HumanSkinData.IsSelected = true;
        MagazinController.Instantiate.UpdateInfoSkin();
        SavedController.Instantiate.SaveGame();
    }

    public void UnSelect()
    {
        if (!humanSkin.HumanSkinData.IsBuy) return;

        humanSkin.HumanSkinData.IsSelected = false;
        MagazinController.Instantiate.UpdateInfoSkin();
        SavedController.Instantiate.SaveGame();
    }
}