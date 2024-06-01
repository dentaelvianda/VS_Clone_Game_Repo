using UnityEngine;

[CreateAssetMenu(fileName = "SettingsModel", menuName = "ScriptableObjects/SettingsModel", order = 1)]
public class SettingsModel : ScriptableObject
{
    public float musicVolume = 1.0f;
    public float sfxVolume = 1.0f;
    public bool isMuted = false;
}