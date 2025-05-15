using UnityEngine;
using System.Collections;

public class Billboard : MonoBehaviour
{
    private Transform cameraTransform;

    void Start()
    {
        cameraTransform = Camera.main.transform;

        StartCoroutine(HideAfterSeconds(10f));
    }

    void LateUpdate()
    {
        Vector3 direction = cameraTransform.position - transform.position;
        direction.y = 0f;

        if (direction.sqrMagnitude > 0.001f)
        {
            Quaternion lookRotation = Quaternion.LookRotation(-direction);
            transform.rotation = lookRotation;
        }
    }

    IEnumerator HideAfterSeconds(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        gameObject.SetActive(false);
    }
}
