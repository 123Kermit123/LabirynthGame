using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]private float Sensitivity = 100f;

    private Transform PlayerBody;
    private float XRotation = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        PlayerBody = transform.parent;
    }

    private void Update()
    {
        CameraRotation();
    }

    private void CameraRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.fixedDeltaTime * Time.timeScale;
        float mouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.fixedDeltaTime * Time.timeScale;

        XRotation -= mouseY;
        XRotation = Mathf.Clamp(XRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(XRotation, 0f, 0f);

        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
