using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    private AudioManager audioManager;
    public int newTrackID;
    public bool playOnStart;
    // Start is called before the first frame update
    void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        if(audioManager)
        {
            if (playOnStart)
            {
                if(audioManager.currentTrack != newTrackID || (audioManager.currentTrack == newTrackID && !audioManager.audioTracks[audioManager.currentTrack].isPlaying))
                {
                    audioManager.PlayNewTrack(newTrackID);
                }
            }
        }
        else
        {
            Debug.LogWarning("AudioManager could not be loaded");
        }
    }
}
