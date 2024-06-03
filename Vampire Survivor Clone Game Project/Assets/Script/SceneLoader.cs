using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private GameOverView gameOverView;

    private void Start()
    {
        playerHealth.OnPlayerDeath += PlayerHealth_OnPlayerDeath;
    }

    private void PlayerHealth_OnPlayerDeath(object sender, System.EventArgs e)
    {
        gameOverView.ShowGameOver();
    }
}
