using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Zenject;

public class HumanSkinMagazin : MonoBehaviour, IPoolable<HumanSkin, SavedController, IMemoryPool>
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

    SavedController _savedController;
    ManagerResources _managerResources;
    MagazinController _magazinController;

    [Inject]
    public void Construct(SavedController savedController, ManagerResources managerResources, MagazinController magazinController)
    {
        _savedController = savedController;
        _managerResources = managerResources;
        _magazinController = magazinController;
    }

    public void LoadInfo()
    {
        nameSkin.text = humanSkin.Name;
        if (!humanSkin.HumanSkinData.IsBuy)
        {
            priceText.text = humanSkin.Price.ToString();
            btBuy.SetActive(true);
            buy.interactable = _managerResources.diamonds.Count >= humanSkin.Price;
        }
        else
        {
            btBuy.SetActive(false);
            btSelected.SetActive(humanSkin.HumanSkinData.IsSelected);
            btUnSelected.SetActive(!humanSkin.HumanSkinData.IsSelected);
            unSelect.interactable = _magazinController.HumanSkins.Count(a => a.HumanSkinData.IsSelected) > 1;
        }
    }

    public void Buy()
    {
        if (_managerResources.diamonds.Eat(humanSkin.Price))
        {
            humanSkin.HumanSkinData.IsBuy = true;
            _magazinController.UpdateInfoSkin();
            _savedController.PlayerSave();
        }
    }

    public void Select()
    {
        if (!humanSkin.HumanSkinData.IsBuy) return;

        humanSkin.HumanSkinData.IsSelected = true;
        _magazinController.UpdateInfoSkin();
        _savedController.PlayerSave();
    }

    public void UnSelect()
    {
        if (!humanSkin.HumanSkinData.IsBuy) return;

        humanSkin.HumanSkinData.IsSelected = false;
        _magazinController.UpdateInfoSkin();
        _savedController.PlayerSave();
    }

    public void OnDespawned()
    {

    }

    public void OnSpawned(HumanSkin p1, SavedController p2, IMemoryPool p3)
    {
        this.humanSkin = p1;
        _savedController = p2;

        panelSkin.ClearChilds();
        var h = Instantiate(humanSkin.Prefab, panelSkin).GetComponent<HumanController>();
        h.enabled = false;

        LoadInfo();
    }

    public class Factory : PlaceholderFactory<HumanSkin, SavedController, HumanSkinMagazin>
    {

    }
}