using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public Player player;
    public static Respawner instance;
    public bool playerIsReviving = false;

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
    }

    void Update()
    {
        if (player.gameObject.activeSelf)
        {
            if (Input.GetKey(KeyCode.R))
            {
                player.Respawn();
                playerIsReviving = true;
            }
        }
        else
        {
            
            StartCoroutine(ExampleCoroutine());
        }

        IEnumerator ExampleCoroutine()
        {
            yield return new WaitForSeconds(0.2f);
            player.Respawn();
        }
    } 

    
}
