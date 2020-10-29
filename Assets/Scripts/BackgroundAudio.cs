using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BackgroundAudio : MonoBehaviour
{

    public static AudioClip darkForest, waterfalls, peacefulMountains, 
                            rockyHills, coin, death, mainTheme;
    static AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        // AudioClips for different backgrounds
        darkForest = Resources.Load<AudioClip>("DarkForest");
        rockyHills = Resources.Load<AudioClip>("RockyHills");
        peacefulMountains = Resources.Load<AudioClip>("PeacefulMountains");
        waterfalls = Resources.Load<AudioClip>("Waterfalls");

        mainTheme = Resources.Load<AudioClip>("MainTheme");

        // Other game's AudioClips
        coin = Resources.Load<AudioClip>("Coin");
        death = Resources.Load<AudioClip>("GameOverDeath");

        // AudioSource to play AudioClips
        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Function to play another background soundtrack
    public static void playMyBackgroundAudio(AudioClip clipToPlay)
    {
        Debug.Log(clipToPlay);
        if (clipToPlay != null)
        {
            Debug.Log("it's not null");
            audioSrc.clip = clipToPlay;
            stopMyAudio();
            audioSrc.Play();
        }
        else
        {
            Debug.Log("i'ts null");
        }
        
    }

    // Function to stop audio
    public static void stopMyAudio()
    {
        audioSrc.Stop();
    }

    // Function which does the sound managing
    public static void PlaySound(string clip) {
        switch (clip) {
            case "MainTheme":
                //playMyBackgroundAudio(mainTheme);
                break;
            case "DarkForest": 
                playMyBackgroundAudio(darkForest);
                break;
            case "RockyHills":
                Debug.Log("playing rocky hills");
                playMyBackgroundAudio(rockyHills);
                break;
            case "PeacefulMountains":
                Debug.Log("playing mountains");
                playMyBackgroundAudio(peacefulMountains);
                break;
            case "Waterfalls":   
                playMyBackgroundAudio(waterfalls);
                break;
            case "Coin": 
                audioSrc.PlayOneShot(coin);
                break;
            case "Death":
                audioSrc.PlayOneShot(death);
                break;
        }
    }
}
