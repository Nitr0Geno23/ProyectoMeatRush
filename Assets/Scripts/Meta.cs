using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meta : MonoBehaviour
{
    public Canvas canvasVictory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canvasVictory.gameObject.SetActive(true);

            //StartCoroutine(SelectLevel());

        }

        //IEnumerator()
    }
}
