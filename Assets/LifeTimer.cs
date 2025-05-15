using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifeTimer : MonoBehaviour
{
    public float totalTime = 600f;
    public float currentLife = 100f;
    public float maxLife = 100f;

    public TMP_Text timerText;
    public Image healthBarFill; // 🆕 Imagen que se rellena

    private float timer;

    void Start()
    {
        timer = totalTime;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

            // Calcula vida proporcional al tiempo
            currentLife = Mathf.Lerp(0, maxLife, timer / totalTime);
            healthBarFill.fillAmount = currentLife / maxLife;

            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            timerText.text = $"{minutes:00}:{seconds:00}";
        }
        else
        {
            currentLife = 0;
            healthBarFill.fillAmount = 0;
            Die();
        }
    }

    void Die()
    {
        Debug.Log("¡Has muerto!");
        SceneManager.LoadScene("Game Over Menu");
    }
}