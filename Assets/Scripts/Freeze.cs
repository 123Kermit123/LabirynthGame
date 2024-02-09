using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freeze : Pickup
{
    public int FreezeTimeCooldown = 14;
    public override void Picked()
    {
        GameManager.Instance.FreezeTime(FreezeTimeCooldown);

        base.Picked();
    }
}
