using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    private static Vector3 START_LOCATION = new Vector3(0,0,0);
    private Vector3 nextRespawnLocation = START_LOCATION;
    private GameObject player;
    private GameObject HUD;
    private bool gameHasStarted;

    // Use this for initialization
	void Start () {
     player = GameObject.Find("Player");
     HUD = GameObject.Find("HUD");
     HUD.SetActive(true);
     gameHasStarted = true;
	}

    public void setNextRespawnLocation(Vector3 checkpointPosition)
    {
        nextRespawnLocation = checkpointPosition;
    }

    internal void respawn()
    {
        respawnPlayer();
    }

    private void respawnPlayer()
    {
        player.transform.position = nextRespawnLocation + new Vector3(0, nextRespawnLocation.y, 0);
    }

    public bool gameAlreadyStarted()
    {
        return gameHasStarted;
    }
}
