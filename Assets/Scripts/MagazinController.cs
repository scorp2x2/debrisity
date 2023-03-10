using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Zenject;

public class MagazinController : MonoBehaviour
{

    HumanSkinMagazin.Factory _skinFactory;
    SavedController _savedController;

    [Inject]
    public void Construct(SavedController saveController, HumanSkinMagazin.Factory skinFactory)
    {
        _savedController = saveController;
        _skinFactory = skinFactory;
    }

    public Transform panelSkins;
    public GameObject humanSkinMagazine;
    public List<HumanSkin> HumanSkins;
    
    
    private void Start()
    {
        HumanSkins = Resources.LoadAll<HumanSkin>("HumanSkins").ToList();
        LoadSkins();
    }

    void LoadSkins()
    {
        panelSkins.ClearChilds();
        foreach (var item in HumanSkins)
        {
            var skin = _skinFactory.Create(item, _savedController).transform;
            skin.transform.SetParent(panelSkins);
            skin.transform.localScale = Vector3.one;
            skin.transform.localPosition = Vector3.one;
            //var h = Instantiate(humanSkinMagazine, panelSkins).GetComponent<HumanSkinMagazin>();
            //h.Load(item);
        }
    }

    public void UpdateInfoSkin()
    {
        for (int i = 0; i < panelSkins.childCount; i++)
        {
            var h = panelSkins.GetChild(i).GetComponent<HumanSkinMagazin>();
            h.LoadInfo();
        }
    }
}
