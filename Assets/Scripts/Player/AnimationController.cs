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
        _animator.SetFloat("VelocityY", velocityY);

        if (jumping)
        {
            if (velocityY < -0.4)
            {
                _animator.SetBool("Jump", false);
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
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("DeathTrigger"))
        {
            StartCoroutine(Die());
        }
    }
}
