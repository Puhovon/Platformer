using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint; 
    [SerializeField] private float fireForce;
    private float dirrections;

    private AnimationController _animationController;

    private void Awake()
    {
        _animationController = GetComponent<AnimationController>();
    }

    public void Shoot(bool facingRight)
    {
        _animationController.Attack();
        StartCoroutine(Attack(facingRight));
    }

    private IEnumerator Attack(bool facingRight)
    {
        yield return new WaitForSeconds(0.7f);
        GameObject newBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
        var bulletRb = newBullet.GetComponent<Rigidbody2D>();

        if (facingRight)
            bulletRb.velocity = new Vector2(fireForce * 1, bulletRb.velocity.y);
        else
            bulletRb.velocity = new Vector2(fireForce * -1, bulletRb.velocity.y);
    }
}
