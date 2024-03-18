using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    public Slider MUSIC_Slider, SFX_Slider, MASTER_Slider, PANNING_Slider;

    public void MusicSlider()
    {
        MainController.Instance.SoundManager.SetMusicVolume(MUSIC_Slider.value);
    }
    public void SFXSlider()
    {
        MainController.Instance.SoundManager.SetSFXVolume(SFX_Slider.value);
    }
    public void MasterSlider()
    {
        MainController.Instance.SoundManager.SetMasterVolume(MASTER_Slider.value);
    }
    public void PanningSlider()
    {
        MainController.Instance.SoundManager.SetPanning(PANNING_Slider.value);
    }
}