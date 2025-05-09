using UnityEngine;
using TMPro;

public class ObjectInteractable : MonoBehaviour
{
    public float interactionDistance = 3f;
    public LayerMask interactableLayer;
    public TMP_Text interactionText;
    public Animator doorAnimator; // Animator para la puerta
    public Transform pivot;

    public GameObject objectToInteract;
    public bool canInteract = false;

    void Update()
    {
        RaycastForObject();

        if (objectToInteract != null)
        {
            interactionText.text = "Presiona [E] para interactuar";

            if (Input.GetKeyDown(KeyCode.E) && canInteract)
            {
                if (objectToInteract.CompareTag("Lever")) // Verificamos si el objeto es la palanca
                {
                    LeverInteraction leverScript = objectToInteract.GetComponent<LeverInteraction>();
                    if (leverScript != null)
                    {
                        leverScript.ActivateLever(); // Activamos la palanca
                    }
                }
            }
        }
        else
        {
            interactionText.text = "";
        }
    }

    void RaycastForObject()
    {
        Ray ray = new Ray(pivot.position, pivot.forward);
        RaycastHit hit;

        // Si el Raycast golpea un objeto interactuable (con layer específico)
        if (Physics.Raycast(ray, out hit, interactionDistance, interactableLayer))
        {
            objectToInteract = hit.collider.gameObject;
            canInteract = true; // Puedes interactuar

            // Debug para verificar el objeto detectado
            Debug.Log("Objeto detectado: " + objectToInteract.name + " con tag: " + objectToInteract.tag);
        }
        else
        {
            objectToInteract = null;
            canInteract = false; // No hay nada con lo que interactuar
        }
    }

    void OpenDoor()
    {
        if (doorAnimator != null)
        {
            // Activamos la animación que abre la puerta
            doorAnimator.SetTrigger("Open"); // Asegúrate de tener un trigger "Open" en el Animator
            Debug.Log("¡Puerta abierta!");
        }
    }
}
