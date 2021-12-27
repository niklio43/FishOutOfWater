using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControlsToggle : MonoBehaviour, ISelectHandler
{
    private AudioController sound;
    private Toggle toggle;

    void Start()
    {
        toggle = GetComponent<Toggle>();
        sound = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioController>();
        if (sound.invertedControls)
            toggle.isOn = true;
        else if (!sound.invertedControls)
            toggle.isOn = false;
        toggle.onValueChanged.AddListener(delegate {sound.InvertControl();} );
    }

    public void OnSelect(BaseEventData eventData)
    {
        sound.Play("Button Hover");
    }
}
