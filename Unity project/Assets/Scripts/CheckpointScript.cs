using UnityEngine;
using System.Collections;

public class CheckpointScript : MonoBehaviour {

    GameController gameController;
	// Use this for initialization
	void Start () {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        OnTriggerEnter();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter()
    {
        Debug.Log("CheckPoint entered");
        gameController.setNextRespawnLocation(transform.position);
        gameController.setNextRespawnCrazynessLevel(gameController.getCrazynessLevelValue());
        gameController.setNextRespawnHopeLevel(gameController.getHopeLevelValue());
    }

    //Doc: http://ben.ie/checkpoints/
}
