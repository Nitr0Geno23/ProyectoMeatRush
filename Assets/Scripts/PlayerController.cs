using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody rb;
    Vector3 respawnPos;
    private bool isGrounded;
    public ParticleSystem Patriculas;

    [SerializeField] InputActionReference jump;
    [SerializeField] float speed = 5;
    [SerializeField] float JumpForce;

    void Start()
    {
        respawnPos = transform.position;

        Patriculas.Stop();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);

        }
    }
    public void Respawn()
    {
        gameObject.SetActive(true);
        rb.velocity = new Vector3(0, 0, 0);
        rb.angularVelocity = Vector3.zero;

        transform.position = respawnPos;

        Patriculas.Stop();
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Ground")
        {
            isGrounded = false;
  
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
    private void FixedUpdate()
    {
        new Vector3(0f, 0f, speed);
        Vector3 v = rb.velocity;
        rb.velocity = new Vector3(0f, v.y, speed);

    }

    public void Death()
    {
        Patriculas.transform.position = transform.position;
        Patriculas.Play();

    }

}
