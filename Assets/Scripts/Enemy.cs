using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Enemy objects")]
    public GameObject hitParticleEffect;
    public GameObject textObject;

    public void TakeDamage(float damage, Vector2 hitPos)
    {
        Instantiate(hitParticleEffect, hitPos, Quaternion.identity);

        Vector2 spawnPos = new Vector2(transform.position.x + (float)Random.Range(-1.7f, 2.7f), transform.position.y + (float)Random.Range(0f, 1.7f));
        Instantiate(textObject, spawnPos, Quaternion.identity);
        if (damage > 1)
            textObject.GetComponentInChildren<TextMesh>().color = HexToColor("#e63946");
        else
            textObject.GetComponentInChildren<TextMesh>().color = HexToColor("#ffffff");
        textObject.GetComponentInChildren<DamageText>().damage = damage;
    }

    Color HexToColor(string hex)
    {
        Color color = new Color();
        ColorUtility.TryParseHtmlString(hex, out color);
        return color;
    }
}
