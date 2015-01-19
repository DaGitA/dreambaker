using UnityEngine;
using System.Collections;

public class InGameMenuController : MonoBehaviour {

    private bool isPaused = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        checkIfInGameMenuIsTriggered();
	}

    private void checkIfInGameMenuIsTriggered()
    {
        if (Input.GetKeyDown("escape") & !isPaused)
        {
            print("Paused");
            isPaused = true;
        }
        else if (Input.GetKeyDown("escape") & isPaused)
        {
            print("Unpaused");
            isPaused = false;
        }
    }
}
