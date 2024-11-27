using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------Music----------")]

    public AudioClip[] backgroundMusic;
    public AudioClip victoryMusic;

    [Header("----------SFX----------")]

    public AudioClip death;
    public AudioClip jump;
    public AudioClip itemPickup;
    public AudioClip portal;
    public AudioClip buttonPress;
    public AudioClip openSettings;

    // Start is called before the first frame update
    public static AudioManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        { 
            Destroy(gameObject);
        }
    }
    void Start()
    {
        if (SceneManager.GetActiveScene().name == "Game")
        {
            musicSource.Stop();
            musicSource.clip = backgroundMusic[0];
        }
        else if (SceneManager.GetActiveScene().name == "Game 2")
        {
            musicSource.Stop();
            musicSource.clip = backgroundMusic[1];
        }
        else if (SceneManager.GetActiveScene().name == "Game 3")
        {
            musicSource.Stop();
            musicSource.clip = backgroundMusic[2];
        }
        else if (SceneManager.GetActiveScene().name == "MenuConGameplay")
        {
            musicSource.Stop();
            musicSource.clip = backgroundMusic[3];
        }


        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    { 
        SFXSource.Stop();
        SFXSource.clip = clip;
        SFXSource.Play();
        //SFXSource.PlayOneShot(clip);
        Debug.Log("Ha sonado" + clip);
    }

}
