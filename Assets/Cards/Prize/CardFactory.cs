using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "CardsPrize/CardPrizeFactory", fileName = "CardPrizeFactory")]
public class CardFactory : CardPrize
{
    public Factory Factory;
    public Boost Boost;
    
    public override void Complete(ManagerResources managerResources, Localization localization)
    {
        Factory.AddBoost(Boost);
    }
}