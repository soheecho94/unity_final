// code tutorial from https://www.youtube.com/watch?v=n-KX8AeGK7E

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonMover : MonoBehaviour
{
    //base movement variables
    private string horizontalInputName = "Horizontal";
    private string verticalInputName = "Vertical";
    public float movespeed = 6f;
    //access actual movement implementer
    private CharacterController characterController;
    //base jump variables
    public float jumpMultiplier;
    public KeyCode jumpKey;
    public AnimationCurve jumpFallOff;
    private bool isJumping;

    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        //apply force when movement keys are pressed
        float verticalInput = Input.GetAxis(verticalInputName);
        float horizontalInput = Input.GetAxis(horizontalInputName);
        //transform input into movement force
        Vector3 verticalMove = verticalInput * transform.forward * movespeed;
        Vector3 horizontalMove = horizontalInput * transform.right * movespeed;

        //move character
        characterController.SimpleMove(verticalMove + horizontalMove);
    }

}
