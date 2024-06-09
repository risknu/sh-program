using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [Header("Shell Settings")]
    public float lifetime = 10f;

    private void Start()
    {
        Invoke("DestroyShell", lifetime);
    }

    public void DestroyShell()
    {
        Destroy(gameObject);
    }
}
