using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameInput gameInput;
    [SerializeField] private Transform projectilePrefabs;
    [SerializeField] private Transform projectilePos;

    [SerializeField] private float projectileSpeed = 50f;
 
    private void Start()
    {
        gameInput.OnFire += GameInput_OnFire;
    }

    private void Update()
    {
        AimToMousePosition();
    }

    private void AimToMousePosition()
    {
        Vector3 mousePos = gameInput.GetMousePosition();

        Vector3 aimDirection = (mousePos - transform.position).normalized;
        float angle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0f, 0f, angle);
    }

    private void GameInput_OnFire(object sender, System.EventArgs e)
    {

        Instantiate(projectilePrefabs, projectilePos.transform.position, Quaternion.identity);
    }

}
