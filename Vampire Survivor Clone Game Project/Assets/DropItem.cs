using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] private float healthAmount;
    [SerializeField] private AudioClip pickUpItemAudio;

    void Update()
    {
        transform.Rotate(0f, 1f, 0f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Player>())
        {
            other.GetComponent<Health>().IncreaseHealth(healthAmount);
            AudioManager.Instance.PlaySFX(pickUpItemAudio, transform.position);
            Destroy(gameObject);
        }
    }
}
