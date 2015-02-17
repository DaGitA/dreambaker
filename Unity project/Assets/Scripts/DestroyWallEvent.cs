using UnityEngine;

public class DestroyWallEvent : MonoBehaviour
{
    public GameObject wall;

    private void Start()
    {
    }

    private void FixedUpdate()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(wall.gameObject);
    }
}