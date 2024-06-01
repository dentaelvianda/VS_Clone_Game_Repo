using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{

    public const string HORIZONTAL = "Horizontal";
    public const string VERTICAL = "Vertical";
    public const string LAST_VEVERTICAL_DIR = "LastVerticalDir";
    public const string LAST_HORIZONTAL_DIR = "LastHorizontalDir";

    [SerializeField] private Player player;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        animator.SetFloat(HORIZONTAL, player.GetMoveDirection().x);
        animator.SetFloat(VERTICAL, player.GetMoveDirection().y);

        if (player.GetMoveDirection() != Vector2.zero)
        {
            animator.SetFloat(LAST_HORIZONTAL_DIR, player.GetMoveDirection().x);
            animator.SetFloat(LAST_VEVERTICAL_DIR, player.GetMoveDirection().y);
        }


    }
}
