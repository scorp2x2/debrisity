using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SityController : MonoBehaviour
{
    public static SityController Instantiate;
    public List<HumanSkin> HumanSkins;
    public GameObject panelPeoples;
    public List<HumanController> peoples;

    public List<FactoryController> factorys;

    void Awake()
    {
        Instantiate = this;

        factorys = FindObjectsOfType<FactoryController>().ToList();
        HumanSkins = Resources.LoadAll<HumanSkin>("HumanSkins").Where(a => a.HumanSkinData.IsSelected).ToList();
    }

    public void UpdateCountPeople()
    {
        var count = (int) Mathf.Round(ManagerResources.Instantiate.people.Count * Random.Range(.7f, 1.3f));
        count = Mathf.Min(count, GameConstant.MaxCountHumanInCity);
        if (count < peoples.Count)
        {
            var c = peoples.Count - count;
            for (int i = 0; i < c; i++)
            {
                if (peoples.Count != 0)
                {
                    peoples[0].Die();
                    peoples.RemoveAt(0);
                }
            }
        }

        if (count > peoples.Count)
        {
            var c = count - peoples.Count;
            for (int i = 0; i < c; i++)
            {
                SpawnPeople();
            }
        }
    }

    public void SpawnPeople()
    {
        var p = Instantiate(HumanSkins.GetRandomElement().Prefab, panelPeoples.transform)
            .GetComponent<HumanController>();
        peoples.Add(p);
    }

    public void WorkFactorys()
    {
        foreach (var element in factorys)
        {
            element.Work();
        }
    }

//    public void SetFactoryLevelEfficiency(int level = 1)
//    {
//        foreach (var element in factorys)
//        {
//            element.SetLevelEfficiency(level);
//        }
//    }
//
//    public void SetFactoryLevelCapacity(int level = 1)
//    {
//        foreach (var element in factorys)
//        {
//            element.SetLevelCapacity(level);
//        }
//    }

    public void UpdateInfoFactorys()
    {
        foreach (var element in factorys)
        {
            element.LoadInfo();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
}