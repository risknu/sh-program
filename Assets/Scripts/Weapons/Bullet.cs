using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.U2D;

public class Bullet : MonoBehaviour
{
    [Header("Bullet Settings")]
    public float speed;
    public float lifetime;
    public float distance;
    public int damage;

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
            col.GetComponent<Enemy>().TakeDamage(damage);
        }
        if (!col.CompareTag("Player"))
        {
            DestroyBullet();
        }
    }

    public void DestroyBullet()
    {
        Instantiate(shootParticleObject, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
