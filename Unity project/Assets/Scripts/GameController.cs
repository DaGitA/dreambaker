using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private static Vector3 START_LOCATION = new Vector3(0,0,0);
    private float crazynessLevel;
    public UnityEngine.UI.Text crazynessLevelText;
    public UnityEngine.UI.Slider crazynessLevelSlider;
    float lastCrazynessLevelUpdate;
    private float TIME_TO_RAISE_CRAYZYNESS_LEVEL = 3;
    private int DECREASE_CRAZINESS_LEVEL_WITH_PILL = 10;
    private Vector3 nextRespawnLocation = START_LOCATION;

    // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        handleCrazynessLevel();
	}

    private void handleCrazynessLevel()
    {
        if ((Time.time - lastCrazynessLevelUpdate) >= TIME_TO_RAISE_CRAYZYNESS_LEVEL)
        {
            crazynessLevel = crazynessLevel + 1;
            lastCrazynessLevelUpdate = Time.time;
            displayCrazynessValue();
        }    
    }

    public void addOneCollectedPill()
    {
        if (crazynessLevel >= DECREASE_CRAZINESS_LEVEL_WITH_PILL)
        {
            crazynessLevel -= DECREASE_CRAZINESS_LEVEL_WITH_PILL;
            displayCrazynessValue();
        }
        else
        {
            crazynessLevel = 0;
            displayCrazynessValue();
        }

    }

    private void displayCrazynessValue()
    {
        crazynessLevelText.text = crazynessLevel.ToString();
        crazynessLevelSlider.value = crazynessLevel;
    }

    public void setNextRespawnLocation(Vector3 checkpointPosition)
    {
        nextRespawnLocation = checkpointPosition;
    }
}
