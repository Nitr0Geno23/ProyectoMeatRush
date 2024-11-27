using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level1Music : MonoBehaviour
{
    // Start is called before the first frame update

    AudioManager audioManager;

    
    private void Awake()
    {

        GameObject g = GameObject.FindGameObjectWithTag("Audio");

        if (g != null)
        {
            audioManager = g.GetComponent<AudioManager>();
        }
    }
    
    void Start()
    {

        audioManager.ChangeMusicLevel1();

    }

}
