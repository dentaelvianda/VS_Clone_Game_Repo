using UnityEngine;

public class MainMenuController : MonoBehaviour
{
    public MainMenuModel mainMenuModel;
    public MainMenuView mainMenuView;
    public SettingsModel settingsModel;
    public SettingsMenuView settingsMenuView;

    private void Start()
    {
        // Set button labels from model data
        mainMenuView.SetButtonLabels(mainMenuModel.playButtonText, mainMenuModel.settingsButtonText, mainMenuModel.quitButtonText);

        // Add button listeners
        mainMenuView.AddPlayButtonListener(OnPlayButtonClicked);
        mainMenuView.AddSettingsButtonListener(OnSettingsButtonClicked);
        mainMenuView.AddQuitButtonListener(OnQuitButtonClicked);
        settingsMenuView.AddBackButtonListener(OnBackButtonClicked);

        // Add settings listeners
        settingsMenuView.AddMusicVolumeSliderListener(OnMusicVolumeChanged);
        settingsMenuView.AddSFXVolumeSliderListener(OnSFXVolumeChanged);
        settingsMenuView.AddMuteToggleListener(OnMuteChanged);

        // Initialize settings UI
        settingsMenuView.SetMusicVolume(settingsModel.musicVolume);
        settingsMenuView.SetSFXVolume(settingsModel.sfxVolume);
        settingsMenuView.SetMute(settingsModel.isMuted);

        // Apply settings to AudioManager
        AudioManager.Instance.SetMusicVolume(settingsModel.musicVolume);
        AudioManager.Instance.SetMute(settingsModel.isMuted);

        // Play main menu music
        AudioManager.Instance.PlayMainMenuMusic();

        // Show main menu by default
        mainMenuView.ShowMainMenu(true);
        mainMenuView.ShowSettingsMenu(false);
    }

    private void OnPlayButtonClicked()
    {
        Debug.Log("Play button clicked");
        LoadingManager.Instance.LoadScene("Game"); 
    }

    private void OnSettingsButtonClicked()
    {
        Debug.Log("Settings button clicked");
        mainMenuView.ShowMainMenu(false);
        mainMenuView.ShowSettingsMenu(true);
    }

    private void OnQuitButtonClicked()
    {
        Debug.Log("Quit button clicked");
        Application.Quit();
    }

    private void OnBackButtonClicked()
    {
        Debug.Log("Back to main menu");
        mainMenuView.ShowMainMenu(true);
        mainMenuView.ShowSettingsMenu(false);
    }

    private void OnMusicVolumeChanged(float volume)
    {
        settingsModel.musicVolume = volume;
        AudioManager.Instance.SetMusicVolume(volume);
    }

    private void OnSFXVolumeChanged(float volume)
    {
        settingsModel.sfxVolume = volume;
        AudioManager.Instance.SetSFXVolume(volume);
    }

    private void OnMuteChanged(bool isMuted)
    {
        settingsModel.isMuted = isMuted;
        AudioManager.Instance.SetMute(isMuted);
    }
}
