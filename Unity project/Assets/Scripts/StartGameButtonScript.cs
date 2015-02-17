using UnityEngine;
using System.Collections;

public class StartGameButtonScript : MonoBehaviour {

    public GameObject mainMenu;
    public GameController gameController;
    public GameObject HUD;

    public void onClick()
    {
        mainMenu.SetActive(false);
        gameController.unPauseGame();
        HUD.SetActive(true);
    }
}
