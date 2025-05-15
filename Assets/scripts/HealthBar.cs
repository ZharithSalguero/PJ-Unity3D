using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image fillImage;
    public float maxHealth = 100f;
    public float currentHealth = 100f;

    public void TakeDamage(float damage) 
    {
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateBar();
    }

    public void Heal(float amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateBar();
    }

    void UpdateBar()
    {
        float fillAmount = currentHealth / maxHealth;
        fillImage.fillAmount = fillAmount;
    }
}
