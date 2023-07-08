using System;
using UnityEngine;

public class MoveblePlatform : MonoBehaviour
{
    [SerializeField] private Transform[] points;

    private SliderJoint2D platformJoint;
    private JointMotor2D platformMotor;
    private bool playerOnPlatform;
    private void Awake()
    {
        platformJoint = GetComponent<SliderJoint2D>();
        platformMotor = platformJoint.motor;
    }

    private void Update()
    {
        if (playerOnPlatform)
        {
            Debug.Log($"Motor speed: {platformJoint.motor.motorSpeed}");
            platformMotor.motorSpeed = -1f;
            platformJoint.motor = platformMotor;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log($"Collision with {other.gameObject.name}");
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
            playerOnPlatform = true;
            platformJoint.useMotor = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        Debug.Log($"Collision exit: {other.gameObject.name}");
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
            playerOnPlatform = false;
            platformJoint.useMotor = false;
        }
    }
}
