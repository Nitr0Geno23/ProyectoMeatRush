using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GravityChanger : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if (GameManager.instance.GetGravityChanged() == false)
        {
            Physics.gravity = new Vector3(0f, 45f, 0f);
            GameManager.instance.GravityHasChanged();
        }
        else 
        {
            Physics.gravity = new Vector3(0f, -45f, 0f);
            GameManager.instance.GravityHasChanged();
        }
        
    }
}
