using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class VolumeControl : MonoBehaviour
{   
    //get mixer (bgm, game, sfx)
    public AudioMixer mixer;
    public Slider inputSlider;
    public TMP_Text volumeText;
    //exposed mixer name from mixer
    public string mixerName;

    private const float MinDecibels = -80f;
    private const float DefaultVolumeDb = 0f; // Default volume set to 0 dB

    void Start()
    {
        if (inputSlider != null)
        {
            inputSlider.onValueChanged.AddListener(SetLevel);

            //set mixer to the default volume
            mixer.SetFloat(mixerName, DefaultVolumeDb);

            //set the slider to reflect 100% volume (1 = 100)
            inputSlider.value = 1; 

            UpdateVolumeText();
        }
    }

    public void SetLevel(float sliderValue)
    {
        //set slider level based on decibels (silence to normal)
        float dB = MinDecibels * (1 - sliderValue);
        mixer.SetFloat(mixerName, dB);
        UpdateVolumeText();
    }

    private void UpdateVolumeText()
    {
        //convert to % (1 = 100 etc)
        volumeText.text = $"{Mathf.RoundToInt(inputSlider.value * 100)}%";
    }
}
