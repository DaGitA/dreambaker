﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpSpeed = 10.0F;
    private Vector3 moveDirection = Vector3.zero;
    public float moveSpeed = 20.0F;
    public float runSpeed = 20.0F;
    public bool isGrounded = false;


    public bool isMine = false;


    private void Awake()
    {
    }

    private void Update()
    {
        if (isMine)
        {
            getUserInput();
            determineMovementSpeed();
            
            if (Input.GetButton("Jump") && isGrounded)
            {
                jump();
            }
        }
    }

    private void FixedUpdate()
    {
        move();
    }
    
    private void jump()
    {
        rigidbody.velocity = new Vector3(0,jumpSpeed,0);
    }

    private void getUserInput()
    {
        moveDirection = new Vector3(Input.GetAxis("Vertical") * -1, 0, Input.GetAxis("Horizontal"));
    }

    private void move()
    {
        transform.Translate(moveDirection);
    }

    private void determineMovementSpeed()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveDirection *= runSpeed;
        }
        else
        {
            moveDirection *= moveSpeed;
        }
    }

    [RPC]
    public void setOwner(NetworkPlayer player)
    {
        if (Network.player == player)
        {
            isMine = true;
        }
        else
        {
            if (GetComponentInChildren<Camera>())
            {
                GetComponentInChildren<Camera>().enabled = false;
            }
            if (GetComponentInChildren<AudioListener>())
            {
                GetComponentInChildren<AudioListener>().enabled = false;
            }
            if (GetComponentInChildren<GUILayer>())
            {
                GetComponentInChildren<GUILayer>().enabled = false;
            }
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Floor"){
            isGrounded = false;
        }
    }
}