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
        if (SceneManager.GetActiveScene().name == "MenuConGameplay")
        {
            if (Input.GetKey(KeyCode.Space))
            {
                SceneManager.LoadScene("LevelSelecter");
                Debug.Log("Entra");
            }
        }

        else if (SceneManager.GetActiveScene().name == "Game")
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("LevelSelecter");
            }
        }

        else if (SceneManager.GetActiveScene().name == "MenuConGameplay")
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                Application.Quit();
                //UnityEditor.EditorApplication.isPlaying = false;
            }
        }

    }
}
    

