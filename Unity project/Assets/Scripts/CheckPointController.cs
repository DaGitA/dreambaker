using UnityEngine;
using System.Collections;

public class CheckPointController : MonoBehaviour
{
    private static Vector3 START_LOCATION = new Vector3(0, 0, 0);
    private GameController gameController;
    private Vector3 nextRespawnLocation;
    private System.Collections.Generic.List<int> checkpointsPassed;
    private GameObject player;

    // Use this for initialization
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        player = GameObject.Find("Player");
        nextRespawnLocation = START_LOCATION;
    }

    internal bool isNewCheckpoint(int checkpointID)
    {
        foreach (int currentCheckpointID in checkpointsPassed)
        {
            if (currentCheckpointID == checkpointID)
                return true;
        }
        return false;
    }

    internal void setNextRespawnLocation(Vector3 checkpointLocation)
    {
        nextRespawnLocation = checkpointLocation;
    }

    public void respawnPlayerLocation()
    {
        player.transform.position = nextRespawnLocation + new Vector3(0, nextRespawnLocation.y, 0);
    }
}
