using UnityEngine;
using System.Collections;

public class CheckpointScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnTriggerEnter()
    {
        GameObject gameController = GameObject.FindGameObjectWithTag("GameController");
        gameController.SendMessage("setNextRespawnLocation", transform.position);
    }

    //Doc: http://ben.ie/checkpoints/
}
