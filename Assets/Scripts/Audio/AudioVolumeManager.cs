using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    // Start is called before the first frame update
    void Start()
    {
        audioVolumeControllers = transform.Find(audioManagerName).GetComponentsInChildren<AudioVolumeController>();
        sfxVolumeControllers = transform.Find(sfxManagerName).GetComponentsInChildren<AudioVolumeController>();
        ChangeVolume();
    }

    private void Update()
    {
        ChangeVolume();
    }

    public void ChangeVolume()
    {
        currentAudioVolumeLevel = Mathf.Clamp(currentAudioVolumeLevel, 0 , maxVolumeLevel);
        currentSFXVolumeLevel = Mathf.Clamp(currentSFXVolumeLevel, 0, maxVolumeLevel);

        foreach (AudioVolumeController avc in audioVolumeControllers)
        {
            avc.SetAudioVolume(currentAudioVolumeLevel);
        }
        foreach (AudioVolumeController sfxvc in sfxVolumeControllers)
        {
            sfxvc.SetAudioVolume(currentSFXVolumeLevel);
        }
    }
}
