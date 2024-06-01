using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuView : MonoBehaviour
{
    public Button backButton;
    public Slider musicVolumeSlider;
    public Slider sfxVolumeSlider;
    public Toggle muteToggle;

    public void AddBackButtonListener(UnityEngine.Events.UnityAction action)
    {
        backButton.onClick.AddListener(action);
    }

    public void AddMusicVolumeSliderListener(UnityEngine.Events.UnityAction<float> action)
    {
        musicVolumeSlider.onValueChanged.AddListener(action);
    }

    public void AddSFXVolumeSliderListener(UnityEngine.Events.UnityAction<float> action)
    {
        sfxVolumeSlider.onValueChanged.AddListener(action);
    }

    public void AddMuteToggleListener(UnityEngine.Events.UnityAction<bool> action)
    {
        muteToggle.onValueChanged.AddListener(action);
    }

    public void SetMusicVolume(float volume)
    {
        musicVolumeSlider.value = volume;
    }

    public void SetSFXVolume(float volume)
    {
        sfxVolumeSlider.value = volume;
    }

    public void SetMute(bool isMuted)
    {
        muteToggle.isOn = isMuted;
    }
}