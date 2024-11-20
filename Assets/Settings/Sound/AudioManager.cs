using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public AudioClip background;
    public AudioClip death;
    public AudioClip sliding;
    public AudioClip jump;
    public AudioClip itempickup;
    public AudioClip win;
    public AudioClip menu;
    public AudioClip portal;

    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    { 
        SFXSource.PlayOneShot(clip);
    }

    void Update()
    {
        
    }
}
