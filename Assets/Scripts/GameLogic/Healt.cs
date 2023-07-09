using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healt : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    private bool isAlive;

    public float CurrentHealth => currentHealth;
    private void Awake()
    {
        currentHealth = maxHealth;
        isAlive = true;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        CheckIsAlive();
    }

    private void CheckIsAlive()
    {
        if (currentHealth > 0)
        {
            isAlive = true;
        }
        else
        {
            isAlive = false;
        }
    }
}
