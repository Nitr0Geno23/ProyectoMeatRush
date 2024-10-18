using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    public Player player;
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            player.Death(); 
            collision.gameObject.SetActive(false); 
            
        }

    } 

}