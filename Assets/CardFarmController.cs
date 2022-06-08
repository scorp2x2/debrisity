using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardFarmController : MonoBehaviour
{
	public Slider slider;
	public Text sliderTextValue;
	public Text textCount;
	public Text textMaxCount;
	
	public Text countReturnPeople;
	public Text countEfficiency;
	
	public Button buttonN100;
	public Button buttonN10;
	public Button buttonN5;
	public Button buttonP5;
	public Button buttonP10;
	public Button buttonP100;
	
	public ProductionType ProductionType;
	
	public int value;
	public int maxValue;
	
	public void UpdateValue(){
		
		maxValue=Resources.People-1;
		
		slider.maxValue=maxValue;
		textMaxCount.text=maxValue.ToString();
		value=Mathf.RoundToInt(maxValue*.25f);
    	slider.value=value;
    	UpdateEnableButton();
    	UpdateText();
	}
    
    public void UpdateEnableButton(){
    	//buttonN100.interactable =value-100 >0;
buttonN10.interactable = value-10 >0;
buttonN5.interactable = value-5 >0;
buttonP5.interactable = value+5 <=maxValue;
buttonP10.interactable = value+10 <=maxValue;
//buttonP100.interactable =value+100 <=maxValue;
    }
	
	public void UpdateText(){
		sliderTextValue.text=value.ToString();
		textCount.text=value.ToString();
		
		Vector2 peop =new Vector2();
		Vector2 res = new Vector2();
		Calc(ref peop,ref res);
		
		countReturnPeople.text=$"{Mathf.RoundToInt(peop.x)}-{Mathf.RoundToInt(peop.y)}";
	countEfficiency.text=$"{Mathf.RoundToInt(res.x)}-{Mathf.RoundToInt(res.y)}";
	}		
	
	public void Calc(ref Vector2 peop, ref Vector2 res){
		switch (ProductionType) {
			case ProductionType.Food:
				peop=new Vector2(value*GameConstant.DeadPeopleInRaidFood.x,value*GameConstant.DeadPeopleInRaidFood.y);
				res=new Vector2(value*GameConstant.FindResInRaidFood.x,value*GameConstant.FindResInRaidFood.y);
				break;
			case ProductionType.Water:
				peop=new Vector2(value*GameConstant.DeadPeopleInRaidWater.x,value*GameConstant.DeadPeopleInRaidWater.y);
				res=new Vector2(value*GameConstant.FindResInRaidWater.x,value*GameConstant.FindResInRaidWater.y);
				break;
			case ProductionType.Debris:
				peop=new Vector2(value*GameConstant.DeadPeopleInRaidDebris.x,value*GameConstant.DeadPeopleInRaidDebris.y);
				res=new Vector2(value*GameConstant.FindResInRaidDebris.x,value*GameConstant.FindResInRaidDebris.y);
				break;
			case ProductionType.Gold:
				
				break;
			case ProductionType.People:
				
				break;

		}
	}
    
    public void ButtonAddPeople(int count){
    	value+=count;
    	if(value<1)value=1;
    	if(value>maxValue) value=maxValue;
    	
    	slider.value=value;
    }
	
    public void UpdateSlider(){
		value=(int)slider.value;
		UpdateEnableButton();
    	UpdateText();
    }
	
	public void SendPeople(){
		
		Vector2 peop =new Vector2();
		Vector2 res =new Vector2();
		Calc(ref peop,ref res);
		
		var rPeople=Mathf.RoundToInt(Random.Range(peop.x, peop.y));
		var rRes=Mathf.RoundToInt(Random.Range(res.x, res.y));
		Resources.AddResource(ProductionType, rRes);
		Resources.KillPeople(value-rPeople);
		
		PanelFarmController.Instantiate.End();
	}
}
