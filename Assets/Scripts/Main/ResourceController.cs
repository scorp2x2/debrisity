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

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public virtual void UpdateValue(bool isUpdateArrow)
    {
    }

    protected void DrawUpDown(int newValue, bool isUpdateArrow)
    {
        if (value != newValue && isUpdateArrow)
        {
            bool isUp = value < newValue;
            imageUp.SetActive(isUp);
            imageDown.SetActive(!isUp);
        }
        else
        {
            imageUp.SetActive(false);
            imageDown.SetActive(false);
        }
    }

    protected void SetValue(int value, int maxValue, bool isUpdateArrow)
    {
        DrawUpDown(value, isUpdateArrow);
        this.value = value;
        if (maxValue == -1)
            textValue.text = string.Format("{0}<size=25><voffset=-0.2em>", value.ToString());
        else
            textValue.text = string.Format("{0}<size=25><voffset=-0.2em>/{1}</voffset></size>", value.ToString(),
                maxValue.ToString());
    }
}