using UnityEngine;
using System.Collections;

public class EnnemyAI : MonoBehaviour
{    
    private Vector3 originalPosition;
    private Quaternion originalRotation;
   
    void Awake()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
    }


    void Start()
    {
        
    }

    void FixedUpdate()
    {
        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("EnteringAggroZone");
            SendMessageUpwards("trackTarget", other.transform);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            SendMessageUpwards("untrackTarget");
        }
    }
}