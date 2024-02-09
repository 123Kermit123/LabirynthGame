using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] float RotateValue;
    void Update()
    {
        transform.Rotate(0, RotateValue * Time.deltaTime, 0);
    }

    public virtual void Picked()
    {
        Debug.Log("Bazowa: Picked");
        Destroy(gameObject);
    }
}
