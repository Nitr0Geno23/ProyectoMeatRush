using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GravityDirection
{
    up,
    down,
    left,
    right
};


public class GravityChanger : MonoBehaviour
{
    
    private GravityDirection gravityDirection;
    void OnTriggerEnter(Collider collider)
    {
        if (GameManager.instance.GetGravityChanged() == false)
        {

            if (gameObject.CompareTag("PortalUp"))
            {
                Physics.gravity = new Vector3(0f, 45f, 0f);
                GameManager.instance.GravityHasChanged();
                gravityDirection = GravityDirection.up;
            }
            else if (gameObject.CompareTag("PortalRight"))
            {
                Physics.gravity = new Vector3(100f, 0f, 0f);
                GameManager.instance.GravityHasChanged();
                gravityDirection = GravityDirection.right;
            }

        }
        else 
        {
            Physics.gravity = new Vector3(0f, -45f, 0f);
            GameManager.instance.GravityHasChanged();
        }      
    }
}
