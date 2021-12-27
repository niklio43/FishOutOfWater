using UnityEngine.EventSystems;
using UnityEngine;

public class ButtonHandler : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, ISelectHandler, ISubmitHandler
{

    private AudioController sound;

    private void Start()
    {
        sound = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioController>();
    }

    public void OnPointerEnter(PointerEventData ped)
    {
        sound.Play("Button Hover");
    }

    public void OnPointerDown(PointerEventData ped)
    {
        sound.Play("Button Click");
    }

    public void OnSelect(BaseEventData eventData)
    {
        sound.Play("Button Hover");
    }

    public void OnSubmit(BaseEventData eventData)
    {
        sound.Play("Button Click");
    }
}
