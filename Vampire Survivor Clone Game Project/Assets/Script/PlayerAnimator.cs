using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    public const string HORIZONTAL = "Horizontal";
    public const string VERTICAL = "Vertical";
    public const string LAST_VERTICAL_DIR = "LastVerticalDir";
    public const string LAST_HORIZONTAL_DIR = "LastHorizontalDir";

    private enum PlayerAnimationType
    {
        LookAtMouse,
        LookAtInputDirection
    }

    [SerializeField] private Player player;
    [SerializeField] PlayerAnimationType playerAnimationType;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        switch (playerAnimationType)
        {
            case PlayerAnimationType.LookAtMouse:
                LookAtMouseAnimation();
                break;
            case PlayerAnimationType.LookAtInputDirection:
                LookAtInputDirectionAnimation();
                break;
        }
    }

    private void LookAtMouseAnimation()
    {
        Vector2 mouseDirection = player.GetMouseDirection();
        Vector2 moveDirection = player.GetMoveDirection();

        if (moveDirection != Vector2.zero)
        {
            animator.SetFloat(HORIZONTAL, mouseDirection.x);
            animator.SetFloat(VERTICAL, mouseDirection.y);

            animator.SetFloat(LAST_HORIZONTAL_DIR, mouseDirection.x);
            animator.SetFloat(LAST_VERTICAL_DIR, mouseDirection.y);
        }
        else
        {
            animator.SetFloat(HORIZONTAL, 0);
            animator.SetFloat(VERTICAL, 0);
        }
    }

    private void LookAtInputDirectionAnimation()
    {
        animator.SetFloat(HORIZONTAL, player.GetMoveDirection().x);
        animator.SetFloat(VERTICAL, player.GetMoveDirection().y);

        if (player.GetMoveDirection() != Vector2.zero)
        {
            animator.SetFloat(LAST_HORIZONTAL_DIR, player.GetMoveDirection().x);
            animator.SetFloat(LAST_VERTICAL_DIR, player.GetMoveDirection().y);
        }
    }
}
