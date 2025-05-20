using UnityEngine;

public class FlickeringLight : MonoBehaviour
{
    private Light lightSource;
    private float timer;

    [Header("Control del parpadeo")]
    [SerializeField] private float minTime = 0.05f;
    [SerializeField] private float maxTime = 0.5f;

    void Start()
    {
        lightSource = GetComponent<Light>();
        StartCoroutine(Flicker());
    }

    System.Collections.IEnumerator Flicker()
    {
        while (true)
        {
            lightSource.enabled = !lightSource.enabled;
            float waitTime = Random.Range(minTime, maxTime);
            yield return new WaitForSeconds(waitTime);
        }
    }
}
