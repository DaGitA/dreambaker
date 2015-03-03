using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private bool isPaused;
    public GameObject HUD;

    CheckPointController checkpointController;

    // Use this for initialization
	void Start () {
        pauseGame();
        HUD.SetActive(false);
        checkpointController =  this.GetComponent<CheckPointController>();
	}
	
	// Update is called once per frame
	void Update () {
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

    internal void respawn()
    {
        checkpointController.respawnPlayerLocation();       
    }
}
