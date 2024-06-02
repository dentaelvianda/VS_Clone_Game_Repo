using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerAnimator : MonoBehaviour
{
    private Animator _animator;
    [SerializeField] private PlayerMovement player;
    private const string _horizontal = "Horizontal";
    private const string _vertical = "Vertical";
    private const string _lastHorizontal = "LastHorizontal";
    private const string _lastVertical = "LastVertical";
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _animator.SetFloat(_horizontal, player.Movement().x);
        _animator.SetFloat(_vertical, player.Movement().y);

        if(player.Movement() != Vector2.zero)
        {
            _animator.SetFloat(_lastHorizontal, player.Movement().x);
            _animator.SetFloat(_lastVertical, player.Movement().y);
        }
    }
}
