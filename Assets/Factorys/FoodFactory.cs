using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodFactory : FactoryController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public override void LoadInfo(){
    	textLevelCapacity.text = $"Lvl: {Factorys.FactoryFood.LevelEfficiency}\n+{Factorys.FactoryFood.GetProduction()}";
    	textLevelEfficiency.text = $"Lvl: {Factorys.FactoryFood.LevelCapacity}\nmax:{Factorys.FactoryFood.GetMaxStorage()}";
    }
    
    public override void Work()
    {
	    var count = Factorys.FactoryFood.GetProduction();
    	
    	Resources.AddResource(ProductionType.Food, count);
    	ManagerResources.Instantiate.WriteStatistic(ProductionType.Food, "Cтоловая произвела", count);
    }
    
    public override void UpLevelCapacity()
    {
	    Factorys.FactoryFood.UpLevelCapacity();
    	LoadInfo();
    }
    
    public override void SetLevelCapacity(int level)
    {
	    Factorys.FactoryFood.SetLevelCapacity(level);
    	LoadInfo();
    }
    
    public override void UpLevelEfficiency()
    {
	    Factorys.FactoryFood.UpLevelEfficiency();
    	LoadInfo();
    }
    
    public override void SetLevelEfficiency(int level)
    {
	    Factorys.FactoryFood.SetLevelEfficiency(level);
    	LoadInfo();
    }
}
