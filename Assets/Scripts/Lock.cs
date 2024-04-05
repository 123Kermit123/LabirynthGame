using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public List<Door> doors;
    public KeyColor myColor;
    bool iCanOpen = false;
    bool locked = false;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && iCanOpen == true && locked)
        {
            animator.SetBool("Open", true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            iCanOpen = true;
            print("Mo¿esz wejœæ");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            iCanOpen = false;
            print("Nie mo¿esz wejœæ");
        }
    }

    public void UseKey()
    {
        foreach (Door door in doors)
        {
            door.OpenDoor();
        }
    }

    public bool CheckExistKey()
    {
        if (GameManager.Instance.RedKeys > 0 && myColor == KeyColor.RedKey)
        {
            GameManager.Instance.RedKeys--;
            locked = false;
            return true;
        }
        else if (GameManager.Instance.RedKeys > 0 && myColor == KeyColor.GreenKey)
        {
            GameManager.Instance.GreenKeys--;
            locked = false;
            return true;
        }
        else if (GameManager.Instance.RedKeys > 0 && myColor == KeyColor.BlueKey)
        {
            GameManager.Instance.BlueKeys--;
            locked = false;
            return true;
        }
        else
        {
            return false;
        }
    }
}
