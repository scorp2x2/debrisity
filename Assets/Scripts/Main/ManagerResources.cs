using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ManagerResources : MonoBehaviour
{
    public Dictionary<Production, List<StatisticResourceElement>> resourcesLogic;

    public Production water;
    public Production food;
    public Production debris;
    public Production gold;
    public Production people;
    public Production days;
    public Production diamonds;

    SignalBus _signalBus;
    Localization _localization;
    [Inject]
    ManagerFactorys _managerFactorys;

    [Inject]
    public void Construct(SignalBus signalBus, Localization localization)
    {
        _signalBus = signalBus;
        _localization = localization;
        resourcesLogic = new Dictionary<Production, List<StatisticResourceElement>>();
    }

    public void SetDefault()
    {
        water.SetDefault();
        food.SetDefault();
        debris.SetDefault();
        gold.SetDefault();
        people.SetDefault();
        days.SetDefault();
    }

    //Один человек пьёт примерно 0.3-0.4 воды в день
    //Один человек ест примерно 0.3-0.4 еды в день
    public void CalcEconomicDay()
    {
        var countP = people.Count;
        var drinkWater = CalcEat();
        var eatFood = CalcEat();
        var addGold = Mathf.RoundToInt(countP * _managerFactorys.gold.GetProduction() / 10f);
        var addDebris = Mathf.RoundToInt(countP * _managerFactorys.debris.GetProduction() / 10f);

        food.Eat(eatFood);
        WriteStatistic(food, _localization.GetText("cost_per_day"), eatFood, false);
        water.Eat(drinkWater);
        WriteStatistic(water, _localization.GetText("cost_per_day"), drinkWater, false);
        gold.Add(addGold);
        WriteStatistic(gold, _localization.GetText("earnings_per_day"), addGold);
        debris.Add(addDebris);
        WriteStatistic(debris, _localization.GetText("earnings_per_day"), addDebris);
    }

    public int CalcEat()
    {
        var count = Mathf.Round(people.Count * Random.Range(GameConstant.CountEatPeople.x, GameConstant.CountEatPeople.y));
        if (people.Count > people.MaxCount)
            count += Mathf.Round(people.MaxCount - people.Count * Random.Range(.3f, .4f)) *
                     (1 - people.Count / people.MaxCount);
        return (int) count;
    }

    public void CalcPeople()
    {
        var food = this.food.Count;
        var water = this.water.Count;
        var people = this.people.Count;
        var days = this.days;
        var deadPeople = 0;
        var livePeople = 0;

        if (food < 0)
        {
            var dfp = Mathf.Abs(food * Random.Range(GameConstant.CountEatPeople.x, GameConstant.CountEatPeople.y));
            if (dfp < 1)
                deadPeople++;
            else
                deadPeople += (int) Mathf.Round(dfp);
        }

        if (water < 0)
        {
            var dwp = Mathf.Abs(water * Random.Range(GameConstant.CountEatPeople.x, GameConstant.CountEatPeople.y));
            if (dwp < 1)
                deadPeople++;
            else
                deadPeople += (int) Mathf.Round(dwp);
        }

        if (deadPeople == 0)
        {
            if (days.Count % 9 == 0)
            {
                int c = Mathf.RoundToInt(people * Random.Range(0.4f, 1.2f));
                livePeople += c;
            }
            else if (Random.Range(0, 1f) <= GameConstant.ProcentNewPeople)
            {
                int c = Mathf.RoundToInt(((float)people / 2) * Random.Range(0.5f, 1.5f));
                livePeople += Mathf.RoundToInt(c + c * (days.Count / GameConstant.UpNewPeople));
            }

            var increase = _managerFactorys.people.GetIncrease();
            if (increase != 0)
                livePeople = Mathf.RoundToInt(livePeople * increase);
        }
            
        KillPeople(deadPeople);
        if (deadPeople != 0)
            WriteStatistic(this.people, _localization.GetText("died_of_hunger"), deadPeople, false);
        this.people.Add(livePeople);
        if (livePeople != 0)
            WriteStatistic(this.people, _localization.GetText("born_people"), livePeople);
    }

    public void KillPeople(int count)
    {
        Debug.Log("Kill people: " + count);

        people.Eat(count);
        if (people.Count <= 0)
        {
            _signalBus.Fire<GameOverSignal>();
        }
    }

    public void WriteStatistic(Production production, string message, int count, bool vector = true)
    {
        if (!resourcesLogic.ContainsKey(production))
            resourcesLogic.Add(production, new List<StatisticResourceElement>());

        resourcesLogic[production].Add(new StatisticResourceElement(message, count, vector));
    }

    public void ClearStatistic()
    {
        resourcesLogic?.Clear();
    }

    public void AddDay()
    {
        days.Add(1);
    }
}