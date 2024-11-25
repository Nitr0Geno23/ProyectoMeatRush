using System.Collections;
using UnityEngine;

public class PowerBoost : MonoBehaviour
{
    public float speedMultiplier = 2f; 
    public float boostDuration = 3f;
    AudioManager audioManager;

    public Player player;

    Coroutine coroutine;

    public void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    public void Restart()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        
        gameObject.GetComponent<BoxCollider>().enabled = true;
        gameObject.GetComponentInChildren<MeshRenderer>().enabled = true;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;

            coroutine = StartCoroutine(ApplyBoost());

            audioManager.PlaySFX(audioManager.itemPickup);
        }

        
    }

    private IEnumerator ApplyBoost()
    {
        
        player.speed *= speedMultiplier;

       
        yield return new WaitForSeconds(boostDuration);

        
        player.speed /= speedMultiplier;

    }

}
