using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour
{
    PowerBoost powerBoost;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            if (powerBoost != null && powerBoost.IsShieldActive())
            {
                powerBoost.UseShield();
            }
            else 
            {
                collision.gameObject.GetComponent<Player>().Death();
                collision.gameObject.SetActive(false);
            }
                      
        }

        else if (collision.gameObject.CompareTag("DuplicatePlayer"))
        {
            collision.gameObject.GetComponent<Player>().Death();
            collision.gameObject.SetActive(false);

        }



    } 

}
