using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerClickHandler
{
    public AudioClip clip;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("The cursor entered the selectable UI element.");
        AudioManager.INSTANCE.source.PlayOneShot(clip);

    }
}


