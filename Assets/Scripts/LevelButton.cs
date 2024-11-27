using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Unity.VisualScripting;

public class LevelButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public Vector3 zoomScale = new Vector3(1.1f, 1.1f, 1.1f);
    private Vector3 originalScale;
    AudioManager audioManager;

    public string levelScene;

    private void Awake()
    {
        GameObject g = GameObject.FindGameObjectWithTag("Audio");

        if (g != null)
        {
            audioManager = g.GetComponent<AudioManager>();
        }

        
    }
    private void Start()
    {
        originalScale = transform.localScale;

    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        transform.localScale = zoomScale;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        transform.localScale = originalScale;
    }

    
    public void OnPointerClick(PointerEventData eventData)
    {
        audioManager.PlaySFX(audioManager.buttonPress);

        if (!string.IsNullOrEmpty(levelScene))
        {
            SceneManager.LoadScene(levelScene);
        }
        
    }

}

