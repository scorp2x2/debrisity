using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class PanelStatsController : MonoBehaviour
{
    public static PanelStatsController Instantiate;

    void Awake()
    {
        Instantiate = this;
    }

    public GameObject panelStats;
    public TextMeshProUGUI textMeshProUgui;
    public TextMeshProUGUI textMeshProUgui2;

    public void Show()
    {
        SavedController.Instantiate.SaveGame();

        panelStats.SetActive(true);
        textMeshProUgui.text = "";
        textMeshProUgui2.text = "";

        foreach (var key in ManagerResources.Instantiate.resourcesLogic.Keys)
        {
            string text = "";

            if (ManagerResources.Instantiate.resourcesLogic[key].Count(a => a.count != 0) == 0) continue;
            string name = key.name;

            text += $"<B>{name}:</B> \n";
            var sum = 0;

            foreach (var item in ManagerResources.Instantiate.resourcesLogic[key])
            {
                if (item.count != 0)
                    text +=
                        $"    <color={(item.vector ? "#458600" : "red")}><size=34>{item.message}: " +
                        $"<B>{(item.vector ? "+" : "-")}{item.count}</B></size></color>\n";
                sum += item.vector ? item.count : -item.count;
            }

            text += $"    <B><color={(sum >= 0 ? "#458600" : "red")}><size=36>Итого: " +
                    $"{(sum >= 0 ? "+" : "")}{sum}</B></size></color>\n";

            if (key == ManagerResources.Instantiate.food || key == ManagerResources.Instantiate.water)
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
        ManagerResources.Instantiate.ClearStatistic();
        //DayController.Instantiate.EndDay();
    }
}