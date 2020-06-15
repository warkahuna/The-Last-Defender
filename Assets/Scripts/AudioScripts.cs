using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioScripts : MonoBehaviour
{
    public AudioMixer audioMixer;
    public AudioMixer audioMixerMusic;
    public AudioMixer audioMixerSFX;
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("master", volume);
    }
    public void setVolumeMusic(float volume)
    {
        audioMixerMusic.SetFloat("master", volume);
    }
    public void setVolumeSFX(float volume)
    {
        audioMixerSFX.SetFloat("master", volume);
    }
}
