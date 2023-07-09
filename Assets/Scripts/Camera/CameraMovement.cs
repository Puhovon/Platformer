using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    private Vector3 distance;

    private void Awake()
    {
        distance = transform.position - player.position;
    }

    private void FixedUpdate()
    {
        transform.position = player.position + distance;
    }
}
