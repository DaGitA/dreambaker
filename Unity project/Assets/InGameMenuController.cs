using UnityEngine;
using UnityEngine.UI;
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
            showInGameMenu();            
        }
        else if (Input.GetKeyDown("escape") & isPaused)
        {
            hideInGameMenu();
        }
    }

    private void hideInGameMenu()
    {
        isPaused = false;
        CanvasGroup menuCanvasGroup = GetComponent<CanvasGroup>();
        menuCanvasGroup.alpha = 0;
    }

    private void showInGameMenu()
    {
        isPaused = true;
        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.alpha = 1;
    }
}
