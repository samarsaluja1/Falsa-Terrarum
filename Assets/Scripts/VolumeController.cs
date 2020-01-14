using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    //Variables
    public AudioMixer audioMixer;

    //Updates Music Volume According to Slider
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
