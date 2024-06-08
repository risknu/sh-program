using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.U2D;

using Random = UnityEngine.Random;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float speed = 20f;
    public float lifetime = 10f;
    public float distance = 20f;
    public int damage = 1;
    public int critDamage = 3;

    [Header("Explosion")]
    public float explosionRadius = 5f;
    public float explosionForce = 700f;
    public LayerMask explosionLayers;

    [Header("Bullet Objects")]
    public LayerMask whatIsSolid;
    public GameObject shootParticleObject;

    private void Start()
    {
        Invoke("DestroyBullet", lifetime);
    }

    public void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            int randomInt = Random.Range(0, 100);
            if (randomInt < 85)
                col.GetComponent<Enemy>().TakeDamage(damage);
            else
                col.GetComponent<Enemy>().TakeDamage(critDamage);
        }
        if (!col.CompareTag("Player"))
            DestroyBullet();
    }

    void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius, explosionLayers);

        foreach (Collider2D collider in colliders)
        {
            Rigidbody2D rb = collider.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                Vector2 direction = rb.transform.position - transform.position;
                direction.Normalize();
                rb.AddForce(direction * explosionForce);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }

    public void DestroyBullet()
    {
        Instantiate(shootParticleObject, transform.position, Quaternion.identity);
        Explode();
        Destroy(gameObject);
    }
}
