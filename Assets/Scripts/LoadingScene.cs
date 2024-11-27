using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
public class LoadingScene : MonoBehaviour
{
    [SerializeField] CanvasGroup fader;
    Scene currentScene;

    static public LoadingScene instance;

    public void Awake()
    {
        instance = this;
    }


    public void LoadScene(string sceneName)
    {
        StartCoroutine(LoadSceneCoroutine(sceneName));
    }
    public IEnumerator LoadSceneCoroutine(string sceneName)
    {

        // Fade
        {
            Tween fadeTween = fader.DOFade(1f, 1f);
            do
            {
                yield return new();
            }
            while (fadeTween.IsPlaying());
        }
        // Descargar escena
        if (currentScene.isLoaded)
        {
            AsyncOperation unloadOperation = SceneManager.UnloadSceneAsync(currentScene);
            do
            {
                yield return new();
            }
            while (unloadOperation.isDone);
        }




        // Cargar Escena

        {
            AsyncOperation loadOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            do
            {
                yield return new();
            }
            while (loadOperation.isDone);
      
            currentScene = SceneManager.GetSceneAt(1);
            SceneManager.SetActiveScene(currentScene);
        }

        // Fade
        {
            Tween fadeTween = fader.DOFade(0f, 1f);
            do
            {
                yield return new();
            }
            while (fadeTween.IsPlaying());
        }
    }

    //[MenuItem("LoadingScene/Debug/Change to OutdoorsScene")]
    static public void DebugChangeToOutDoorScene()
    {
        LoadingScene.instance.LoadScene("Game");
    }
}
