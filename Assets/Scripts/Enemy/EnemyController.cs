using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float timeToRevert;
    

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _enemyRigidbody;
    private Healt health;

    private const float IdleState = 0;
    private const float WalkState = 1;
    private const float RevertState = 2;

    private float currentState;
    private float currentTimeToRevert;
    private float damage = 35;
    
    private void Awake()
    {
        _enemyRigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        health = GetComponent<Healt>();
        currentState = WalkState;
    }

    private void Update()
    {
        if (health.CheckIsDead())
        {
            StartCoroutine(Die());
        }
        else
        {
            if (currentTimeToRevert >= timeToRevert)
            {
                currentState = RevertState;
                currentTimeToRevert = 0;
            }
            
            switch (currentState)
            {
                case IdleState:
                    currentTimeToRevert += Time.deltaTime;
                    break;
                case WalkState:
                    _enemyRigidbody.velocity = Vector2.left * speed;
                    break;
                case RevertState:
                    _spriteRenderer.flipX = !_spriteRenderer.flipX;
                    speed *= -1;
                    currentState = WalkState;
                    break;
            }
            _animator.SetFloat("Velocity", _enemyRigidbody.velocity.magnitude);
        } 
    }

    private IEnumerator Die()
    {
        Debug.Log("DIE");
        _animator.SetBool("IsDie", true);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("EnemyStopper"))
            currentState = IdleState;
        if(other.CompareTag("Player"))
            _animator.SetTrigger("Attack");
    }
}
