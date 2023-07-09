using System;
using Player;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _player;
    private PlayerController _playerController;
    private bool onGround;

    private bool jumping = false;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Rigidbody2D>();
        _playerController = GetComponent<PlayerController>();
    }

    private void FixedUpdate()
    {
        if (jumping)
        {
            float velocityY = _player.velocity.y;
            if (velocityY < -0.01f)
            {
                _animator.SetFloat("Velocity", velocityY);
                onGround = _playerController.IsGrounded();
            }
            else if (onGround)
            {
                _animator.SetFloat("Velocity", velocityY);
                _animator.SetBool("OnGround", onGround);
                jumping = false;
            }
        }

        if (Math.Abs(_player.velocity.x) > 0.01f)
        {
            _animator.SetBool("IsRunning", true);
        }
        else
        {
            _animator.SetBool("IsRunning",false);
        }
    }

    public void JumpAnimation()
    {
        if (_player.velocity.y > 0.01f)
        {
            jumping = true;
            _animator.SetTrigger("Jump");
        }
       
    }

    public void RunAnimation(float velocity)
    {
        if(Math.Abs(velocity) > 0)
            _animator.SetBool("IsRunning", true);
        else if(Math.Abs(velocity) < 0.01f)
            _animator.SetBool("IsRunning", false);
    }

    public void Die()
    {
        _animator.SetBool("IsDead", true);
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
    }
}
