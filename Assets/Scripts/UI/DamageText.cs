using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    [Header("Text Settings/Objects")]
    public float damage;
    public TextMesh textMesh;

    private void Start()
    {
        textMesh = GetComponent<TextMesh>();
        textMesh.text = "-" + damage;
    }

    public void OnAnimationOver()
    {
        Destroy(gameObject);
    }
}
