using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    [SerializeField] private float damageDealt;
    [SerializeField] private float damageInterval;

    private bool isCollidingWithPlayer = false;
    private Coroutine damageCoroutine;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            if (!isCollidingWithPlayer)
            {
                isCollidingWithPlayer = true;
                damageCoroutine = StartCoroutine(DealDamage(other.gameObject.GetComponent<Health>()));
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.GetComponent<Player>())
        {
            if (isCollidingWithPlayer)
            {
                isCollidingWithPlayer = false;
                if (damageCoroutine != null)
                {
                    StopCoroutine(damageCoroutine);
                }
            }
        }
    }

    private IEnumerator DealDamage(Health playerHealth)
    {
        while (isCollidingWithPlayer)
        {
            playerHealth.Hit(damageDealt);
            yield return new WaitForSeconds(damageInterval);
        }
    }
}
