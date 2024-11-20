using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{

    private void Awake()
    {
        if (SceneManager.GetActiveScene().name == "SplashScreen")
        {
            StartCoroutine(ExampleCoroutine());
        }
            
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("MenuConGameplay");
    }

    private void Update()
    {

        
        if (SceneManager.GetActiveScene().name == "LevelSelecter")
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("MenuConGameplay");
            }
        }
    }

    
    public void PlayScene()
    {
        SceneManager.LoadScene("LevelSelecter");

    }




}
    

