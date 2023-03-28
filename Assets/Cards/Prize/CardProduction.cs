using System;
using UnityEngine;
using Zenject;

[Serializable]
[CreateAssetMenu(menuName = "CardsPrize/CardPrizeProduction", fileName = "CardPrizeProduction")]
public class CardProduction : CardPrize
{
    public bool isMultiply;
    public float prizeMultiply;
    public Vector2 rangeMultiply = new Vector2(-1, -1);
    public Production productionMultiply;

    public Production production;

    public override void Complete(ManagerResources managerResources, Localization localization)
    {
        var p = GetPrizeCount();
        if (CardPrizeVector == CardPrizeVector.Positive)
        {
            production.Add(p);
            managerResources.WriteStatistic(production, localization.GetText("event_reward"), p);
        }
        else
        {
            production.Eat(p);
            managerResources.WriteStatistic(production, localization.GetText("event_costs"), p, false);
        }
    }

    public override int GetPrizeCount()
    {
        if (!isMultiply)
            return prizeCount;

        float prize = productionMultiply.Count * prizeMultiply;
        if (rangeMultiply.y != -1)
            prize = Mathf.Min(rangeMultiply.y, prize);
        if (rangeMultiply.x != -1)
            prize = Mathf.Max(rangeMultiply.x, prize);

        return Mathf.RoundToInt(prize);
    }
}