using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {


    public GameObject objectPrefab;
    public float spawnRate = 1.0F;
    private float crazinessLevel = 0;
    public Timer spawnTimer;

	void Start() 
	{
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.trigger = this;
        updateSpawnRate();
        spawnTimer.startTimer();
    }

	void Update() 
    {
        
	}

    public void setCrazinessLevel(float crazinessLevel)
    {
        this.crazinessLevel = crazinessLevel;
        updateSpawnRate();
    }

    private void updateSpawnRate(){
        spawnRate = crazinessLevel + 1.0F;
        spawnTimer.timerValue = spawnRate;
    }

    public void timesUp()
    {
        spawn();
        spawnTimer.startTimer();
    }

    public void spawn()
    {
        Debug.Log("spawn");
    }
}
