using UnityEngine;
using System.Collections;

public class CrazinessLevelController : MonoBehaviour {

    public float TIME_TO_RAISE_CRAYZYNESS_LEVEL = 3;
    public float crazinessLevel = 0.0F;
    public float nextRespawnCrazinessLevel = 0.0F;
    private UnityEngine.UI.Slider crazynessLevelSlider;

    private Spawner[] spawnAreaList;
    private GameController gameController;
    private Timer timer;

	// Use this for initialization
	void Start () {
        crazynessLevelSlider = GameObject.Find("CrazynessSlider").GetComponent<UnityEngine.UI.Slider>();
        spawnAreaList = FindObjectsOfType(typeof(Spawner)) as Spawner[];
        timer = gameObject.AddComponent<Timer>();
        timer.timerValue = TIME_TO_RAISE_CRAYZYNESS_LEVEL;
        timer.trigger = this;
        timer.startTimer();
	}
	
	// Update is called once per frame
	void Update () {
	    
	}

    private void signalCrazinessLevelToSpawner()
    {
        foreach (Spawner spawner in spawnAreaList)
        {
            spawner.setCrazinessLevel(crazinessLevel);
        }        
    }

    public void timesUp()
    {
        incrementCrazinessLevel();
        timer.startTimer();
        displayCrazynessValue();
        signalCrazinessLevelToSpawner();
    }

    private void incrementCrazinessLevel()
    {
        if( crazinessLevel < 100){
            crazinessLevel = crazinessLevel + 1.0F;
        }
    }

    private void displayCrazynessValue()
    {
        crazynessLevelSlider.value = crazinessLevel;
    }

    public void setNextRespawnCrazinessLevel()
    {
        nextRespawnCrazinessLevel = crazinessLevel;
    }

    public void respawnCrazinessLevel()
    {
        crazinessLevel = nextRespawnCrazinessLevel;
    }
}
