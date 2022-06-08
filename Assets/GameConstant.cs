using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameConstant 
{
	public static int FactoryWaterEfficiency {get; private set;} = 3;
	public static int FactoryFoodEfficiency {get; private set;} = 3;
	
	public static int FactoryFoodCapacity {get; private set;} = 10;
	public static int FactoryWaterCapacity {get; private set;} = 10;
	public static int FactoryStorageCapacity {get; private set;} = 10;
	public static int FactoryBaracsCapacity {get; private set;} = 10;

	public static int GoldPriceFactoryWaterEfficiency {get; private set;} = 5;
	public static int GoldPriceFactoryFoodEfficiency {get; private set;} = 5;
	
	public static int GoldPriceFactoryFoodCapacity {get; private set;} = 4;
	public static int GoldPriceFactoryWaterCapacity {get; private set;} = 4;
	public static int GoldPriceFactoryStorageCapacity {get; private set;} = 4;
	public static int GoldPriceFactoryBaracsCapacity {get; private set;} = 4;
	
	public static int DebrisPriceFactoryWaterEfficiency {get; private set;} = 2;
	public static int DebrisPriceFactoryFoodEfficiency {get; private set;} = 2;
	
	public static int DebrisPriceFactoryFoodCapacity {get; private set;} = 1;
	public static int DebrisPriceFactoryWaterCapacity {get; private set;} = 1;
	public static int DebrisPriceFactoryStorageCapacity {get; private set;} = 1;
	public static int DebrisPriceFactoryBaracsCapacity {get; private set;} = 1;
	
	public static Vector2 DeadPeopleInRaidWater {get; private set;} = new Vector2(.6f, 1);
	public static Vector2 DeadPeopleInRaidFood {get; private set;} = new Vector2(.6f, 1);
	public static Vector2 DeadPeopleInRaidDebris {get; private set;} = new Vector2(.4f, .9f);
	
	public static Vector2 FindResInRaidWater {get; private set;} = new Vector2(.1f, .4f);
	public static Vector2 FindResInRaidFood {get; private set;} = new Vector2(.1f, .4f);
	public static Vector2 FindResInRaidDebris {get; private set;} = new Vector2(0, .3f);
	

	
}
