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
        meshWeapon = transform.FindChild("Weapon");
        timer = gameObject.AddComponent<Timer>();
        animator = this.GetComponentInChildren<Animator>();
        timer.trigger = this;
        timer.timerValue = attackTime;
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
        
        weaponPrefab.rigidbody.velocity = moveDirection.normalized * 5;
        //weaponPrefab.rigidbody.AddRelativeForce(transform.forward * 20, ForceMode.Impulse);
        //weaponPrefab.transform.TransformDirection(moveDirection);
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
        if (moveDirection.Equals(Vector3.zero))
        {
            meshWeapon.localPosition = new Vector3(0, 0, 1);
        }
        else
        {
            meshWeapon.localPosition = moveDirection.normalized;
        }
    }
}
