using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpSpeed = 8.0F;
    private float xInput;
    private float yInput;
    private float zInput;
    private Vector3 displacment;
    public float moveSpeed = 5.0F;

    // Use this for initialization    
    private void Awake()
    {
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        updateUserInput();
        updatePosition();
    }

    private void updateUserInput()
    {
        zInput = Input.GetAxis("Horizontal");
        xInput = -1 * Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump();
        }
        
    }

    private void jump()
    {
        transform.Translate(Vector3.up * jumpSpeed * Time.deltaTime);
    }

    public void updatePosition()
    {
        transform.position += new Vector3(xInput,0,zInput)*moveSpeed;
    }

    public void takeDammage(float attackDammage)
    {
        Debug.Log("AOUCH");
    }

}