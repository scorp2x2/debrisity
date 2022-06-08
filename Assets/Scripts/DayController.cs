using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayController : MonoBehaviour
{
	public static DayController Instantiate;
	
	public Text dayText;
	
    // Start is called before the first frame update
    void Start()
    {
        Instantiate=this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void ReDrawDayCount(){
    	dayText.text= Resources.Day.ToString();
    }
    
    public void NextDay(){
	    PanelFarmController.Instantiate.Show();
    }
    
    public void EndDay(){
    	Resources.AddDay();
    	////Resources.GenerateRandomValue();
    	Debug.Log("CalcEconomicDay");
    	ManagerResources.Instantiate.CalcEconomicDay();
        Debug.Log("WorkFactorys");
    	SityController.Instantiate.WorkFactorys();
    	
        Debug.Log("CalcPeople");
        ManagerResources.Instantiate.CalcPeople();

        Debug.Log("UpdateResourcesUI");
    	GameController.Instantiate.UpdateResourcesUI(true);
    	SityController.Instantiate.UpdateInfoFactorys();
        Debug.Log("UpdateCountPeople");
		SityController.Instantiate.UpdateCountPeople();
    	ReDrawDayCount();
    }
}
