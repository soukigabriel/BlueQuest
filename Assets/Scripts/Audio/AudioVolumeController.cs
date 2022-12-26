using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioVolumeController : MonoBehaviour
{
    private AudioSource audioSource;
    private float currentAudioLevel;
    [Range(0.0f, 1.0f)]
    public float defaultAudioLevel;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void SetAudioVolume(float newVolume)
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        currentAudioLevel = defaultAudioLevel * newVolume;
        audioSource.volume = currentAudioLevel;
    }
}
