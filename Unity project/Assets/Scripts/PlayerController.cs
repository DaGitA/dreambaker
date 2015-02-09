using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 20.0F;
    public float jumpSpeed = 8.0F;
    private Vector3 moveDirection = Vector3.zero;
    public float moveSpeed = 5.0F;
    public float runSpeed = 20.0F;

    private void Awake()
    {
    }

    private void FixedUpdate()
    {
        var controller = GetComponent<CharacterController>();
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Vertical")*-1, 0, Input.GetAxis("Horizontal"));
            moveDirection = transform.TransformDirection(moveDirection);

            determineMovementSpeed();

            if (Input.GetButton("Jump"))
                moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity*Time.deltaTime;
        controller.Move(moveDirection*Time.deltaTime);
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
}