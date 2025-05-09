using UnityEngine;

public class LeverInteraction : MonoBehaviour
{
    public Animator doorAnimator; // Animator de la puerta
    private ObjectInteractable interactableScript; // Referencia al script ObjectInteractable del jugador
    private bool isLeverActivated = false;

    private void Start()
    {
        // Buscar el script ObjectInteractable en el jugador (o donde sea necesario)
        // Asegúrate de que el objeto que tiene el script ObjectInteractable sea el jugador o la cámara
        GameObject player = GameObject.FindGameObjectWithTag("Player"); 
        if (player != null)
        {
            interactableScript = player.GetComponent<ObjectInteractable>();
        }
        else
        {
            Debug.LogError("No se encontró el objeto con la etiqueta 'Player'.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Detectar si el jugador entra en el área de la palanca
        if (other.CompareTag("Player"))
        {
            // Cambia el texto de interacción
            interactableScript.interactionText.text = "Presiona [E] para activar la palanca";
            interactableScript.objectToInteract = gameObject; // Asignamos la palanca como objeto interactuable
            interactableScript.canInteract = true; // Permitimos la interacción
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Si el jugador sale del área de la palanca, desactivar la interacción
        if (other.CompareTag("Player"))
        {
            interactableScript.interactionText.text = "";
            interactableScript.objectToInteract = null; // Dejamos de interactuar
            interactableScript.canInteract = false; // Ya no se puede interactuar
        }
    }

    public void ActivateLever()
    {
        if (!isLeverActivated)
        {
            // Activamos la animación de la puerta
            if (doorAnimator != null)
            {
                doorAnimator.SetTrigger("Open"); // Asegúrate de que el trigger "Open" esté en el Animator de la puerta
                Debug.Log("¡Palanca activada y puerta abierta!");
            }
            else
            {
                Debug.LogError("No se ha asignado un Animator de la puerta.");
            }
            isLeverActivated = true; // Marca la palanca como activada
        }
        else
        {
            Debug.Log("La palanca ya ha sido activada.");
        }
    }
}
