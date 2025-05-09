using UnityEngine;
using UnityEngine.SceneManagement;

public class UIPauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;  // El Canvas del men� de pausa

    void Update()
    {
        // Detecta si se presiona la tecla Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }

    // M�todo para activar el men� de pausa
    void Pause()
    {
        pauseMenuUI.SetActive(true);  // Muestra el men�
        Time.timeScale = 0f;  // Detiene el juego (pausa el tiempo)
    }

    // M�todo para reanudar el juego
    public void Resume()
    {
        pauseMenuUI.SetActive(false);  // Oculta el men�
        Time.timeScale = 1f;  // Reanuda el juego (restablece el tiempo normal)
    }

    // M�todo para salir al men� principal
    public void GoToMainMenu()
    {
        Time.timeScale = 1f;  // Aseg�rate de restaurar el tiempo
        SceneManager.LoadScene("MainMenu");  // Cambia "MainMenu" por el nombre de tu escena principal
    }
}