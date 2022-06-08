using System;
using UnityEngine;

[Serializable]
[CreateAssetMenu(menuName = "CardsPrize/CardPrizeProduction", fileName = "CardPrizeProduction")]
public class CardProduction : CardPrize
{
    public ProductionType ProductionType;

    public override void Complete()
    {
        if (CardPrizeVector == CardPrizeVector.Positive)
            Resources.AddResource(ProductionType, prizeCount);
        else
            Resources.EatResource(ProductionType, prizeCount);
    }
}