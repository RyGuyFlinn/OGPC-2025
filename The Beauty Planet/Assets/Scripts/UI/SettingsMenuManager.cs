using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class SettingsMenuManager : MonoBehaviour
{
    public Slider masterVOL, musicVOL, sfxVOL, sensSlider;
    public AudioMixer mainAudioMixer;
    
    public void ChangeMasterVolume()
    {
        mainAudioMixer.SetFloat("MasterVLM", masterVOL.value);
    }

    public void ChangeMusicVolume()
    {
        mainAudioMixer.SetFloat("MusicVLM", musicVOL.value);
    }

    public void ChangeSFXVolume()
    {
        mainAudioMixer.SetFloat("SFXVLM", sfxVOL.value);
    }

    public void ChangeSensVolume()
    {
        hotbar.sensitivityThreshold = sensSlider.value;
    }
}
