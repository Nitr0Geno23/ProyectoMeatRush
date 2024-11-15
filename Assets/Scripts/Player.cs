using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject[] Items;
    public float speed = 5f;

    public static List<Player> instances = new();
    private Rigidbody rb;
    Vector3 respawnPos;
    private bool isGrounded;
    public ParticleSystem Patriculas;
    public bool jumping = false;

    [SerializeField] InputActionReference jump;
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

    void OnTriggerEnter(Collider other)
    {

        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
            if (other.gameObject.CompareTag("TriggerJump"))
            {
                rb.AddForce(transform.up * Mathf.Abs(JumpForce), ForceMode.Impulse);
            }
        }
        
    }

    private void OnEnable()
    {
        instances.Add(this);
    }

    private void OnDisable()
    {
        instances.Remove(this);
    }

    void Update()
    {
        if (SceneManager.GetActiveScene().name == "Game" || SceneManager.GetActiveScene().name == "Game 2" || SceneManager.GetActiveScene().name == "Game 3")
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
        Physics.gravity = new Vector3(0f, -45f, 0f);
        GameManager.instance.gravitychanged = false;

        gameObject.SetActive(true);
        speed = 7f;
        rb.velocity = new Vector3(speed, 0, 0);
        rb.angularVelocity = Vector3.zero;

        transform.position = respawnPos;

        Respawner.instance.playerIsReviving = false;
        
        JumpForce = Mathf.Abs(JumpForce);
        Patriculas.Stop();
        
        


        foreach (GameObject item in Items)
        {

            item.GetComponent<PowerBoost>().Restart();
            
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true; 
            jumping = false;  
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
