using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private static Vector3 START_LOCATION = new Vector3(0,0,0);
    private Vector3 nextRespawnLocation = START_LOCATION;
    private bool isPaused;
    public GameObject HUD;

    // Use this for initialization
	void Start () {
        pauseGame();
        HUD.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void setNextRespawnLocation(Vector3 checkpointPosition)
    {
        nextRespawnLocation = checkpointPosition;
    }

    public void pauseGame()
    {
        Time.timeScale = 0;
        isPaused = true;
    }

    public void unPauseGame()
    {
        Time.timeScale = 1;
        isPaused = false;
    }

    public bool gameIsPaused()
    {
        return isPaused;
    }

}
