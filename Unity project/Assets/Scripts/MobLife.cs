using UnityEngine;
using System.Collections;

public class MobLife : MonoBehaviour {

    public float healthBar = 100;
    private Animator animator;
    private GameObject gameController;

    void Awake()
    {
        animator = this.GetComponentInChildren<Animator>();
        gameController = GameObject.FindWithTag("GameController");
    }

    public void takeDamage(float attackDamage)
    {
        animator.SetBool("isHit", true);
        healthBar -= attackDamage;
        Debug.Log(healthBar);
        if (healthBar <= 0)
        {
            die();
        }
    }

    private void die()
    {
        animator.SetBool("isDead", true);
        gameController.SendMessage("mort", gameObject);
    }
}
