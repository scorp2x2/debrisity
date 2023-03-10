using System;

[Serializable]
public class HumanSkinData
{
    public bool IsBuy;
    public bool IsSelected;
    public string Name;

    internal void Load(HumanSkinData humanSkinData)
    {
        IsBuy = humanSkinData.IsBuy;
        IsSelected = humanSkinData.IsSelected;
    }
}