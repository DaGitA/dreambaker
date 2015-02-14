using UnityEngine;
using System.Collections;

public class StartGameButtonScript : MonoBehaviour {

    public GameObject mainMenu;

    public void onClick()
    {
        mainMenu.SetActive(false);
    }
}
