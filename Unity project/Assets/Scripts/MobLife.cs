using UnityEngine;
using System.Collections;

public class MobLife : MonoBehaviour {

    public float healthBar = 100;
    private Animator animator;
    private GameObject gameController;
    private Timer myTimer;

    void Awake()
    {
        myTimer = gameObject.AddComponent<Timer>();
        animator = this.GetComponentInChildren<Animator>();
        gameController = GameObject.FindWithTag("GameController");
    }

    public void takeDamage(float attackDamage)
    {
        animator.SetBool("isHit", true);
        startHitTimer();
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

    private void startHitTimer()
    {
        float milliSecondsToWait = 2000.0f;
        myTimer.setSlot("hitAnimationIsOver");
        myTimer.setTrigger(this);
        myTimer.setTimerValue(milliSecondsToWait);
        myTimer.startTimer();
    }

    public void hitAnimationIsOver()
    {
        Debug.Log("hitAnimationIsOver reached");
        animator.SetBool("isHit", false);
    }

    public void test()
    {
        Debug.Log("Bob");
    }
}
