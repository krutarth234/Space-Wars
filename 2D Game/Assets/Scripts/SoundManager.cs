using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}
public class SoundManager : MonoBehaviour
{
    public Sound[] MUSIC, SFX;
    public AudioSource MUSIC_Source, SFX_Source;

    private void Start()
    {
        PlayMusic("BackGround");
    }

    public void PlayMusic(string name)
    {
        Sound s = null;
        foreach (var sound in MUSIC)
        {
            if (sound.name == name)
            {
                s = sound;
                MUSIC_Source.clip = s.clip;
                MUSIC_Source.Play();
                break;
            }
        }
    }

    public void ToggleMusicMute(bool mute)
    {
        MUSIC_Source.volume = mute ? 0f : 1f;
    }

    public void PlaySFX(string name)
    {
        Sound s = null;
        foreach (var sound in SFX)
        {
            if (sound.name == name)
            {
                s = sound;
                SFX_Source.PlayOneShot(s.clip);
                break;
            }
        }
    }

    //public void ToggleMusic()
    //{
    //    MUSIC_Source.mute = !MUSIC_Source.mute;
    //}
    //public void ToggleSFX()
    //{
    //    SFX_Source.mute = !SFX_Source.mute;
    //}
    public void SetMusicVolume(float volume)
    {
        MUSIC_Source.volume = volume;
    }
    public void SetSFXVolume(float volume)
    {
        SFX_Source.volume = volume;
    }
    public void SetMasterVolume(float volume)
    {
        //
        AudioListener.volume = volume;
    }
    public void SetPanning(float pan)
    {
        //
        MUSIC_Source.panStereo = pan;
        SFX_Source.panStereo = pan;
    }

}
