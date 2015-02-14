using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InGameMenuController : MonoBehaviour {

    public GameObject inGameMenu;
    public GameController gameController;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        checkIfInGameMenuIsTriggered();
	}

    private void checkIfInGameMenuIsTriggered()
    {
        
        if (Input.GetKeyDown("escape") & !gameController.gameIsPaused())
        {
            inGameMenu.SetActive(true);
            gameController.pauseGame();
        }
        else if (Input.GetKeyDown("escape") & gameController.gameIsPaused())
        {
            inGameMenu.SetActive(false);
            gameController.unPauseGame();
        }
    }
}
