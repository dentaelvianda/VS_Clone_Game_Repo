using UnityEngine;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource musicSource;
    public SettingsModel settingsModel;

    public int sfxPoolSize = 10;
    private List<AudioSource> sfxSources = new List<AudioSource>();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ApplySettings();
    }

    public void ApplySettings()
    {
        musicSource.volume = settingsModel.musicVolume * (settingsModel.isMuted ? 0 : 1);
        foreach (var sfxSource in sfxSources)
        {
            sfxSource.volume = settingsModel.sfxVolume * (settingsModel.isMuted ? 0 : 1);
            sfxSource.mute = settingsModel.isMuted;
        }
        musicSource.mute = settingsModel.isMuted;
    }

    public void PlayMusic(AudioClip clip)
    {
        musicSource.clip = clip;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip, Vector3 position)
    {
        GameObject sfxObject = new GameObject("SFX");
        sfxObject.transform.position = position;
        AudioSource sfxSource = sfxObject.AddComponent<AudioSource>();
        sfxSource.clip = clip;
        sfxSource.volume = settingsModel.sfxVolume * (settingsModel.isMuted ? 0 : 1);
        sfxSource.spatialBlend = 1.0f; // This makes the sound 3D
        sfxSource.Play();
        Destroy(sfxObject, clip.length); // Destroy the object after the clip finishes
    }

    public void SetMusicVolume(float volume)
    {
        settingsModel.musicVolume = volume;
        ApplySettings();
    }

    public void SetSFXVolume(float volume)
    {
        settingsModel.sfxVolume = volume;
        ApplySettings();
    }

    public void SetMute(bool isMuted)
    {
        settingsModel.isMuted = isMuted;
        ApplySettings();
    }
}
