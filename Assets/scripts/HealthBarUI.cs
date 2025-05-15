using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Image healthBarFill; 
    public HealthBar playerHealth; 

    void Update()
    {
        float fill = playerHealth.currentHealth / playerHealth.maxHealth;
        healthBarFill.fillAmount = Mathf.Clamp01(fill);
    }
}
