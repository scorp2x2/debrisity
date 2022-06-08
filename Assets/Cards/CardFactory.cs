using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "CardsPrize/CardPrizeFactory", fileName = "CardPrizeFactory")]
public class CardFactory : CardPrize
{
    public FactoryType FactoryType;
    public Boost Boost;
    
    public override void Complete()
    {
        switch (FactoryType)
        {
            case FactoryType.Food:
                Factorys.FactoryFood.AddBoost(Boost);
                break;
            case FactoryType.Water:
                Factorys.FactoryWater.AddBoost(Boost);
                break;
            case FactoryType.Debris:
                Factorys.FactoryStorage.AddBoost(Boost);
                break;
            case FactoryType.People:
                Factorys.FactoryBaracs.AddBoost(Boost);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}