using UnityEngine;
using System.Collections;

<<<<<<< HEAD
public class Timer : MonoBehaviour
{

    public Component trigger;
    public float timerValue;

    private float time;
    private float targetTime;

    void Start() { }

    void FixedUpdate()
    {
=======
public class Timer : MonoBehaviour {

    public Component trigger;
    public float timerValue;
    
    private float time;
    private float targetTime;

	void Start () {}
	
	void FixedUpdate () {
>>>>>>> master
        time += Time.fixedDeltaTime;
        if (time > targetTime)
        {
            trigger.SendMessage("timesUp");
        }
<<<<<<< HEAD
    }
=======
	}
>>>>>>> master

    public void startTimer()
    {
        time = Time.time;
        targetTime = time + timerValue;
    }
}
