using UnityEngine;
using System.Collections;

public class InGameMenuController : MonoBehaviour {

    private bool isPaused = new bool();

	// Use this for initialization
	void Start () {
        isPaused = false;
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
