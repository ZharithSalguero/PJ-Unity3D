using UnityEngine;
using UnityEngine.EventSystems;

public class aaa : MonoBehaviour, IPointerEnterHandler
{
    public AudioClip clip;

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("The cursor entered the selectable UI element.");
        AudioManager.INSTANCE.source.PlayOneShot(clip);

    }
}


