using UnityEngine;
using System.Collections;

public class PlayerLife : MonoBehaviour {

    public float healthBar = 100;

    public void takeDamage(float attackDamage)
    {
        healthBar -= attackDamage;
        if (healthBar == 0)
        {
            //TODO CHECKPOINT A DAVOGE
        }
    }
}
