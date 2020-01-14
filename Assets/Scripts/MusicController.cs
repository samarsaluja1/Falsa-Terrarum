using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    //Variables
    public static bool mcExists;
    public AudioSource[] musicTracks;
    public int currentTrack;
    public bool musicCanPlay;

    void Start()
    {
        //Creates a Music Controller if one doesn't Exist in the Scene
        if (!mcExists)
        {
            mcExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else { Destroy(gameObject); }
    }

    void Update()
    {
        //Music Control - Sets Music to On or Off
        if (musicCanPlay)
        {
            if (!musicTracks[currentTrack].isPlaying)
            {
                musicTracks[currentTrack].Play();
            }
        }
        else
        {
            musicTracks[currentTrack].Stop();
        }
    }

    //Function to Change Current Playing Track
    public void SwitchTrack(int newTrack)
    {
        musicTracks[currentTrack].Stop();
        currentTrack = newTrack;
        musicTracks[currentTrack].Play();
    }
}
