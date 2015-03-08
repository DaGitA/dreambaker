using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public bool haveControl = false;
    public int speed = 10;
    private float verticalInput = 0.0f;
    private float horizontalInput = 0.0f;


    void FixedUpdate()
    {
        if (haveControl)
        {
            takePlayerInput();
            Vector3 newVelocity = (transform.right * horizontalInput * speed) + (transform.forward * verticalInput * speed);
            Vector3 velocity = GetComponent<Rigidbody>().velocity;
            velocity.x = newVelocity.x;
            velocity.z = newVelocity.z;

            if (velocity != GetComponent<Rigidbody>().velocity)
            {
                if (Network.isServer)
                {
                    movePlayer(velocity);
                }
                else
                {
                    GetComponent<NetworkView>().RPC("movePlayer", RPCMode.Server, velocity);
                }
            }
            
        }
    }

    private void takePlayerInput()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }

    [RPC]
    private void movePlayer(Vector3 velocity)
    {
        GetComponent<Rigidbody>().velocity = velocity;
        GetComponent<NetworkView>().RPC("updatePlayer", RPCMode.OthersBuffered, transform.position);
    }

    [RPC]
    private void updatePlayer(Vector3 position)
    {
        transform.position = position;
    }
}
