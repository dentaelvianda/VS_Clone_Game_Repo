using UnityEngine;

[CreateAssetMenu(fileName = "MainMenuModel", menuName = "ScriptableObjects/MainMenuModel", order = 1)]
public class MainMenuModel : ScriptableObject
{
    public string playButtonText = "Play";
    public string settingsButtonText = "Settings";
    public string quitButtonText = "Quit";
}