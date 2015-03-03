using UnityEngine;
using System.Collections;

public class PlayerAttackBehaviour : MonoBehaviour {

    public WeaponAttackBehaviour weaponPrefab;
    private Timer timer;
    private Animator animator;
    public bool isOnCoolDown = false;
    public float attackTime = 0.2f;

    void Start()
    {
        weaponPrefab = this.GetComponentInChildren<WeaponAttackBehaviour>();
        timer = gameObject.AddComponent<Timer>();
        animator = this.GetComponentInChildren<Animator>();
        timer.trigger = this;
        timer.timerValue = attackTime;
    }

    void Update()
    {
        if (Input.GetButton("Fire2") && !isOnCoolDown)
        {
            weaponPrefab.gameObject.SetActive(true);
            animator.SetBool("attack", true);
            timer.startTimer();
            isOnCoolDown = true;
        }
        
    }

    void timesUp()
    {
        weaponPrefab.gameObject.SetActive(false);
        animator.SetBool("attack", false);
        isOnCoolDown = false;
    }
}
