using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayController : MonoBehaviour
{
    public static DayController Instantiate;

    public Text dayText;

    // Start is called before the first frame update
    void Awake()
    {
        Instantiate = this;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ReDrawDayCount()
    {
        dayText.text = ManagerResources.Instantiate.days.Count.ToString();
    }

    public void NextDay()
    {
        PanelFarmController.Instantiate.Show();
            // PanelFactorysController.Instantiate.Show();
    }

    public void EndDay()
    {
        ManagerResources.Instantiate.AddDay();
        ////Resources.GenerateRandomValue();
        Debug.Log("CalcEconomicDay");
        ManagerResources.Instantiate.CalcEconomicDay();
        Debug.Log("WorkFactorys");
        SityController.Instantiate.WorkFactorys();

        Debug.Log("CalcPeople");
        ManagerResources.Instantiate.CalcPeople();

        Debug.Log("UpdateResourcesUI");
        GameController.Instantiate.UpdateResourcesUi(true);
        SityController.Instantiate.UpdateInfoFactorys();
        Debug.Log("UpdateCountPeople");
        SityController.Instantiate.UpdateCountPeople();
        ReDrawDayCount();

        PanelStatsController.Instantiate.Show();
    }
}