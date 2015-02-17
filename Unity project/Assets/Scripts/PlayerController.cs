﻿using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpSpeed = 8.0F;
    private Vector3 moveDirection = Vector3.zero;
    public float moveSpeed = 20.0F;
    public float runSpeed = 20.0F;
    public float healthBar = 100;

    private void Awake()
    {
    }

    private void Update()
    {
        getUserInput();
        determineMovementSpeed();
    }

    private void FixedUpdate()
    {
        move();

        if (Input.GetButton("Jump"))
        {
            jump();
        }
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

    public void takeDamage(float attackDamage)
    {
        healthBar -= attackDamage;
        if (healthBar == 0)
        {
            //TODO CHECKPOINT A DAVOGE
        }
    }
}