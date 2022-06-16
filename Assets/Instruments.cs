using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Instruments
{
    public static void ClearChilds(this Transform transform)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject.Destroy(transform.GetChild(i).gameObject);
        }
    }

    public static T GetRandomElement<T>(this List<T> elements)
    {
        return elements[Random.Range(0, elements.Count)];
    }

    public static float CalcMultiplay(int lvl, float mult, float start)
    {
        if (lvl == 1)
            return start;

        return CalcMultiplay(lvl - 1, mult, start) + start * Mathf.Pow(mult, lvl - 1);
    }
}