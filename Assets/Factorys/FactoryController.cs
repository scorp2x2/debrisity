using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactoryController : MonoBehaviour
{
	public Text textLevelCapacity;
	public Text textLevelEfficiency;
    // Start is called before the first frame update
    void Start()
    {
    	//SetLevel(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public virtual void LoadInfo(){
    	
    }
    
    public virtual void UpLevelEfficiency(){
    	LoadInfo();
    }
    
    public virtual void SetLevelEfficiency(int newlevel){
    	LoadInfo();
    }
    
    public virtual void UpLevelCapacity(){
    	LoadInfo();
    }
    
    public virtual void SetLevelCapacity(int newlevel){
    	LoadInfo();
    }
    
    public virtual void Work(){
    }
}
