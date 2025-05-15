using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    public float damage = 25f;

    void OnTriggerEnter(Collider other)
    {
        // Verifica si el objeto que entra tiene el script HealthBar
        HealthBar health = other.GetComponent<HealthBar>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}
