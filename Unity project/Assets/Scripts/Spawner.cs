﻿using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {


    public GameObject objectPrefab;
    public float spawnRate = 1.0F;
    public float coefficient = 100f;
    private float crazinessLevel = 0;
    private Timer spawnTimer;

    private CrazinessLevelController crazinessLevelController;

	void Start() 
	{
        crazinessLevelController = GameObject.FindObjectOfType<CrazinessLevelController>() as CrazinessLevelController;
        spawnTimer = gameObject.AddComponent<Timer>();
        spawnTimer.trigger = this;
        updateSpawnRate();
        spawnTimer.startTimer();
        coefficient = 100F;
    }

	void Update() 
    {
        
	}

    public void setCrazinessLevel(float crazinessLevel)
    {
        this.crazinessLevel = crazinessLevel;
    }

    private void updateSpawnRate(){
        crazinessLevel = crazinessLevelController.crazinessLevel;
        spawnRate = crazinessLevel;
        spawnTimer.timerValue = coefficient / (1 + 0.5f * spawnRate);
        Debug.Log(spawnTimer.timerValue);
    }

    public void timesUp()
    {
        spawn();
        updateSpawnRate();
        spawnTimer.startTimer();
    }

    public void spawn()
    {
        Network.Instantiate(objectPrefab, transform.position, Quaternion.identity, 0);
    }
}