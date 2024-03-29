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

    private Vector3 playerVelocity;

    public float DashMul;

    public bool CanDash;

    public float DashCooldown;

    float DM;
    float SM;

    [Header("Ground")]
    public Transform groundCheck;
    public LayerMask groundMask;

    [Header("Jumping")]
    [SerializeField] KeyCode JumpKey;
    public float jumpPower = 10;
    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //PlayerMovement();

        Movement();

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            isSprinting = true;
            SM = sprintMultiplier;

            speed = baseSpeed * sprintMultiplier * groundMultiplier ;
        }
        else
        {
            isSprinting = false;
            SM = 1;

            speed = baseSpeed * groundMultiplier;
        }

        if (Input.GetKeyDown(KeyCode.Space) && CanDash)
        {
            DM = DashMul;

            StartCoroutine(Dash());

            Invoke(nameof(CanDashTrue), DashCooldown);
        }
    }

    /*private void PlayerMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);
    }*/

    private void Movement()
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

        #region PlayerMovement

        playerVelocity += Physics.gravity * Time.deltaTime * 2;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = hit.collider != null ? (transform.right * x + transform.forward * z) : (transform.up * playerVelocity.y);

        playerVelocity.y = Input.GetKeyDown(JumpKey) && hit.collider != null ? jumpPower : 0;

        controller.Move(move * speed * Time.deltaTime);

        #endregion 

    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.gameObject.tag == "Pickup")
        {
            hit.gameObject.GetComponent<Pickup>().Picked();
        }
    }

    void CanDashTrue()
    {
        CanDash = true;
    }

    IEnumerator Dash()
    {
        CanDash = false;

        int i = 1;

        while (i < 20)
        {
            yield return new WaitForSecondsRealtime(0.001f);
            i++;

            controller.Move(transform.forward * speed * DashMul * Time.deltaTime * 3 * SM);
        }

        yield return null;
    }
}
