// code tutorial from https://www.youtube.com/watch?v=n-KX8AeGK7E

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonLook : MonoBehaviour
{
    //Mouse controls
    public string mouseXInputName = "Mouse X";
    public string mouseYInputName = "Mouse Y";
    public float mouseSensitivity = 150f;
    //Access to player body
    public Transform playerBody;
    //camera clamping when looking vertically
    private float verticalClamp;

    void Awake() {
        Cursor.lockState = CursorLockMode.Locked; //lock cursor
        verticalClamp = 0.0f; //initialize clamping value
    }

    void Update()
    {
        Look();
        // CameraRotation();
    }

    private void Look()
    {
        //get current mouseX and mouseY axes
        //multiply with mouse sensitivity to adjust speed
        //use time.deltaTime to adjust for framerate
        float mouseX = Input.GetAxis(mouseXInputName) * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis(mouseYInputName) * mouseSensitivity * Time.deltaTime;
        //track vertical clamp threshold
        verticalClamp += mouseY;
        //handle vertical clamp if it goes over the edge
        if(verticalClamp > 90.0f) {
            verticalClamp = 90.0f;
            mouseY = 0.0f;
            ClampVerticalRotation(270.0f);
        } else if (verticalClamp < -90.0f) {
            verticalClamp = -90.0f;
            mouseY = 0.0f;
            ClampVerticalRotation(90.0f);
        }
        //apply vertical rotation through camera
        transform.Rotate(new Vector3(-1, 0, 0) * mouseY);
        //apply horizontal rotation through body
        playerBody.Rotate(new Vector3(0, 1, 0) * mouseX);
    }

    private void ClampVerticalRotation(float value)
    {
         Vector3 eulerRotation = transform.eulerAngles;
         eulerRotation.x = value;
         transform.eulerAngles = eulerRotation;
    }
}
