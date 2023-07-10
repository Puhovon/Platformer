using System;
using System.Collections;
using Player;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AnimationController : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _player;
    private PlayerController _playerController;
    private Healt _health;
    private bool onGround;

    private bool jumping = false;
    private bool fall = false;
    private void ResetLanding() => _animator.SetBool("IsLanding", false);
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GetComponent<Rigidbody2D>();
        _playerController = GetComponent<PlayerController>();
        _health = GetComponent<Healt>();
    }

    private void Update()
    {
        if (_health.CurrentHealth <= 0)
        {
            StartCoroutine(Die());
        }
        
    }

    private void FixedUpdate()
    {
        float velocityY = _player.velocity.y;

        if (velocityY < -0.4)
            fall = true;
        if (jumping || fall )
        {
            if (velocityY < -0.4)
            {
                Debug.Log("IsFalling");
                _animator.SetBool("Jump", false);
                _animator.SetBool("IsFalling", true);
                onGround = _playerController.IsGrounded();
            }
            else if (velocityY == 0 || onGround)
            {
                _animator.SetBool("IsFalling", false);
                _animator.SetBool("IsLanding", true);
                jumping = false;
                fall = !fall;
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
        if (_player.velocity.y > 0.2)
        {
            jumping = true;
            _animator.SetBool("Jump", true);
        }
       
    }
    
    
    public void RunAnimation(float velocity)
    {
        if(Math.Abs(velocity) > 0)
            _animator.SetBool("IsRunning", true);
        else if(Math.Abs(velocity) < 0.01f)
            _animator.SetBool("IsRunning", false);
    }

    public IEnumerator Die()
    {
        _animator.SetTrigger("Die");
        yield return new WaitForSeconds(2);
    }

    public void Attack()
    {
        _animator.SetTrigger("Attack");
    }
}
