using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerResources : MonoBehaviour
{
    public static ManagerResources Instantiate;

    public Dictionary<ProductionType, List<StatisticResourceElement>> resourcesLogic;
    
    void Awake()
    {
        Instantiate = this;
    }

    // Start is called before the first frame update
    void Start()
    {
    	resourcesLogic=new Dictionary<ProductionType, List<StatisticResourceElement>>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    //Один человек пьёт примерно 0.3-0.4 воды в день
    //Один человек ест примерно 0.3-0.4 еды в день

    public void CalcEconomicDay()
    {
        var countP = Resources.People;
        var drinkWater = CalcEat();
        var eatFood = CalcEat();
        var addGold = (int) Mathf.Round(countP * Random.Range(.1f, .2f));
        var addDebris = (int) Mathf.Round(countP * Random.Range(0, .1f));

        Resources.EatResource(ProductionType.Food, eatFood);
        WriteStatistic(ProductionType.Food, "Затраты за день", eatFood, false);
        Resources.EatResource(ProductionType.Water, drinkWater);
        WriteStatistic(ProductionType.Water,  "Затраты за день",drinkWater, false);
        Resources.AddResource(ProductionType.Gold, addGold);
        WriteStatistic(ProductionType.Gold, "Заработок за день",addGold);
        Resources.AddResource(ProductionType.Debris, addDebris);
        WriteStatistic(ProductionType.Debris, "Заработок за день",addDebris);
    }

    public int CalcEat()
    {
        var count = Mathf.Round(Resources.People * Random.Range(.3f, .4f));
        if (Resources.People > Resources.MaxPeople)
            count += Mathf.Round(Resources.MaxPeople - Resources.People * Random.Range(.3f, .4f)) *
                     (1 - Resources.People / Resources.MaxPeople);
        return (int) count;
    }

    public void CalcPeople()
    {
        var food = Resources.Food;
        var water = Resources.Water;
        var people = Resources.People;
        var days = Resources.Day;
        var deadPeople = 0;
        var livePeople = 0;

        if (food < 0)
        {
            var dfp = Mathf.Abs(food * Random.Range(.3f, .4f));
            if (dfp < 1)
                deadPeople++;
            else
                deadPeople += (int) Mathf.Round(dfp);
        }

        if (water < 0)
        {
            var dwp = Mathf.Abs(food * Random.Range(.3f, .4f));
            if (dwp < 1)
                deadPeople++;
            else
                deadPeople += (int) Mathf.Round(dwp);
        }

        if (deadPeople == 0)
        {
            if (Random.Range(0, 4) == 1)
                livePeople += Mathf.RoundToInt((days % 3 == 0 ? people / 2 : 1) * Random.Range(0.5f, 1.5f));
        }

        Resources.KillPeople(deadPeople);
        if(deadPeople!=0) ManagerResources.Instantiate.WriteStatistic(ProductionType.People, "Умерло от голода", deadPeople, false);
        Resources.AddResource(ProductionType.People, livePeople);
        if(livePeople!=0) ManagerResources.Instantiate.WriteStatistic(ProductionType.People, "Родилось", livePeople);
    }
    
    public void WriteStatistic(ProductionType productionType, string message, int count, bool vector=true){
    	if(!resourcesLogic.ContainsKey(productionType))
    		resourcesLogic.Add(productionType, new List<StatisticResourceElement>());
    	
    	resourcesLogic[productionType].Add(new StatisticResourceElement(message, count, vector));
    }
    
    public void CleatStatistic(){
    	resourcesLogic.Clear();
    }
    
    public class StatisticResourceElement{
    	public string message;
    	public bool vector;
    	public int count;
    	
    	public StatisticResourceElement(string message, int count, bool vector=true){
    		this.message = message;
 			this.vector=vector;
			this.count=count;
    	}
    }
}