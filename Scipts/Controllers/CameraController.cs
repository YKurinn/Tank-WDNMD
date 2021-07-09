using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float mouseX, mouseY,mouseZ;
    public float mouseSensitivity;
    public float xRotation,yRotation,zRotation;
    public float maxHorizentalAngle;
    public float minHorizentalAngle;
    public float maxVerticalAngle;
    public float minVerticalAngle;
    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftAlt)) 
        {
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -50, 20);
            yRotation += mouseX;
            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        }
        else 
        { 
            mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, minVerticalAngle, maxVerticalAngle);
            yRotation += mouseX;
            yRotation = Mathf.Clamp(yRotation, minHorizentalAngle, maxHorizentalAngle);
            transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0);
        }
    }
}
