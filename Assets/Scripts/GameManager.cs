using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gravitychanged = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else 
        {
            Destroy(gameObject);
        }
    }

    public void GravityHasChanged()
    {
        gravitychanged = !gravitychanged;
   
    }

    public bool GetGravityChanged()
    {
        return gravitychanged;
    }
}
