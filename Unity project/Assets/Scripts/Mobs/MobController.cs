using UnityEngine;
using System.Collections;

public class MobController : MonoBehaviour
{

    private Transform target;
    public int moveSpeed;
    private GameObject instantiatedObj;
    private Vector3 originPosition;
    private float stepBackTimer;
    private bool stepBackTimerStarted;
    private Transform aggroZone;
    // states of mobs
    private bool moveTowardATarget;

    void Start()
    {
        originPosition = transform.position;
        untrackTarget();
        aggroZone = gameObject.transform.Find("AggroZone");
        stepBackTimerStarted = false;
    }

    void Update()
    {
        if (stepBackTimerStarted)
        {
            stepBackTimer = stepBackTimer - Time.deltaTime;
            if (stepBackTimer <= 0)
            {
                stopStepBackTimer();
            }
        }
    }


    public void trackTarget(Transform target)
    {
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
        aggroZone.gameObject.SetActive(false);
        startStepBackTimer();
    }

    private void startStepBackTimer()
    {
        stepBackTimerStarted = true;
        float timeThatTheMobRetreats = 0.1f;
        stepBackTimer = timeThatTheMobRetreats;
    }

    private void stopStepBackTimer()
    {
        aggroZone.gameObject.SetActive(true);
    }
}
