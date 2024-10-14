using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawner : MonoBehaviour
{
    public Player player;
    void Update()
    {
        if (player != null)
        {
            if (Input.GetKey(KeyCode.R))
            {
                player.Respawn();
            }

            else if (!player.gameObject.activeSelf)
            {

                StartCoroutine(ExampleCoroutine());
            }

            IEnumerator ExampleCoroutine()
            {
                yield return new WaitForSeconds(0.5f);
                player.Respawn();
            }
        }      

    }
}
