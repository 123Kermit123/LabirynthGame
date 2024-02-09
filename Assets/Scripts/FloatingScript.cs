using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingScript : MonoBehaviour
{
    public float floatingHeight = 0.5f;

    private int count = 0;
    private const int STEPS = 25;
    private bool up = true;

    public void FixedUpdate()
    {
        Vector3 move;

        if (up)
        {
            move = new Vector3(0, floatingHeight / STEPS);
        }
        else
        {
            move = new Vector3(0, -floatingHeight / STEPS);
        }

        transform.position += move;
        count++;

        if (count >= STEPS)
        {
            count = 0;
            up = !up;
        }
    }
}
