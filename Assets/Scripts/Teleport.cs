using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Teleport portal;
    new Vector3 p;
    void Start()
    {
        portal.p = transform.position;        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Entra");
            Player.instances[0].transform.position = portal.p;
        }
        

    }
}
