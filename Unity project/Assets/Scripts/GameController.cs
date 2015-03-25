using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private static Vector3 START_LOCATION = new Vector3(0,0,0);
    private Vector3 nextRespawnLocation = START_LOCATION;
    private GameObject[] players;
    private GameObject HUD;
    CheckPointController checkpointController;

    // Use this for initialization
	void Start () {
     players = GameObject.FindGameObjectsWithTag("Player");
     checkpointController = this.GetComponent<CheckPointController>();
	}

    public void setNextRespawnLocation(Vector3 checkpointPosition)
    {
        nextRespawnLocation = checkpointPosition;
    }

    internal void respawn()
    {
        foreach(GameObject player in players)
        {
            checkpointController.respawnPlayerLocation();
            player.GetComponent<CharactersCommon>().respawnHopeLevel();
        }
        this.GetComponent<CrazinessLevelController>().respawnCrazinessLevel();      
    }
}
