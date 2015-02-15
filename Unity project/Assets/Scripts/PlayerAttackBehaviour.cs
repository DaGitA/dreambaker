using UnityEngine;
using System.Collections;

public class PlayerAttackBehaviour : MonoBehaviour {

    public float attackDammage = 1;

    void OnTriggerEnter(Collider other)
    {
        if (Input.GetKeyDown("tab") && other.CompareTag("Mob"))
        {
            other.SendMessage("takeDammage", attackDammage);
        }
    } 
}
