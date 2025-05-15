using UnityEngine;
using System.Collections;

public class GameStartManager : MonoBehaviour
{
    [Header("Pantallas UI")]
    [SerializeField] private GameObject instructionsScreen;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private GameObject timer;
    [SerializeField] private GameObject inventory;

    [Header("Movimiento del jugador")]
    [SerializeField] private MonoBehaviour playerMovementScript;

    void Start()
    {
        // Mostrar instrucciones y ocultar HUD/jugador
        if (instructionsScreen != null) instructionsScreen.SetActive(true);
        if (healthBar != null) healthBar.SetActive(false);
        if (timer != null) timer.SetActive(false);
        if (inventory != null) inventory.SetActive(false);
        if (playerMovementScript != null) playerMovementScript.enabled = false;

        // Iniciar la corrutina de arranque
        StartCoroutine(BeginGameAfterDelay(5f));
    }

    IEnumerator BeginGameAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Ocultar instrucciones y activar el juego
        if (instructionsScreen != null) instructionsScreen.SetActive(false);
        if (healthBar != null) healthBar.SetActive(true);
        if (timer != null) timer.SetActive(true);
        if (inventory != null) inventory.SetActive(true);
        if (playerMovementScript != null) playerMovementScript.enabled = true;

        Debug.Log("Juego iniciado tras las instrucciones.");
    }
}
