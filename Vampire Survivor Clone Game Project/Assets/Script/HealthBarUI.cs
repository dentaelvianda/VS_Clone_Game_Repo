using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [SerializeField] private Health hasHealthGameObject;
    [SerializeField] private Image barImage;

    private void Start()
    {
        hasHealthGameObject.OnHealthDecreased += HasHealthGameObject_OnHealthDecreased;
        barImage.fillAmount = 1f;
    }

    private void HasHealthGameObject_OnHealthDecreased(object sender, Health.OnHealthDecreasedEventArgs e)
    {
        barImage.fillAmount = e.healthBar;
    }
}
