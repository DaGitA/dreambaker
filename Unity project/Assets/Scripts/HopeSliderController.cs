using UnityEngine;
using System.Collections;

public class HopeSliderController : MonoBehaviour {

    public UnityEngine.UI.Text hopeLevelText;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void updateHopeLevelText()
    {
        UnityEngine.UI.Slider hopeLevelSlider = GetComponentInParent<UnityEngine.UI.Slider>();
        hopeLevelText.text = hopeLevelSlider.value.ToString();
    }
}
