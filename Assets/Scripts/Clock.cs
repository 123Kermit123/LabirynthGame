using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock : Pickup
{
    public int TimeToAdd = 5;
    public override void Picked()
    {
        GameManager.Instance.AddTime(TimeToAdd);

        base.Picked();
    }
}
