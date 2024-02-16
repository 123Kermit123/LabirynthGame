using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    public Vector3 Angle;
    void Start()
    {
        
    }

    void Update()
    {
        transform.Rotate(Angle);
    }
}
