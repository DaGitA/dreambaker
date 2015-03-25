using UnityEngine;
using System.Collections;

public class PlayerTwoAttackBehaviour : MonoBehaviour
{

    public GameObject weaponPrefab;
    private Timer timer;
    private Animator animator;
    public float attackTime = 1000f;
    private Vector3 moveDirection;
    private Transform meshConscienceTranform;
    public float shootForce = 1;
    private GameObject fireBall;

    void Start()
    {
        timer = gameObject.AddComponent<Timer>();
        animator = this.GetComponentInChildren<Animator>();
        meshConscienceTranform = transform.Find("conscience");
        timer.trigger = this;
        timer.timerValue = attackTime;
    }

    void Update()
    {
    }

    private void playerAttack()
    {
        animator.SetBool("attack", true);
        throwFireBall();
        timer.startTimer();
    }

    private void throwFireBall()
    {
        fireBall = Network.Instantiate(weaponPrefab, transform.position, Quaternion.identity, 0) as GameObject;
        fireBall.GetComponent<Rigidbody>().velocity = (2 * meshConscienceTranform.forward + Vector3.up).normalized * shootForce;
    }

    public void timesUp()
    {
        weaponPrefab.gameObject.SetActive(false);
        animator.SetBool("attack", false);
        Network.Destroy(fireBall);

    }

    private void getUserInput()
    {
        moveDirection = new Vector3(Input.GetAxis("Vertical") * -1, 0, Input.GetAxis("Horizontal"));
    }


}
