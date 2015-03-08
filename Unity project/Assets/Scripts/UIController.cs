using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

    public GameObject mainMenu;
    public GameObject HUD;

	// Use this for initialization
	void Start () {
        mainMenu.SetActive(true);
        HUD.SetActive(false);
	}

    public void prepareUIForGameBeginning()
    {
        hideMainMenu();
        showHUD();
    }

    private void hideMainMenu()
    {
        mainMenu.SetActive(false);
    }

    private void showHUD()
    {    
        HUD.SetActive(true);
    }
}
