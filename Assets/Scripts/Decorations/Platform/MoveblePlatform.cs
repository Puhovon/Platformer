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

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = true;
            MovePlatform(playerOnPlatform, other.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerOnPlatform = false;
            MovePlatform(playerOnPlatform, other.gameObject);
        }
        
    }

    private void MovePlatform(bool onPlatform, GameObject player)
    {
        if (onPlatform)
        {
            platformJoint.useMotor = true;
            platformMotor.motorSpeed = -1f;
            platformJoint.motor = platformMotor;
            // player.transform.SetParent(transform);
        }
        else
        {
            platformMotor.motorSpeed = 1f;
            platformJoint.motor = platformMotor;
            // player.transform.SetParent(null);
            platformJoint.useMotor = true;
        }
    }
}
