using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource source;
    public AudioClip shot;
    public AudioClip explosion;

    private Dictionary<string, AudioClip> audioClips;

    void Start()
    {
        source = GameObject.Find("Audio Source").GetComponent<AudioSource>();

        // Inicjalizacja s³ownika i przypisanie AudioClipów
        audioClips = new Dictionary<string, AudioClip>
        {
            { "shot", shot },
            { "explosion", explosion }
        };

        GameManager.audioManager = this;
    }

    public void Play(string clipName, float volume)
    {
        if (audioClips.TryGetValue(clipName.ToLower(), out AudioClip clip))
        {
            source.PlayOneShot(clip, volume);
        }
    }
}
