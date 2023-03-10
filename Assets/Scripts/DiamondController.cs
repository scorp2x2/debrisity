using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class DiamondController : MonoBehaviour
{
    public Text countDiamond;
    ManagerResources _managerResources;

    [Inject]
    public void Construct(ManagerResources managerResources)
    {
        _managerResources = managerResources;
    }

    // Update is called once per frame
    void Update()
    {
        countDiamond.text = _managerResources.diamonds.Count.ToString();
    }
}
