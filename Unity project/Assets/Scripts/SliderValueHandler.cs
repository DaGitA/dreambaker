using UnityEngine;
using System.Collections;

public class SliderValueHandler : MonoBehaviour {
    private UnityEngine.UI.Slider crazinessLevelSlider;
    private UnityEngine.UI.Text crazinessLevelText;

    void Start()
    {
        //this.OnValueChanged();
        //gameObject .onValueChanged.AddListener(ListenerMethod);
        crazinessLevelSlider = GameObject.Find("CrazynessSlider").GetComponent<UnityEngine.UI.Slider>();
        crazinessLevelText = GameObject.FindGameObjectWithTag("crazynessLevelText").GetComponent<UnityEngine.UI.Text>();
    }

    public void changeCrazinessText(){
        crazinessLevelText.text = crazinessLevelSlider.value.ToString();
    }
}
