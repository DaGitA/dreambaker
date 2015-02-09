using UnityEngine;
using System.Collections;

public class FightController : MonoBehaviour
{
    public float attackTime, waitTime = 1.0f;
    protected bool canAttack = true;
    public float DAMAGE_STRENGTH = 0.05f;
    private Collider ennemyCollider;

    public void OnMouseDown()
    {
        attackTime = Time.time;
        if (canAttack)
        {
            damage += damage * ((int)DAMAGE_STRENGTH);
            canAttack = false;
        }
    }

    public void Update()
    {
        if (!canAttack)
        {
            if (Time.time > attackTime + waitTime)
                canAttack = true;
        }
    }
}