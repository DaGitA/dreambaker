using UnityEngine;
using System.Collections;

public class EnnemyAI : MonoBehaviour
{    
    private Transform target;
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    float lastAttack;
   
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

    void OnTriggerEnter(Collider other)
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