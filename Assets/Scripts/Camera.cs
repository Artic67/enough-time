using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private float smoothness = 0.1f;
    [SerializeField] Transform player;
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, player.position + Vector3.back * 5 + Vector3.up * 2, smoothness);
    }
}
