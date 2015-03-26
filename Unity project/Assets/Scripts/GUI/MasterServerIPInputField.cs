using UnityEngine;
using System.Collections;

public class MasterServerIPInputField : MonoBehaviour {
    public UnityEngine.UI.InputField masterServerInputField;
    public NetworkManager networkManager;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void onEndEdit()
    {
        networkManager.setMasterServerIP(masterServerInputField.text);
    }
}
