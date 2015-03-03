using UnityEngine;
using System.Collections;

public class CheckpointScript : MonoBehaviour {

    CheckPointController checkpointController;
	// Use this for initialization
	void Start () {
        checkpointController = GameObject.Find("GameController").GetComponent<CheckPointController>();
        OnTriggerEnter();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter()
    {
     Debug.Log("CheckPoint entered");
    if(checkpointController.isMostAdvancedCheckpoint())
    {
    checkpointController.setNextRespawnLocation(transform.position);
     checkpointController.setNextRespawnCrazynessLevel(gameController.getCrazynessLevelValue());
     checkpointController.setNextRespawnHopeLevel(gameController.getHopeLevelValue());
    }     
    }

    //Doc: http://ben.ie/checkpoints/
}
