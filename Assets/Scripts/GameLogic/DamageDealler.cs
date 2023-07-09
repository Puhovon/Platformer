using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealler : MonoBehaviour
{
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Damageble"))
        {
            other.gameObject.GetComponent<Healt>().TakeDamage(damage);
        }
        
        Destroy(gameObject);
    }
}
