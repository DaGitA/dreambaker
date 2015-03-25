using UnityEngine;
using System.Collections;

public class MobAttackBehaviour : MonoBehaviour
{
    public float attackDamage = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.SendMessage("takeDamage", attackDamage);
        }
    }
}
