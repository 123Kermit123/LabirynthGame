using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class Lock : MonoBehaviour
{
    public List<Door> doors;
    public KeyColor myColor;
    public bool iCanOpen = false;
    public bool locked = false;
    Animator animator;

    public string PadlockName = "Padlock";
    public GameObject PadlockObj;

    public Material CanOpenMaterial;
    public Material BlankMaterial;
    private void Start()
    {
        animator = GetComponent<Animator>();
        PadlockObj = transform.Find(PadlockName).gameObject;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && iCanOpen == true && !locked)
        {
            animator.SetBool("Open", true);
            UseKey();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            iCanOpen = true;
            print("Możesz wejść");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            iCanOpen = false;
            print("Nie możesz wejść");
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
