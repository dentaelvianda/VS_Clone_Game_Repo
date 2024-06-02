using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    public Button playButton;
    public Button settingsButton;
    public Button quitButton;

    public TextMeshProUGUI playButtonText;
    public TextMeshProUGUI settingsButtonText;
    public TextMeshProUGUI quitButtonText;

    public GameObject mainMenuPanel; // Panel untuk main menu
    public GameObject settingsPanel; // Panel untuk menu settings

    public void SetButtonLabels(string playText, string settingsText, string quitText)
    {
        playButtonText.text = playText;
        settingsButtonText.text = settingsText;
        quitButtonText.text = quitText;
    }

    public void AddPlayButtonListener(UnityEngine.Events.UnityAction action)
    {
        playButton.onClick.AddListener(action);
    }

    public void AddSettingsButtonListener(UnityEngine.Events.UnityAction action)
    {
        settingsButton.onClick.AddListener(action);
    }

    public void AddQuitButtonListener(UnityEngine.Events.UnityAction action)
    {
        quitButton.onClick.AddListener(action);
    }

    public void ShowMainMenu(bool show)
    {
        mainMenuPanel.SetActive(show);
    }

    public void ShowSettingsMenu(bool show)
    {
        settingsPanel.SetActive(show);
    }
}