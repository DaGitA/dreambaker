using UnityEngine;
using System.Collections;

public class SliderValueHandler : MonoBehaviour {
    public UnityEngine.UI.Slider crazinessLevelSlider;
    public UnityEngine.UI.Text crazinessLevelText;

    void Start()
    {
    }

    public void changeCrazinessText(){
        crazinessLevelText.text = crazinessLevelSlider.value.ToString();
    }
}
