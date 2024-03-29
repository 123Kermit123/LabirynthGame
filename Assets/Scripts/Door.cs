using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Transform ClosePosition;
    public Transform OpenPosition;

    public Transform door;

    public bool Open;

    public float speed;

    private void Update()
    {
        if (Open && Vector3.Distance(door.position, OpenPosition.position) > 0.01f)
        {
            door.position = Vector3.MoveTowards(door.position, OpenPosition.position, speed * Time.deltaTime);
        }
    }

    public void OpenDoor()
    {
        Open = true;
    }

    private void Start()
    {
        door.position = ClosePosition.position;
    }
}
