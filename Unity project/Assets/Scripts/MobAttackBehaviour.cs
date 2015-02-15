using UnityEngine;
using System.Collections;

public class MobAttackBehaviour : MonoBehaviour
{
    public float attackDammage = 1;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.SendMessage("takeDammage", attackDammage);
        }
    }
}
