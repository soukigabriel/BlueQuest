using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class AudioManager : MonoBehaviour
{
    public AudioSource[] audioTracks;
    public int currentTrack;
    public float audioVolume;

    public void PlayNewTrack(int newTrack)
    {
        audioTracks[currentTrack].Stop();
        currentTrack = newTrack;
        audioTracks[currentTrack].Play();
        audioTracks[currentTrack].volume = 0f;
        DOTween.To(() => audioTracks[currentTrack].volume, x => audioTracks[currentTrack].volume = x, audioTracks[currentTrack].gameObject.GetComponent<AudioVolumeController>().defaultAudioLevel, 5);
    }
}
