using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        [Header("Movement vars")]
        [SerializeField] private float jumpForce = 3;
        [SerializeField] private float speed;
        [SerializeField] private bool isGrounded = false;

        [Header("Settings")] 
        [SerializeField] private Transform groundColliderTransform;
        [SerializeField] private float jumpOffset;
        [SerializeField] private LayerMask groundMask;

        [Header("Arrow")] 
        [SerializeField] private SpriteRenderer _arrowSpriteRenderer;
        
        private Rigidbody2D _rigidbody;
        private AnimationController _animationController;
        private SpriteRenderer _spriteRenderer;

        
        private bool facingRight = true;
        
        public bool IsFacingRight => facingRight;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _animationController = GetComponent<AnimationController>();
            _rigidbody = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            Vector3 overlapCircleTransform = groundColliderTransform.position;
            
            isGrounded = Physics2D.OverlapCircle(overlapCircleTransform, jumpOffset,groundMask);
        }

        public void Move(float dirrection, bool isJumping)
        {
            if (isJumping)
                Jump();
            
            if(dirrection > 0 && !facingRight)
                Flip();
            
            if(dirrection < 0 && facingRight)
                Flip();
            
            if(Math.Abs(dirrection) >= 0.01f)
                HorizontalMovement(dirrection);
        }

        private void Jump()
        {
            if (isGrounded)
            {
                _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, jumpForce);
                _animationController.JumpAnimation();                
            }
        }

        private void HorizontalMovement(float dirrection)
        {
            _rigidbody.velocity = new Vector2(dirrection * speed, _rigidbody.velocity.y);
        }

        private void Flip()
        {
            _spriteRenderer.flipX = facingRight;
            _arrowSpriteRenderer.flipX = facingRight;
            facingRight = !facingRight;
        }
    }
}