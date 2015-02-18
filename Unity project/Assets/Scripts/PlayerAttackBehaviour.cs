using UnityEngine;
using System.Collections;

public class PlayerAttackBehaviour : MonoBehaviour {

    public float attackDamage = 1;

    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown("tab") && other.CompareTag("Mob"))
        {
            other.SendMessage("takeDamage", attackDamage);
        }
    }
}
