using System;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float damage;

    private KillCounter _killCounter;

    private void Awake()
    {
        _killCounter = GameObject.FindWithTag("GameController").GetComponent<KillCounter>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemyHealt = other.gameObject.GetComponentInParent<Healt>();
            enemyHealt.TakeDamage(damage);
            if(enemyHealt.CheckIsDead())
                _killCounter.IncreaseCounter();
            Destroy(gameObject);
        }
    }
}
