using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class AudioSliderController : MonoBehaviour, ISelectHandler
{
    private Slider slider;

    private AudioController sound;

    void Start()
    {
        sound = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioController>();
        slider = gameObject.GetComponent<Slider>();
        slider.onValueChanged.AddListener(sound.MenuVolume);
        
        if(sound.menuVolume != -1)
        {
            slider.value = sound.menuVolume;
        }
    }

    public void OnSelect(BaseEventData eventData)
    {
        sound.Play("Button Hover");
    }
}
