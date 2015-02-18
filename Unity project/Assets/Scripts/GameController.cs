using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private static Vector3 START_LOCATION = new Vector3(0,0,0);
    private float crazynessLevel;
    public UnityEngine.UI.Text crazynessLevelText;
    public UnityEngine.UI.Slider crazynessLevelSlider;
    public UnityEngine.UI.Slider hopeLevelSlider;
    float lastCrazynessLevelUpdate;
    private float TIME_TO_RAISE_CRAYZYNESS_LEVEL = 3;
    private int DECREASE_CRAZINESS_LEVEL_WITH_PILL = 10;
    private Vector3 nextRespawnLocation = START_LOCATION;
    private float nextRespawnHopeLevel;
    private float nextRespawnCrazynessLevel;
    private bool isPaused;
    public GameObject HUD;
    private GameObject player;

    // Use this for initialization
	void Start () {
        pauseGame();
        HUD.SetActive(false);
        player = GameObject.Find("Player");
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

    public float getCrazynessLevelValue()
    {
        return crazynessLevel;
    }

    public void setNextRespawnLocation(Vector3 checkpointPosition)
    {
        nextRespawnLocation = checkpointPosition;
    }

    public void setNextRespawnHopeLevel(float hopeLevel)
    {
        nextRespawnHopeLevel = hopeLevel;
    }

    public void setNextRespawnCrazynessLevel(float crazynessLevel)
    {
        nextRespawnCrazynessLevel = crazynessLevel;
    }

    internal void pauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    internal void unPauseGame()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    internal bool gameIsPaused()
    {
        return isPaused;
    }

    internal void setCrazynessLevelValue(float newValue)
    {
        crazynessLevel = newValue;
    }

    internal void respawn()
    {
        respawnPlayer();
        reloadHope();
        reloadCrazyness();
    }

    private void reloadCrazyness()
    {
        crazynessLevelSlider.value = nextRespawnCrazynessLevel;
    }

    private void reloadHope()
    {
        hopeLevelSlider.value = nextRespawnHopeLevel;
    }

    private void respawnPlayer()
    {
        player.transform.position = nextRespawnLocation + new Vector3(0, nextRespawnLocation.z, 0);
    }

    public float getHopeLevelValue()
    {
        return hopeLevelSlider.value;
    }
}
