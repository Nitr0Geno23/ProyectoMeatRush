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
            collision.gameObject.SetActive(false);
            
                      
        }

    } 

}
