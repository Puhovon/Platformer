using UnityEngine;

public class Healt : MonoBehaviour
{
    [SerializeField] private bool isPlayer = false;
    [SerializeField] private float maxHealth;
    [SerializeField] private float currentHealth;
    
    private bool isAlive;
    
    public float CurrentHealth => currentHealth;
    public bool CheckIsAlive() => currentHealth <= 0;

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


}
