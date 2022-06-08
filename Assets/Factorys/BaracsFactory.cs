using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaracsFactory : FactoryController
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
    	textLevelCapacity.text = $"Lvl: {Factorys.FactoryBaracs.LevelEfficiency}\n+{Factorys.FactoryBaracs.GetProduction()}";
    	textLevelEfficiency.text = $"Lvl: {Factorys.FactoryBaracs.LevelCapacity}\nmax:{Factorys.FactoryBaracs.GetMaxStorage()}";
    }
    
    public override void UpLevelCapacity()
	{
		Factorys.FactoryBaracs.UpLevelCapacity();
		LoadInfo();
	}
    
    public override void SetLevelCapacity(int level)
	{
		Factorys.FactoryBaracs.SetLevelCapacity(level);
		LoadInfo();
	}
    
    public override void UpLevelEfficiency()
    {
	    Factorys.FactoryBaracs.UpLevelEfficiency();
		LoadInfo();
    }
    
    public override void SetLevelEfficiency(int level)
    {
	    Factorys.FactoryBaracs.SetLevelEfficiency(level);
	    LoadInfo();
    }
}
