using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{
    public Component trigger;
    public float timerValue;

    private float time;
    private float targetTime;
    private bool started = false;

    void Start() { }

    void FixedUpdate()
    {
        if (started)
        {
            time += Time.fixedDeltaTime;
            if (time > targetTime)
            {
                trigger.SendMessage("timesUp");
                started = false;
            }
        }
    }

    public void startTimer()
    {
        time = Time.time;
        targetTime = time + timerValue;
        started = true;
    }
}
