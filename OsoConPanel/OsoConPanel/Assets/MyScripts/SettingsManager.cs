using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class SettingsManager : MonoBehaviour {

    public Slider volumeSlider;
    public AudioMixer audioMixer;

    public void SubirVol()
    {
        if (volumeSlider.value < 10)
        {
            volumeSlider.value += 10;
            audioMixer.SetFloat("volume",volumeSlider.value);
        }
    }

    public void BajarVol()
    {
        if (volumeSlider.value > -50)
        {
            volumeSlider.value -= 10;
            audioMixer.SetFloat("volume", volumeSlider.value);
        }
    }

    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);

    }

}
