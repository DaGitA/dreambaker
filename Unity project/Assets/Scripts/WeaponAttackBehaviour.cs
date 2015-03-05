using UnityEngine;
using System.Collections;

public class WeaponAttackBehaviour : MonoBehaviour
{
    public float attackDamage = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Mob"))
        {
            Debug.Log("Attaque");
            other.SendMessage("takeDamage", attackDamage);
//            other.GetComponentInChildren<MeshRenderer>().material.color = Color.yellow;
        }
    }
}
