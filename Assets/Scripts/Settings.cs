using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.Rendering.DebugUI;
using UnityEngine.SceneManagement;

public class Settings : MonoBehaviour
{
    public Animator animator;
    public int settings = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
    }

}
