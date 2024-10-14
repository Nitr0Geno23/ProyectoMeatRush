using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePincho : MonoBehaviour
{
    public Player player;
    private void OnCollisionEnter(Collision collision)
    {
        player.Death();
        collision.gameObject.SetActive(false);
        
    }



}
