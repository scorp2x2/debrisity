using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorageFactory : FactoryController
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
    	textLevelCapacity.text = $"Lvl: {Factorys.FactoryStorage.LevelEfficiency}\n+{Factorys.FactoryStorage.GetProduction()}";
    	textLevelEfficiency.text = $"Lvl: {Factorys.FactoryStorage.LevelCapacity}\nmax:{Factorys.FactoryStorage.GetMaxStorage()}";
    }
    
    public override void UpLevelCapacity()
    {
	    Factorys.FactoryStorage.UpLevelCapacity();
    	LoadInfo();
    }
    
    public override void SetLevelCapacity(int level)
    {
	    Factorys.FactoryStorage.SetLevelCapacity(level);
    	LoadInfo();
    }
    
    public override void UpLevelEfficiency()
    {
	    Factorys.FactoryStorage.UpLevelEfficiency();
    	LoadInfo();
    }
    
    public override void SetLevelEfficiency(int level)
    {
	    Factorys.FactoryStorage.SetLevelEfficiency(level);
    	LoadInfo();
    }
}
