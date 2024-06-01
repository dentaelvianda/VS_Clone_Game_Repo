using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Turret : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefabs;
    [SerializeField] private Transform projectilePos;
    [SerializeField] private float projectileSpeed;

    private Transform target;
    private float shootingCooldown = 3f;
    private float shootingCounter;

    private void Start()
    {
        target = FindObjectOfType<Player>().transform;
    }

    private void Update()
    {
        if (target == null) { return; }

        shootingCounter += Time.deltaTime;
        AimToTarget();
        if (shootingCounter > shootingCooldown && Vector3.Distance(transform.position, target.position) < 20f)
        {
            shootingCounter = 0f;
            FireProjectile();
        }

    }

    private void AimToTarget()
    {
        Vector3 aimDirection = (target.transform.position - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        transform.eulerAngles = new Vector3(0f, 0f, angle);
    }

    private void FireProjectile()
    {
        GameObject projectileSpawned = Instantiate(projectilePrefabs, projectilePos.position, projectilePos.rotation);
        Rigidbody2D rigidbody2D = projectileSpawned.GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(projectilePos.up * projectileSpeed, ForceMode2D.Impulse);
    }
}
