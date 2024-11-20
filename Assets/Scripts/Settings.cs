using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public Animator animator;
    public int settings = 0;
    public bool settingsActive = false;
    public GameObject pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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


                ResetMenuAnimations();
                pauseMenu.gameObject.SetActive(settingsActive);
                settingsActive = !settingsActive;
            }
        }
    }

    private void ResetMenuAnimations()
    {  

        animator.Rebind();  


        animator.Play("Menu", 0, 0f); 

    }

    public void MainMenu()
    {
        animator.SetInteger("Menu", 0);
    }

    public void GraphicsMenu()
    {
        animator.SetInteger("Menu", 1);
    }

    public void SoundMenu()
    {
        animator.SetInteger("Menu", 2);
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MenuConGameplay");
        settingsActive = false;
        pauseMenu.gameObject.SetActive(settingsActive);
    }


    public void SetVolume(float volume)
    { 
    
    }
}

