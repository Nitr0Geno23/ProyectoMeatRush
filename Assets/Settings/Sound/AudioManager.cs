using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("----------Music----------")]

    public AudioClip backgroundMusic;
    public AudioClip victoryMusic;

    [Header("----------SFX----------")]

    public AudioClip death;
    public AudioClip jump;
    public AudioClip itemPickup;
    public AudioClip portal;
    public AudioClip buttonPress;
    public AudioClip openSettings;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = backgroundMusic;
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
