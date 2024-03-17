using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum KeyColor
{
    RedKey, GreenKey, BlueKey
}
public class Key : Pickup
{
    public KeyColor ColorKey;

    private void Start()
    {
        if (ColorKey == KeyColor.RedKey)
        GetComponentInChildren<MeshRenderer>().material.color = Color.red;
        else if (ColorKey == KeyColor.GreenKey)
            GetComponentInChildren<MeshRenderer>().material.color = Color.green;
        else
            GetComponentInChildren<MeshRenderer>().material.color = Color.blue;

    }
    public override void Picked()
    {
        GameManager.Instance.AddKey(ColorKey);

        base.Picked();
    }
}
