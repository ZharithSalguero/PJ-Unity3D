using UnityEngine;
using System.Collections;

public class FinalTrigger : MonoBehaviour
{
    [SerializeField] private GameObject finalSign; // Asigna aquí el cartel desde el editor

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (finalSign != null)
            {
                finalSign.SetActive(true);
                StartCoroutine(HideSignAfterDelay(5f));
            }
        }
    }

    IEnumerator HideSignAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        finalSign.SetActive(false);
    }
}
