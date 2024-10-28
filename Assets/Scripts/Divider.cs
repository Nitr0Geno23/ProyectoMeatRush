//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Divider : MonoBehaviour
//{
//    public GameObject clonePlayer; 

//    void Start()
//    {
//        if (clonePlayer != null)
//        {
//            clonePlayer.SetActive(false);
//        }
//    }

//    void OnTriggerEnter(Collider other)
//    {
//        if (other.CompareTag("Player") && clonePlayer != null)
//        {
//            Debug.Log("Activando el clon del jugador con gravedad invertida.");

           
//            clonePlayer.SetActive(true);
//            Player clonePlayerScript = clonePlayer.GetComponent<Player>();
//            clonePlayerScript.SetDuplicateBehavior(); 


//            Player playerScript = other.GetComponent<Player>();
//            playerScript.Death += HandlePlayerDeath;
//            clonePlayerScript.Death += HandlePlayerDeath;
//        }
//    }

//    private void HandlePlayerDeath(Player deadPlayer)
//    {
//        if (deadPlayer.CompareTag("Player"))
//        {
//            Debug.Log("Jugador original ha muerto. Desactivando el clon y reiniciando.");

//            // Desactivar el clon y respawnear al jugador original
//            clonePlayer.SetActive(false);
//            deadPlayer.Respawn();
//        }
//        else if (deadPlayer.CompareTag("DuplicatePlayer"))
//        {
//            Debug.Log("El clon ha muerto. Desactivando y esperando reactivación.");
//            clonePlayer.SetActive(false);
//        }
//    }
//}

