using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float baseSpeed;
    [SerializeField] float sprintMultiplier;
    [SerializeField] float groundMultiplier;

    [SerializeField] float LowMul;
    [SerializeField] float HighMul;

    [SerializeField]private float speed;

    private CharacterController controller;

    private bool isSprinting;

    [Header("Ground")]
    public Transform groundCheck;
    public LayerMask groundMask;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        PlayerMovement();

        CheckGround();

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            isSprinting = true;
            speed = baseSpeed * sprintMultiplier * groundMultiplier;
        }
        else
        {
            isSprinting = false;
            speed = baseSpeed * groundMultiplier;
        }
    }

    private void PlayerMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }

    private void CheckGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(groundCheck.position, transform.TransformDirection(Vector3.down), out hit, 0.4f, groundMask))
        {
            string terrainType = hit.collider.gameObject.tag;

            switch(terrainType)
            {
                default:
                    groundMultiplier = 1;
                    break;
                case "Low":
                    groundMultiplier = LowMul;
                    break;
                case "High":
                    groundMultiplier = HighMul;
                    break;
            }
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.tag == "Pickup")
        {
            hit.gameObject.GetComponent<Pickup>().Picked();
        }
    }
}
