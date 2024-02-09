using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : Pickup
{
    public int Points = 5;

    public override void Picked()
    {
        GameManager.Instance.AddPoints(Points);

        base.Picked();
    }
}
