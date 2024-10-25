using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player>().Death();
            //Player.instances[0].Death();
            collision.gameObject.SetActive(false); 
            
        }

        else if (collision.gameObject.CompareTag("DuplicatePlayer"))
        {
            collision.gameObject.GetComponent<Player>().Death();
            //Player.instances[0].Death();
            collision.gameObject.SetActive(false);

        }

    } 

}
