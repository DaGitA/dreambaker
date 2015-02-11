using UnityEngine;
using System.Collections;

public class EnnemyAI : MonoBehaviour
{

    
    private Transform target;
    public int moveSpeed;
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
            Debug.Log("EnteringAggroMax");
            SendMessageUpwards("trackTarget");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("QuitingAggroMax");
            SendMessageUpwards("goBackToSpawn");
        }
    }
}