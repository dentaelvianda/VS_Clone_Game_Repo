using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private GameObject projectilePrefabs;
    [SerializeField] private Transform projectilePos;

    [SerializeField] private float projectileSpeed;

    private Vector3 mousePos;


    private void Start()
    {
        gameInput.OnFire += GameInput_OnFire;
    }

    private void OnDisable()
    {
        gameInput.OnFire -= GameInput_OnFire;
    }

    private void Update()
    {
        AimToMousePosition();
    }


    //===========================Rotate Weapon Based On Mouse Position=============================
    private void AimToMousePosition()
    {
        mousePos = gameInput.GetMousePosition();
        Vector3 aimDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg -90f;
        transform.eulerAngles = new Vector3(0f, 0f, angle);
    }


    //============================Fire Projectile On Right Click Mouse=============================
    private void GameInput_OnFire(object sender, System.EventArgs e)
    {
        GameObject projectileSpawned = Instantiate(projectilePrefabs, projectilePos.position, projectilePos.rotation);
        Rigidbody2D rigidbody2D = projectileSpawned.GetComponent<Rigidbody2D>();
        rigidbody2D.AddForce(projectilePos.up * projectileSpeed, ForceMode2D.Impulse);
    }

}
