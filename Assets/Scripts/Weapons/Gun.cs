using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [Header("Gun Settings")]
    public float rotZOffset;
    private float timeBtwShots;
    public int startAmmo = 512;
    public float startTimeBtwShots;

    [Header("Gun Objects")]
    public GameObject cameraObject;
    public GameObject bulletObject;
    public Transform shotPoint;
    public PlayerController player;
    public SpriteRenderer spriteRenderer;

    [Header("Particles/Sounds")]
    public GameObject shootParticleObject;

    public void Start()
    {
        player = GetComponentInParent<PlayerController>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotZOffset);

        if (timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
            {
                Shoot();
                timeBtwShots = startTimeBtwShots;
                cameraObject.GetComponent<Animator>().SetBool("isShake", true);
            } 
            else
                cameraObject.GetComponent<Animator>().SetBool("isShake", false);
        } 
        else
            timeBtwShots -= Time.deltaTime;

        float zRotation = transform.rotation.eulerAngles.z;
        if (zRotation > 180) zRotation -= 360;

        if (zRotation < 90 && zRotation > -90)
            spriteRenderer.flipY = false;
        else
            spriteRenderer.flipY = true;
    }

    public void Shoot()
    {
        Instantiate(shootParticleObject, shotPoint.position, transform.rotation);
        Instantiate(bulletObject, shotPoint.position, transform.rotation);
    }
}
