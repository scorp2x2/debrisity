using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using Zenject;

public class PanelStatsController : MonoBehaviour
{
    SavedController _savedController;
    ManagerResources _managerResources;

    public GameObject panelStats;
    public TextMeshProUGUI textMeshProUgui;
    public TextMeshProUGUI textMeshProUgui2;

    [Inject]
    public void Construct(SavedController savedController, ManagerResources managerResources)
    {
        _savedController = savedController;
        _managerResources = managerResources;
    }

    public void Show()
    {
        _savedController.SaveGame();

        panelStats.SetActive(true);
        textMeshProUgui.text = "";
        textMeshProUgui2.text = "";

        foreach (var key in _managerResources.resourcesLogic.Keys)
        {
            string text = "";

            if (_managerResources.resourcesLogic[key].Count(a => a.count != 0) == 0) continue;
            string name = key.name;

            text += $"<B>{name}:</B> \n";
            var sum = 0;

            foreach (var item in _managerResources.resourcesLogic[key])
            {
                if (item.count != 0)
                    text +=
                        $"    <color={(item.vector ? "#458600" : "red")}><size=34>{item.message}: " +
                        $"<B>{(item.vector ? "+" : "-")}{item.count}</B></size></color>\n";
                sum += item.vector ? item.count : -item.count;
            }

            text += $"    <B><color={(sum >= 0 ? "#458600" : "red")}><size=36>Итого: " +
                    $"{(sum >= 0 ? "+" : "")}{sum}</B></size></color>\n";

            if (key == _managerResources.food || key == _managerResources.water)
                textMeshProUgui.text += text;
            else
                textMeshProUgui2.text += text;
        }
    }

    public void Hide()
    {
        if (panelStats != null)
            panelStats.SetActive(false);
    }

    public void End()
    {
        Hide();
        _managerResources.ClearStatistic();
        //DayController.Instantiate.EndDay();
    }
}