using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Teleport portal; 
    private Vector3 destinationPosition;
    private bool canTeleport = true;
    public float teleportCooldown = 1f; 

    void Start()
    {
        destinationPosition = portal.transform.position;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canTeleport)
        {
            other.transform.position = destinationPosition;
            StartCoroutine(TeleportCooldown());
            portal.DisableTeleportForCooldown();
        }
    }

    private void DisableTeleportForCooldown()
    {
        canTeleport = false;
        StartCoroutine(TeleportCooldown());
    }

    private IEnumerator TeleportCooldown()
    {
        yield return new WaitForSeconds(teleportCooldown);
        canTeleport = true;
    }
}

