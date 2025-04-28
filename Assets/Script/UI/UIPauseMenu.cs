using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;  // El Canvas del menú de pausa

    void Update()
    {
        // Detecta si se presiona la tecla Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    // Método para activar el menú de pausa
    void Pause()
    {
        pauseMenuUI.SetActive(true);  // Muestra el menú
        Time.timeScale = 0f;  // Detiene el juego (pausa el tiempo)
    }

    // Método para reanudar el juego
    public void Resume()
    {
        pauseMenuUI.SetActive(false);  // Oculta el menú
        Time.timeScale = 1f;  // Reanuda el juego (restablece el tiempo normal)
    }

    // Método para salir al menú principal
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;  // Asegúrate de restaurar el tiempo
        SceneManager.LoadScene("MainMenu");  // Cambia "MainMenu" por el nombre de tu escena principal
    }
}