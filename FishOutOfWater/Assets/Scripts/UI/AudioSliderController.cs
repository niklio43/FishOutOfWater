using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AudioSliderController : MonoBehaviour, ISelectHandler, IMoveHandler, IDropHandler
{
    private Slider slider;

    private AudioController sound;

    void Start()
    {
        sound = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioController>();
        slider = gameObject.GetComponent<Slider>();

        if (sound.menuVolume != -1)
        {
            slider.value = sound.menuVolume;
        }
        slider.onValueChanged.AddListener(sound.MenuVolume);
    }

    public void OnSelect(BaseEventData eventData)
    {
        sound.Play("Button Hover");
    }

    public void OnMove(AxisEventData eventData)
    {
        sound.Play("Button Click");
    }

    public void OnDrop(PointerEventData eventData)
    {
        sound.Play("Button Click");
    }
}
