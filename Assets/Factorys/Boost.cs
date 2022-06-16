using System;
using UnityEngine;

[Serializable]
public class Boost
{
    [SerializeField] private int _duration;

    public int Duration
    {
        get => _duration;
        private set => _duration = value;
    }

    [SerializeField] private float _increase;

    public float Increase
    {
        get => _increase;
        private set => _increase = value;
    }

    public Boost(int duration, float increase)
    {
        Duration = duration;
        Increase = increase;
    }

    public bool CheckBoost()
    {
        Duration--;
        return Duration > 0;
    }
}