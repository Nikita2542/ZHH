using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public float sensitivity = 100.0f;
    public float zoomIn = 20;
    public bool lockLook;
    public Transform playerBody;
    Camera cam;

    float xRotation = 0.0f;
    float zoom;
    


    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        
        cam = GetComponent<Camera>();
        zoom = cam.fieldOfView;
    }

    void Update()
    {
        Look();
        ZoomIn();
    }

    void Look()
    {
        if (lockLook == false)
        {
            float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90.0f, 90.0f);

            transform.localRotation = Quaternion.Euler(xRotation, 0.0f, 0.0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }

    void ZoomIn()
    {
        if (Input.GetMouseButton(1))
        {
            cam.fieldOfView = zoomIn; 
        }
        else
        {
            cam.fieldOfView = zoom;
        }
    }
}
