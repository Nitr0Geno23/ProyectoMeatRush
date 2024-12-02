using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] private AudioMixer myMixer;
    private Slider musicSlider;
    private Slider SFXSlider;

    private void Start()
    {
        AssignSliders(); // Intenta asignar sliders al cargar la primera escena
        SceneManager.sceneLoaded += OnSceneLoaded; // Detecta cambios de escena
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignSliders(); // Reasigna sliders cada vez que cargues una nueva escena
    }

    private void AssignSliders()
    {
        // Busca los sliders en cualquier parte de la escena, incluso desactivados
        musicSlider = FindSliderInScene("MusicSlider");
        SFXSlider = FindSliderInScene("SFXSlider");

        if (musicSlider == null || SFXSlider == null)
        {
            Debug.LogWarning("No se encontraron sliders en la escena: " + SceneManager.GetActiveScene().name);
            return;
        }

        // Configura los eventos de los sliders para cambiar el volumen
        musicSlider.onValueChanged.RemoveAllListeners();
        musicSlider.onValueChanged.AddListener(delegate { SetMusicVolume(); });

        SFXSlider.onValueChanged.RemoveAllListeners();
        SFXSlider.onValueChanged.AddListener(delegate { SetSFXVolume(); });

        // Carga los valores guardados
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
            SetSFXVolume();
        }

        Debug.Log("Sliders asignados correctamente en la escena: " + SceneManager.GetActiveScene().name);
    }

    // Método que busca los sliders en la escena, incluyendo desactivados
    private Slider FindSliderInScene(string sliderName)
    {
        // Recorre todos los objetos en la escena, incluso los desactivados
        Slider slider = FindInChildrenRecursively(sliderName, transform);
        return slider;
    }

    private Slider FindInChildrenRecursively(string sliderName, Transform parent)
    {
        // Busca el Slider en el objeto actual
        Slider slider = parent.GetComponent<Slider>();
        if (slider != null && slider.name == sliderName)
        {
            return slider;
        }

        // Si no se encuentra, recursivamente busca en los hijos
        foreach (Transform child in parent)
        {
            slider = FindInChildrenRecursively(sliderName, child);
            if (slider != null)
            {
                return slider;
            }
        }

        // Si no se encuentra en esta rama, retorna null
        return null;
    }

    public void SetMusicVolume()
    {
        if (musicSlider == null) return;

        float volume = musicSlider.value;
        myMixer.SetFloat("music", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    public void SetSFXVolume()
    {
        if (SFXSlider == null) return;

        float volume = SFXSlider.value;
        myMixer.SetFloat("SFX", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", volume);
    }

    private void LoadVolume()
    {
        float musicVolume = PlayerPrefs.GetFloat("musicVolume", 1f);
        float SFXVolume = PlayerPrefs.GetFloat("SFXVolume", 1f);

        if (musicSlider != null) musicSlider.value = musicVolume;
        if (SFXSlider != null) SFXSlider.value = SFXVolume;

        SetMusicVolume();
        SetSFXVolume();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded; // Limpia la suscripción al evento
    }
}
