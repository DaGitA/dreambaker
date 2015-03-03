using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour
{

    public Component trigger;
    public float timerValue;

    private float time;
    private float targetTime;

    void Start() { }

    void FixedUpdate()
    {
        time += Time.fixedDeltaTime;
        if (time > targetTime)
        {
            trigger.SendMessage("timesUp");
        }
    }

    public void startTimer()
    {
        time = Time.time;
        targetTime = time + timerValue;
    }
}
