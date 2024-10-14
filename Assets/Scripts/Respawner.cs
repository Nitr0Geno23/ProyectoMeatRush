using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public Player player;
    void Update()
    {
        if (player.gameObject.activeSelf)
        {
            if (Input.GetKey(KeyCode.R))
            {
                player.Respawn();
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
