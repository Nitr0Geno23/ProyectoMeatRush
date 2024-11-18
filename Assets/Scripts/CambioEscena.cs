using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambioEscena : MonoBehaviour
{
    public Canvas pauseMenu;
    public bool settingsActive = true;
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

        if (SceneManager.GetActiveScene().name == "Game" || SceneManager.GetActiveScene().name == "Game 2" || SceneManager.GetActiveScene().name == "Game 3")
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!settingsActive)
                {
                    Time.timeScale = 1f;
                }
                else
                {
                    Time.timeScale = 0f;
                }


                pauseMenu.gameObject.SetActive(settingsActive);
                settingsActive = !settingsActive;
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

    
    public void PlayScene()
    {
        SceneManager.LoadScene("LevelSelecter");

    }




}
    

