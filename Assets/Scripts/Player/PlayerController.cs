using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    
    private Vector2 movement;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");

        movement = new Vector2(horizontal, 0);
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(movement * 2f);
    }
}
