using System;
using UnityEngine;

[Serializable]
public class CardPrize : ScriptableObject
{
    public int prizeCount;

    public virtual int GetPrizeCount()
    {
        return prizeCount;
    }
    
    public CardPrizeVector CardPrizeVector;

    public string Text;

    public string FieldName { get =>$"{this.GetInstanceID()}_{name}"; }

    public virtual void Complete(ManagerResources managerResources, Localization localization)
    {
    	
    }
}