using UnityEngine;
using System.Collections;

public class attackBehavior : MonoBehaviour {

    public float attackDammage = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mob") || other.CompareTag("Player"))
        {
            other.SendMessage("takeDammage", attackDammage);
        }
    } 
}
