using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuMusic : MonoBehaviour
{
    public static AudioClip mainTheme;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        mainTheme = Resources.Load<AudioClip>("MainTheme");
        // AudioSource to play AudioClips
        audioSrc = GetComponent<AudioSource>();
    }

    // Function to play another background soundtrack
    public static void playMyBackgroundAudio(AudioClip clipToPlay)
    {
        audioSrc.clip = clipToPlay;
        audioSrc.Play();
    }

    // Function to stop audio
    public static void stopMyAudio()
    {
        audioSrc.Stop();
    }
}
