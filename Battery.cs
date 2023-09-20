using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battery 
{
    public float MaxCapacity { get; private set; }
    public float CurrentCapacity { get; private set; }

    public Battery(float maxCapacity)
    {
        MaxCapacity = maxCapacity;
        CurrentCapacity = maxCapacity; 
    }

    public void Consume(float amount)
    {
        CurrentCapacity -= amount;
        CurrentCapacity = Mathf.Clamp(CurrentCapacity, 0f, MaxCapacity);
    }

    public void Recharge(float amount)
    {
        CurrentCapacity += amount;
        CurrentCapacity = Mathf.Clamp(CurrentCapacity, 0f, MaxCapacity);
    }
}
