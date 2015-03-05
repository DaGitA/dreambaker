using UnityEngine;
using System.Collections;

public class PlayerOneAttackBehaviour : MonoBehaviour
{

    public WeaponAttackBehaviour weaponPrefab;
    private Timer timer;
    private Animator animator;
    public float attackTime = 0.2f;
    private Vector3 moveDirection;
    public float shootForce = 100;

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
        if (Input.GetButtonUp("Fire2"))
        {
            attack();
        }
    }

    private void attack()
    {
        weaponPrefab.gameObject.SetActive(true);
        animator.SetBool("attack", true);
        //weaponPrefab.rigidbody.AddForce(weaponPrefab.transform.forward * shootForce);
        //weaponPrefab.transform.TransformDirection(moveDirection);
        timer.startTimer();
    }

    public void timesUp()
    {
        weaponPrefab.gameObject.SetActive(false);
        animator.SetBool("attack", false);
    }

}