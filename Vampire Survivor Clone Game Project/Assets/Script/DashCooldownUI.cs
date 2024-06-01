using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashCooldownUI : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private Image barImage;

    private void Start()
    {
        player.OnDashCooldown += Player_OnDashCooldown;
        barImage.fillAmount = 0f;
    }

    private void Player_OnDashCooldown(object sender, Player.OnDashCooldownEventArgs e)
    {
        barImage.fillAmount = e.dashCounter;

        if(e.dashCounter <= 0f || e.dashCounter >=1f)
        {
            Hide();
        }
        else
        {
            Show();
        }
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Show()
    {
        gameObject.SetActive(true);
    }
}
