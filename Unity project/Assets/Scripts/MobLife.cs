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
        healthBar -= attackDamage;
        Debug.Log(healthBar);
        if (healthBar <= 0)
        {
            animator.SetBool("isDead", true);
            gameController.SendMessage("mort", gameObject);
        }
    }
}
