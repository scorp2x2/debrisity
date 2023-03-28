using System.Collections;
using System.Linq;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using Zenject;

public class SityController : MonoBehaviour
{
    public List<HumanSkin> HumanSkins;
    public GameObject panelPeoples;
    public List<HumanController> peoples;

    public List<FactoryController> factorys;

    ManagerResources _managerResources;
    HumanController.Factory _humanFactory;
    DiContainer _container;

    [Inject]
    public void Construct(ManagerResources managerResources, HumanController.Factory humanFactory, DiContainer container)
    {
        _container = container;
        _humanFactory = humanFactory;
        _managerResources = managerResources;
    }

    void Awake()
    {
        factorys = FindObjectsOfType<FactoryController>().ToList();
        HumanSkins = Resources.LoadAll<HumanSkin>("HumanSkins").Where(a => a.HumanSkinData.IsSelected).ToList();
    }

    public void UpdateCountPeople()
    {
        var count = (int) Mathf.Round(_managerResources.people.Count * Random.Range(.7f, 1.3f));
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
        var p = _container.InstantiatePrefab((UnityEngine.Object)HumanSkins.GetRandomElement().Prefab, panelPeoples.transform).GetComponent<HumanController>();

        peoples.Add(p);
    }

    public void WorkFactorys()
    {
        foreach (var element in factorys)
        {
            element.Work(_managerResources);
        }
    }

    public void UpdateInfoFactorys()
    {
        foreach (var element in factorys)
        {
            element.LoadInfo();
        }
    }
}