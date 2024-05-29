using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ProjectileBehavior : MonoBehaviour
{
    [SerializeField] private float projectileSpeed = 1f;
    [SerializeField] private GameInput gameInput;

    private void Awake()
    {
        gameInput = FindObjectOfType<GameInput>();
    }

    private void Update()
    {
        transform.position += gameInput.GetMousePosition() * projectileSpeed * Time.deltaTime;
    }
}
