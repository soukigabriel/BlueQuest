using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioVolumeManager : MonoBehaviour
{
    private AudioVolumeController[] audioVolumeControllers;
    private AudioVolumeController[] sfxVolumeControllers;
    [Range(0.0f, 1.0f)]
    public float currentAudioVolumeLevel;
    [Range(0.0f, 1.0f)]
    public float currentSFXVolumeLevel;
    public float maxVolumeLevel;
    public const string audioManagerName = "AudioManager";
    public const string sfxManagerName = "SFX_Manager";
    public Slider[] audioSliders;



    // Start is called before the first frame update
    void Start()
    {
        foreach (Slider audioSlider in audioSliders)
        {
            audioSlider.maxValue = maxVolumeLevel;
            audioSlider.value = currentAudioVolumeLevel;
        }
        audioVolumeControllers = transform.Find(audioManagerName).GetComponentsInChildren<AudioVolumeController>();
        sfxVolumeControllers = transform.Find(sfxManagerName).GetComponentsInChildren<AudioVolumeController>();
        ChangeAudioVolume(currentAudioVolumeLevel);
        ChangeSFXVolume();
    }

    public void ChangeAudioVolume(float value)
    {
        currentAudioVolumeLevel = Mathf.Clamp(value, 0, maxVolumeLevel);

        foreach (AudioVolumeController avc in audioVolumeControllers)
        {
            avc.SetAudioVolume(currentAudioVolumeLevel);
        }

        foreach (Slider audioSlider in audioSliders)
        {
            audioSlider.value = currentAudioVolumeLevel;
        }
    }

    public void ChangeSFXVolume()
    {
        currentSFXVolumeLevel = Mathf.Clamp(currentSFXVolumeLevel, 0, maxVolumeLevel);

        foreach (AudioVolumeController sfxvc in sfxVolumeControllers)
        {
            sfxvc.SetAudioVolume(currentSFXVolumeLevel);
        }
    }
}
