using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public virtual void Picked()
    {
        Debug.Log($"Picked: {gameObject.name}");
        Destroy(gameObject);
    }
}
