using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    private Component trigger;
    private float timerValue;

    private float time;
    private float targetTime;

    private string functionToCall;

    void Start() 
    {
        functionToCall = "timesUp";
    }

    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        if (time > targetTime)
        {
            trigger.SendMessage(functionToCall);
            functionToCall = "timesUp";
        }
    }

    public void startTimer()
    {
        time = Time.time;
        targetTime = time + timerValue;
    }

    public void setSlot(string slot)
    {
        functionToCall = slot;
    }

    internal void setTrigger(Component gameObject)
    {
        trigger = gameObject;
    }

    internal void setTimerValue(float time)
    {
        timerValue = time;
    }
}
