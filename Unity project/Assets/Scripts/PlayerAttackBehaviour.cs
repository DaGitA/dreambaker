using UnityEngine;
using System.Collections;

public class PlayerAttackBehaviour : MonoBehaviour {

    public WeaponAttackBehaviour weaponPrefab;
    private Timer timer;
    public bool isOnCoolDown = false;
    public float attackTime = 0.2f;

    void Start()
    {
        weaponPrefab = this.GetComponentInChildren<WeaponAttackBehaviour>();
        timer = gameObject.AddComponent<Timer>();
        timer.trigger = this;
        timer.timerValue = attackTime;
    }

    void Update()
    {
        if (Input.GetButton("Fire2") && !isOnCoolDown)
        {
            weaponPrefab.gameObject.SetActive(true);
            timer.startTimer();
            isOnCoolDown = true;
        }
        
    }

    void timesUp()
    {
        weaponPrefab.gameObject.SetActive(false);
        isOnCoolDown = false;
    }
}
