using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ResourceController : MonoBehaviour
{
    public TextMeshProUGUI textValue;
    int value;
    public GameObject imageUp;
    public GameObject imageDown;
    public Image icon;

    public Production production;

    // Start is called before the first frame update
    void Start()
    {
        icon.sprite = production.Icon;
    }

    public void UpdateValue(bool isUpdateArrow)
    {
        var newValue = production.Count;
        var maxValue = production.MaxCount;
        DrawUpDown(newValue, isUpdateArrow);
        if (maxValue == Int32.MaxValue)
            textValue.text = $"{newValue.ToString()}";
        else
            textValue.text = $"{newValue.ToString()}<size=30><voffset=-0.2em>/{maxValue.ToString()}</voffset></size>";

        this.value = newValue;
    }

    void DrawUpDown(int newValue, bool isUpdateArrow)
    {
        if (value != newValue && isUpdateArrow)
        {
            var isUp = value < newValue;
            imageUp.SetActive(isUp);
            imageDown.SetActive(!isUp);
        }
        else
        {
            imageUp.SetActive(false);
            imageDown.SetActive(false);
        }
    }
}