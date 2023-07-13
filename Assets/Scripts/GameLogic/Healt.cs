using UnityEngine;

public class Healt : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    
    private bool isAlive;
    
    public float CurrentHealth => currentHealth;
    public bool CheckIsDead() => currentHealth <= 0;

    private void Awake()
    {
        currentHealth = maxHealth;
        isAlive = true;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        CheckIsDead();
    }


}
