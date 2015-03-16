using UnityEngine;
using System.Collections;

public class MobLife : MonoBehaviour {

    public float healthBar = 100;
    private Animator animator;
    private GameObject gameController;
    private Timer myTimer;

    void Awake()
    {
        animator = this.GetComponentInChildren<Animator>();
        gameController = GameObject.FindWithTag("GameController");
        myTimer = gameObject.AddComponent<Timer>();
        myTimer.trigger = this;
        float hitAnimationDelay = 1.0f;
        myTimer.timerValue = hitAnimationDelay;
    }

    public void takeDamage(float attackDamage)
    {
        animator.SetBool("isHit", true);
        myTimer.startTimer();
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

    public void timesUp()
    {
        animator.SetBool("isHit", false);
        Debug.Log("timesup");
    }
}
