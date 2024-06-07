using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [Header("Camera Settings")]
    public Transform target;
    public Vector3 velocity = Vector3.zero;
    public float smoothTime = 0.15f;


    public void FixedUpdate()
    {
        Vector3 targetPos = target.position;
        targetPos.z = transform.position.z;
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }
}
