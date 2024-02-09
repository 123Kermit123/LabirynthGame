using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    [SerializeField] float RotateValue;
    void FixedUpdate()
    {
        Vector3 Angle = new Vector3(0f, 0f,RotateValue * Time.fixedDeltaTime);
        transform.Rotate(Angle);
    }

    public virtual void Picked()
    {
        Debug.Log("Bazowa: Picked");
        Destroy(gameObject);
    }
}
