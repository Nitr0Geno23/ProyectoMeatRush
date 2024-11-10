using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public Canvas pauseMenu;
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

        else if (SceneManager.GetActiveScene().name == "Game" || SceneManager.GetActiveScene().name == "Game 2" || SceneManager.GetActiveScene().name == "Game 3")
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                pauseMenu.gameObject.SetActive(true);
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
        else if (SceneManager.GetActiveScene().name == "LevelSelecter")
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                SceneManager.LoadScene("MenuConGameplay");
            }
        }
    }
}
    

