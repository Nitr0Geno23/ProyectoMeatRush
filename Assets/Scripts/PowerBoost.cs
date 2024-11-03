using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBoost : MonoBehaviour
{
    public float speedMultiplier = 2f;  
    public float boostDuration = 3f;   
    private bool shieldActive = false;  

    private Player player;

    private void OnTriggerEnter(Collider collision)
    {

        if (collision.CompareTag("Player"))
        {
            player = collision.GetComponent<Player>();

            StartCoroutine(ApplyBoost());

            Destroy(gameObject);
        }
    }

    private IEnumerator ApplyBoost()
    {

        player.speed *= speedMultiplier;

        shieldActive = true;
        player.ShowShieldIndicator(true);

        yield return new WaitForSeconds(boostDuration);

        player.speed /= speedMultiplier;

        player.ShowShieldIndicator(false);
    }

    public bool IsShieldActive()
    {
        return shieldActive;
    }

    public void UseShield()
    {
        shieldActive = false;
    }
}
