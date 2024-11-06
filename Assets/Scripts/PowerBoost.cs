using System.Collections;
using UnityEngine;

public class PowerBoost : MonoBehaviour
{
    public float speedMultiplier = 2f; 
    public float boostDuration = 3f;    

    public Player player;

    Coroutine coroutine;

    public void Restart()
    {
        StopCoroutine(coroutine);
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
        }

        
    }

    private IEnumerator ApplyBoost()
    {
        
        player.speed *= speedMultiplier;

       
        yield return new WaitForSeconds(boostDuration);

        
        player.speed /= speedMultiplier;

    }

}
