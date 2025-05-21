using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public ObjectGrabber playerGrabber; // Asignar el GameObject del jugador con ObjectGrabber
    public string requiredItemName = "Key"; // Nombre exacto del objeto requerido
    public GameObject puertaBloqueadaUI; // Texto que aparece si no tienes la llave

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (playerGrabber.HasItem(requiredItemName))
            {
                AbrirPuerta();
            }
            else
            {
                Debug.Log("La puerta está cerrada. Necesitas la llave.");
                if (puertaBloqueadaUI != null)
                    puertaBloqueadaUI.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && puertaBloqueadaUI != null)
        {
            puertaBloqueadaUI.SetActive(false);
        }
    }

    void AbrirPuerta()
    {
        Debug.Log("¡Puerta abierta!");
        gameObject.SetActive(false);
    }
}