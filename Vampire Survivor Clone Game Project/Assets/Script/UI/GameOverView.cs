using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverView : MonoBehaviour
{
    public GameObject gameOverPanel;
    public Button retryButton;
    public Button mainMenuButton;

    private void Start()
    {
        retryButton.onClick.AddListener(OnRetryButtonClicked);
        mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        gameOverPanel.SetActive(false);
    }

    public void ShowGameOver()
    {
        gameOverPanel.SetActive(true);
    }

    private void OnRetryButtonClicked()
    {
        gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload the current scene
    }

    private void OnMainMenuButtonClicked()
    {
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene("MainMenu"); // Load the main menu scene
    }
}