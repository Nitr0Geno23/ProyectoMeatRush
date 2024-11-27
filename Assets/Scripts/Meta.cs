using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Meta : MonoBehaviour
{
    public Canvas canvasVictory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canvasVictory.gameObject.SetActive(true);

            StartCoroutine(RespawnAgain());
        }

        IEnumerator RespawnAgain()
        {
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene("MenuConGameplay");
        }
    }
}
