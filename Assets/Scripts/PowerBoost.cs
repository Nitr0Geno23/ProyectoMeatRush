using System.Collections;
using UnityEngine;

public class PowerBoost : MonoBehaviour
{
    public float speedMultiplier = 2f; 
    public float boostDuration = 3f;    

    public Player player; 

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(ApplyBoost());
        }

        gameObject.SetActive(false);
    }

    private IEnumerator ApplyBoost()
    {
        
        player.speed *= speedMultiplier;

       
        yield return new WaitForSeconds(boostDuration);

        
        player.speed /= speedMultiplier;

    }
}
