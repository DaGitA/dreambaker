using UnityEngine;

public class PlayerOneController : MonoBehaviour
{
    public float jumpSpeed = 15.0F;
    private Vector3 moveDirection = Vector3.zero;
    public float moveSpeed = 5.0F;
    public float runSpeed = 20.0F;
    public bool isGrounded = false;
    private Transform meshConscience;
    private Animator animator;

    public bool isMine = false;


    private void Awake()
    {
        meshConscience = transform.FindChild("Hero");
        animator = this.GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (isMine)
        {
            getUserInput();
            determineMovementSpeed();
            animator.SetBool("jumping", false);

            if (Input.GetButton("Jump") && isGrounded)
            {
                animator.SetBool("jumping", true);
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
        GetComponent<Rigidbody>().velocity = new Vector3(0, jumpSpeed, 0);
    }

    private void getUserInput()
    {
        moveDirection = new Vector3(Input.GetAxis("Vertical") * -1, 0, Input.GetAxis("Horizontal"));
        if (moveDirection.Equals(Vector3.zero))
        {
            animator.SetBool("walking", false);
        }
    }

    private void move()
    {
        animator.SetBool("walking", true);
        transform.Translate(moveDirection);
        faceMovingDirection(moveDirection);
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

    public void faceMovingDirection(Vector3 moveDirection)
    {
        if (moveDirection.magnitude != 0)
            meshConscience.rotation = Quaternion.LookRotation(moveDirection, transform.up); 
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
        if (collision.gameObject.tag == "Floor")
        {
            isGrounded = false;
        }
    }
}