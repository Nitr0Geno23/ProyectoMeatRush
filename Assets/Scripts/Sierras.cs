using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sierras : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    Vector3 spawnPosition;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        spawnPosition = transform.position;
    }

    private void Update()
    {
        if (Respawner.instance.playerIsReviving)
        {
            transform.position = spawnPosition;
        }
    }

    private void FixedUpdate()
    {
        new Vector3(speed, 0f, 0f);
        Vector3 v = rb.velocity;
        rb.velocity = new Vector3(speed, v.y, 0f);

    }

    private void OnTriggerExit(Collider Limiter)
    {
        speed = -speed;
    }

}
