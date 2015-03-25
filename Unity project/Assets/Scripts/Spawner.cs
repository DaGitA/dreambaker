using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {


    public GameObject objectPrefab;
    public const float DEFAULT_MOBS_SPAWNED_PER_SECOND = 0.1f;
    public float spawnRate;
    private float crazinessLevel = 0;
    private float COEFFICIENT = 0.5f;
    private float timer;

    private CrazinessLevelController crazinessLevelController;

	void Start() 
	{
        crazinessLevelController = GameObject.FindObjectOfType<CrazinessLevelController>() as CrazinessLevelController;
        updateSpawnRate();
        spawn();
    }

	void Update() 
    {
        timer = timer - Time.deltaTime;
        if (timer <= 0)
        {
            timesUp();
        }
	}

    public void setCrazinessLevel(float crazinessLevel)
    {
        this.crazinessLevel = crazinessLevel;
    }

    private void updateSpawnRate(){
        double crazinessLevelDouble = System.Convert.ToDouble(crazinessLevelController.crazinessLevel);
        if (crazinessLevelDouble <= 1)
            crazinessLevelDouble = 2;
        //Ancienne fonction: spawnRate = COEFFICIENT * crazinessLevel * (DEFAULT_MOBS_SPAWNED_PER_SECOND);
        spawnRate = COEFFICIENT * (float)System.Math.Log10(crazinessLevelDouble);
        timer = 1/spawnRate;
    }

    public void timesUp()
    {
        spawn();
        updateSpawnRate();
    }

    public void spawn()
    {
        if (Network.isServer)
        {
            Debug.Log("spawn");
            Network.Instantiate(objectPrefab, transform.position, Quaternion.identity, 0);    
        }
    }
}
