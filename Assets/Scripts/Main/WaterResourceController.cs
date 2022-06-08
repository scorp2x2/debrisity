using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterResourceController : ResourceController
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
	public override void UpdateValue(bool isUpdateArrow)
	{
		SetValue(Resources.Water, Resources.MaxWater, isUpdateArrow);
	}
}
