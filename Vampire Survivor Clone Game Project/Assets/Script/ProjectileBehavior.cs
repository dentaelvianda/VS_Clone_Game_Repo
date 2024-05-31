using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ProjectileBehavior : MonoBehaviour
{

    [SerializeField] private float projectileDamage;

    private void Start()
    {
        Destroy(gameObject, 1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            health.Hit(projectileDamage);
        }
        Destroy(gameObject);
    }
}
