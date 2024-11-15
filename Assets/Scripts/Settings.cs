using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public Animator animator;
    public GameObject panel;
    private bool settings = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }



    public void SettingsPanel()
    {

        settings = !settings;

        animator.SetBool("OnSettings", settings);
    }

    public void GoMainMenu()
    {
        SceneManager.LoadScene("MenuConGameplay");
    }

}
