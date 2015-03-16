using UnityEngine;
using System.Collections;

public class PlayerAttackBehaviour : MonoBehaviour
{

    public WeaponAttackBehaviour weaponPrefab;
    private Timer timer;
    private Animator animator;
    public float attackTime = 1f;
    private Vector3 moveDirection;
    private Transform meshWeapon;
    public float shootForce = 100;

    void Start()
    {
        weaponPrefab = this.GetComponentInChildren<WeaponAttackBehaviour>();
        timer = gameObject.AddComponent<Timer>();
        animator = this.GetComponentInChildren<Animator>();
        timer.setTrigger(this);
        timer.setTimerValue(attackTime);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            attack();
        }
    }

    private void attack()
    {
        setWeaponPosition();
        weaponPrefab.gameObject.SetActive(true);
        animator.SetBool("attack", true);
        
        weaponPrefab.GetComponent<Rigidbody>().velocity = moveDirection.normalized * 5;
        timer.startTimer();
    }

    public void timesUp()
    {
        weaponPrefab.gameObject.SetActive(false);
        animator.SetBool("attack", false);
    }

    private void getUserInput()
    {
        moveDirection = new Vector3(Input.GetAxis("Vertical") * -1, 0, Input.GetAxis("Horizontal"));
    }

    private void setWeaponPosition()
    {
        getUserInput();
        weaponPrefab.transform.localPosition = new Vector3(0 ,0.5f ,0);
    }
}
