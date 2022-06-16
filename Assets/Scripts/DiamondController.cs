using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiamondController : MonoBehaviour
{
    public Text countDiamond;

    // Update is called once per frame
    void Update()
    {
        countDiamond.text = ManagerResources.Instantiate.diamonds.Count.ToString();
    }
}
