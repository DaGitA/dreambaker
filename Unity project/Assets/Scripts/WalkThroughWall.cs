using UnityEngine;

public class WalkThroughWall : MonoBehaviour
{
    public string walkingObjectName = "Player";
    public GameObject wall;

    private void Start()
    {
    }

    private void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == walkingObjectName)
        {
            Physics.IgnoreCollision(wall.collider, other.collider);
        }
    }
}