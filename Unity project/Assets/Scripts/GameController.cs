using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private static Vector3 START_LOCATION = new Vector3(0,0,0);
    private Vector3 nextRespawnLocation = START_LOCATION;
    private GameObject player;
    private bool isPaused;
    public GameObject HUD;

    CheckPointController checkpointController;

    // Use this for initialization
	void Start () {
        player = GameObject.Find("Player");
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

        public void setNextRespawnLocation(Vector3 checkpointPosition)
    {
        nextRespawnLocation = checkpointPosition;
    }

    internal void respawn()
    {
        checkpointController.respawnPlayerLocation();       
    }
}
