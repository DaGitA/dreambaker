using UnityEngine;
using System.Collections;

public class CrazynessLevelSliderController : MonoBehaviour {

    //private System.Collections.Generic.List<spawnArea> spawnAreaList;
    private spawnArea[] spawnAreaList;
    private GameController gameController;

	// Use this for initialization
	void Start () {
        spawnArea[] bob = FindObjectsOfType(typeof(spawnArea)) as spawnArea[];
        spawnAreaList = bob;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void onValueChanged(float newSliderValue)
    {
        foreach (spawnArea currentSpawnArea in spawnAreaList)
        {
            gameController.setCrazynessLevelValue(newSliderValue);
        }        
    }
}
