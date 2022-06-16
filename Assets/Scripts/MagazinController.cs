using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MagazinController : MonoBehaviour
{
    public static MagazinController Instantiate;

    private void Awake()
    {
        Instantiate = this;
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
            var h = Instantiate(humanSkinMagazine, panelSkins).GetComponent<HumanSkinMagazin>();
            h.Load(item);
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
