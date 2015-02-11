using UnityEngine;
using System.Collections;

public class MobController : MonoBehaviour {

    private Transform target;
    public int moveSpeed;


    public void trackTarget(Transform target){
        this.target = target;
        moveTowardTarget();
    }

    public void moveTowardTarget()
    {
        transform.LookAt(target.position);
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }

    public void goBackToSpawn()
    {

    }

}
