using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterFactory : FactoryController
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
    	textLevelCapacity.text = $"Lvl: {Factorys.FactoryWater.LevelEfficiency}\n+{Factorys.FactoryWater.GetProduction()}";
    	textLevelEfficiency.text = $"Lvl: {Factorys.FactoryWater.LevelCapacity}\nmax:{Factorys.FactoryWater.GetMaxStorage()}";
    }
    
    public override void Work()
    {
	    var count = Factorys.FactoryWater.GetProduction();
    	ManagerResources.Instantiate.WriteStatistic(ProductionType.Water, "Водокачка произвела", count);
    	Resources.AddResource(ProductionType.Water,count);
    }
    
    public override void UpLevelCapacity()
    {
	    Factorys.FactoryWater.UpLevelCapacity();
    LoadInfo();}
    
    public override void SetLevelCapacity(int level)
    {
	    Factorys.FactoryWater.SetLevelCapacity(level);
    LoadInfo();}
    
    public override void UpLevelEfficiency()
    {
	    Factorys.FactoryWater.UpLevelEfficiency();
    LoadInfo();}
    
    public override void SetLevelEfficiency(int level)
    {
	    Factorys.FactoryWater.SetLevelEfficiency(level);
    LoadInfo();}
}
