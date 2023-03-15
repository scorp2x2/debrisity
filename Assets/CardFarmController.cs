using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class CardFarmController : MonoBehaviour
{
    public Slider slider;
    public Text sliderTextValue;
    public Text textCount;
    public Text textMaxCount;

    public Text countReturnPeople;
    public Text countEfficiency;

    public Button buttonN100;
    public Button buttonN10;
    public Button buttonN5;
    public Button button05;
    public Button buttonP5;
    public Button buttonP10;
    public Button buttonP100;

    public Production production;

    public int value;
    public int maxValue;

    ManagerResources _managerResources;
    PanelFarmController _panelFarmController;

    [Inject]
    public void Construct(ManagerResources managerResources, PanelFarmController panelFarmController)
    {
        _managerResources = managerResources;
        _panelFarmController = panelFarmController;
    }

    public void UpdateValue()
    {
        maxValue = _managerResources.people.Count / 2;

        slider.maxValue = maxValue;
        textMaxCount.text = maxValue.ToString();
        value = Mathf.RoundToInt(maxValue * .25f);
        slider.value = value;
        UpdateEnableButton();
        UpdateText();
    }

    public void UpdateEnableButton()
    {
        buttonN10.interactable = value - 10 > 0;
        buttonN5.interactable = value - 5 > 0;
        buttonP5.interactable = value + 5 <= maxValue;
        buttonP10.interactable = value + 10 <= maxValue;
    }

    public void UpdateText()
    {
        sliderTextValue.text = value.ToString();
        textCount.text = value.ToString();

        Vector2 peop = new Vector2();
        Vector2 res = new Vector2();
        Calc(ref peop, ref res);

        countReturnPeople.text = $"{Mathf.RoundToInt(peop.x)}-{Mathf.RoundToInt(peop.y)}";
        countEfficiency.text = $"{Mathf.RoundToInt(res.x)}-{Mathf.RoundToInt(res.y)}";
    }

    public void Calc(ref Vector2 peop, ref Vector2 res)
    {
        peop = new Vector2(value * production.DeadPeopleInRaid.x,
            value * production.DeadPeopleInRaid.y);
        res = new Vector2(value * production.FindResInRaid.x, value * production.FindResInRaid.y);
    }

    public void Button05People()
    {
        slider.value = Mathf.CeilToInt(((float)maxValue) / 2);
    }

    public void ButtonAddPeople(int count)
    {
        value += count;
        if (value < 1) value = 1;
        if (value > maxValue) value = maxValue;

        slider.value = value;
    }

    public void UpdateSlider()
    {
        value = (int)slider.value;
        UpdateEnableButton();
        UpdateText();
    }

    public void SendPeople()
    {
        Vector2 peop = new Vector2();
        Vector2 res = new Vector2();
        Calc(ref peop, ref res);

        var rPeople = Mathf.RoundToInt(Random.Range(peop.x, peop.y));
        var rRes = Mathf.RoundToInt(Random.Range(res.x, res.y));
        production.Add(rRes);
        _managerResources.KillPeople(value - rPeople);

        _managerResources.WriteStatistic(production, "Добыто в походе", rRes);
        if (value - rPeople > 0)
            _managerResources.WriteStatistic(_managerResources.people, "Погибло в походе", value - rPeople, false);

        _panelFarmController.End();
    }
}