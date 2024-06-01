using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public static Player Instance { get; private set; }

    public event EventHandler<OnDashCooldownEventArgs> OnDashCooldown;
    public class OnDashCooldownEventArgs : EventArgs
    {
        public float dashCounter;
        public float dashCooldown;
    }

    [SerializeField] private GameInput gameInput;

    [Header("Player Ability")]
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float dashCooldown = 2f;
    [SerializeField] private float dashDistance = 5f;
    [SerializeField] private LayerMask dashLayerMask;

    private Vector3 moveDir;
    private Rigidbody2D rigidBody2D;
    private float dashCounter;
    private TrailRenderer trailRenderer;

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("There's more than one instance");
        }
        Instance = this;
    }

    private void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        trailRenderer = GetComponent<TrailRenderer>();

        dashCounter = dashCooldown;
        gameInput.OnDash += GameInput_OnDash;
    }

    private void Update()
    {
        dashCounter += Time.deltaTime;

        OnDashCooldown?.Invoke(this, new OnDashCooldownEventArgs
        {
            dashCounter = dashCounter / dashCooldown
        });

        HandleInput();
    }

    private void FixedUpdate()
    {
        ProcessMovement();
    }


    //===========================MOVEMENT==============================\\
    private void HandleInput()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        moveDir = new Vector3(inputVector.x, inputVector.y, 0f);
    }

    private void ProcessMovement()
    {
        rigidBody2D.velocity = new Vector2(moveDir.x * moveSpeed, moveDir.y * moveSpeed);
    }
    //==============================================================\\




    //===========================DASH==============================\\
    private void GameInput_OnDash(object sender, System.EventArgs e)
    {
        if (dashCounter >= dashCooldown)
        {
            dashCounter = 0f;

            

            Vector3 dashPosition = transform.position + moveDir * dashDistance;


            RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, moveDir, dashDistance, dashLayerMask);
            if (raycastHit2D.collider != null)
            {
                dashPosition = raycastHit2D.point;
            }

            trailRenderer.emitting = true;
            rigidBody2D.MovePosition(dashPosition);
            StartCoroutine(TrailEnabler());
        }
    }

    private IEnumerator TrailEnabler()
    {
        yield return new WaitForSeconds(0.1f);
        trailRenderer.emitting = false;
    }
    //==============================================================\\


    public Vector2 GetMoveDirection()
    {
        return moveDir;
    }
}

