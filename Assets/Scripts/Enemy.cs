using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy objects")]
    public GameObject textObject;

    public void TakeDamage(float damage)
    {
        Vector2 spawnPos = new Vector2(transform.position.x + (float)Random.Range(-1.7f, 2.7f), transform.position.y + (float)Random.Range(0f, 1.7f));
        Instantiate(textObject, spawnPos, Quaternion.identity);
        textObject.GetComponentInChildren<DamageText>().damage = damage;
    }
}
