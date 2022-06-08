using System.Collections;

public static class Factorys
{
	public static Factory FactoryWater { get; private set; } = new Factory(FactoryType.Water);
	public static Factory FactoryFood {get; private set;}= new Factory(FactoryType.Food);
	public static Factory FactoryStorage {get; private set;}= new Factory(FactoryType.Debris);
	public static Factory FactoryBaracs {get; private set;}= new Factory(FactoryType.People);
	
//	public static void UpLevel(FactoryType factoryType){
//		 switch (factoryType)
//        {
//            case FactoryType.Food:
//		 			Foodlevel++;
//                break;
//            case FactoryType.Water:
//		 			Waterlevel++;
//                break;
//            case FactoryType.Debris:
//		 			Storagelevel++;
//                break;
//            case FactoryType.People:
//		 			Baracslevel++;
//                break;
//        }
//	}
//	
//	public static void Setlevel(FactoryType factoryType, int level){
//		 switch (factoryType)
//        {
//            case FactoryType.Food:
//		 			Foodlevel=level;
//                break;
//            case FactoryType.Water:
//		 			Waterlevel=level;
//                break;
//            case FactoryType.Debris:
//		 			Storagelevel=level;
//                break;
//            case FactoryType.People:
//		 			Baracslevel=level;
//                break;
//        }
//	}
}