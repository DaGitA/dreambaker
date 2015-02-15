using UnityEngine;

public class WalkThroughWall : MonoBehaviour
{
    public GameObject wall;

    private void Start()
    {
    }

    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Player")
        {
            Physics.IgnoreCollision(wall.collider, other.collider);
        }
    }
}