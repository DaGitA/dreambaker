﻿using UnityEngine;
using System.Collections;

public class HopeSliderController : MonoBehaviour {

    public UnityEngine.UI.Text hopeLevelText;
    public UnityEngine.UI.Slider hopeLevelSlider;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void updateHopeLevelText()
    {
        hopeLevelText.text = hopeLevelSlider.value.ToString();
    }
}
