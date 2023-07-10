using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private float damage;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Healt>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}