using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    [SerializeField] private Health health;

    private TextMeshProUGUI textMeshPro;

    private void Start()
    {
        textMeshPro = gameObject.GetComponent<TextMeshProUGUI>();
        health.OnHealthDecreased += Health_OnHealthDecreased;
    }

    private void Health_OnHealthDecreased(object sender, Health.OnHealthDecreasedEventArgs e)
    {
        textMeshPro.text = e.currentHealth.ToString() + "/" + e.maxHealth.ToString();
    }
}
