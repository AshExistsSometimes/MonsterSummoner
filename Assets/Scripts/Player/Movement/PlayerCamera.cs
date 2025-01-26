using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public float XSensitivity;
    public float YSensitivity;

    public Transform orientation;// Player Rotation

    float xRot;
    float yRot;

    public bool CursorLocked = false;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        CursorLocked = true;
    }

    private void Update()
    {
        CursorLocking();

        // Get Mouse Input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * XSensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * YSensitivity;

        yRot += mouseX;

        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90, 90);

        // Rotate Camera & Orientation
        transform.rotation = Quaternion.Euler(xRot, yRot, 0f);
        orientation.rotation = Quaternion.Euler(0f, yRot, 0f);
    }

    ////////////////////////////////////////////////////////////////////////////////////////////////////
    private void CursorLocking()
    {
        // Cursor Locking //
        if (CursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
