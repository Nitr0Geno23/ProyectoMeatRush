using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player instance;
    private Rigidbody rb;
    Vector3 respawnPos;
    private bool isGrounded;
    public ParticleSystem Patriculas;
    bool jumping = false;

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
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        rb = GetComponent<Rigidbody>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("TriggerJump"))
        {
            rb.AddForce(transform.up * Mathf.Abs(JumpForce), ForceMode.Impulse);
        }
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                jumping = true;
                isGrounded = false;
            }
        }
    }
    public void Respawn()
    {
        gameObject.SetActive(true);
        rb.velocity = new Vector3(speed, 0, 0);
        rb.angularVelocity = Vector3.zero;
        transform.position = respawnPos;
        Respawner.instance.playerIsReviving = false;
        Patriculas.Stop();
        Physics.gravity = new Vector3(0f, -45f, 0f);
        GameManager.instance.gravitychanged = false;
        JumpForce = Mathf.Abs(JumpForce);

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
        if (GameManager.instance.GetGravityChanged())
        {
            if (jumping)
            {

                rb.AddForce(transform.up * -Mathf.Abs(JumpForce), ForceMode.Impulse);
                jumping = false;
            }
        }
        else 
        {
            if (jumping)
            {
                rb.AddForce(transform.up * Mathf.Abs(JumpForce), ForceMode.Impulse);
                jumping = false;
            }
        }
 

        new Vector3(speed, 0f, 0f);
        Vector3 v = rb.velocity;
        rb.velocity = new Vector3(speed, v.y, 0f);

    }

    public void Death()
    {
        Patriculas.transform.position = transform.position;
        Patriculas.Play();
        Respawner.instance.playerIsReviving = true;

    }

}
