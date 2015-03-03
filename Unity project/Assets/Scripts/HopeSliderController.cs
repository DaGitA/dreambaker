using UnityEngine;
using System.Collections;

public class HopeSliderController : MonoBehaviour {

    public UnityEngine.UI.Text hopeLevelText;
    public UnityEngine.UI.Slider hopeLevelSlider;

    public void updateHopeLevelText()
    {
        hopeLevelText.text = hopeLevelSlider.value.ToString();
    }
}
