using UnityEngine;
using System.Collections;

public class MobController : MonoBehaviour {

    private Transform target;
    public int moveSpeed;
    private GameObject instantiatedObj;
    private Vector3 originPosition;
    // states of mobs
    private bool moveTowardATarget;
    private float stepBackTimer;

    void Start()
    {
        originPosition = transform.position;
        untrackTarget();
    }

    void Update()
    {

    }


    public void trackTarget(Transform target){
        this.target = target;
        moveTowardATarget = true;
    }

    public void untrackTarget()
    {
        this.target = null;
        moveTowardATarget = false;
    }

    public void moveTowardTarget()
    {
        transform.LookAt(target.position);
        moveForward();
    }

    public void moveBackToSpawn()
    {
        transform.LookAt(originPosition);
        moveForward();
    }

    private void moveForward()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    void FixedUpdate()
    {
        move();
    }

    private void move()
    {
        if (moveTowardATarget)
        {
            moveTowardTarget();
        }
        else
        {
            moveBackToSpawn();
        }
    }

    public void stepBackOnDamage()
    {
        untrackTarget();
        getAgrozone().disable
            Timer
                agrozone.enabled
    }
}
