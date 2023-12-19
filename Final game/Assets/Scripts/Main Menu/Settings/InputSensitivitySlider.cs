using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class SliderValueConnector : MonoBehaviour
{
    //input slider will be attached
    public Slider inputSlider;

    //we access and set sensitivity variables here
    public MouseLook mouseLook;

    //to display sensitivity
    public TMP_Text sensitivityText;

    void Start()
    {
        //initialise slider value to mouse look sensitivity
        inputSlider.value = mouseLook.getSensitivity();
        
        //change text to reflect value
        sensitivityText.text = $"{inputSlider.value}";
        
        //add event for value change of slider
        inputSlider.onValueChanged.AddListener(delegate { ValueChanged(); });
    }

    // This method is called whenever the slider's value changes
    void ValueChanged()
    {
        //ensure sensitivity is matched to slider
        mouseLook.changeSensitivity(inputSlider.value);

        Debug.Log(inputSlider.value);
        
        //change text to reflect value
        sensitivityText.text = $"{inputSlider.value}";
    }
}