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
    
    public virtual void Complete(){
    	
    }
}