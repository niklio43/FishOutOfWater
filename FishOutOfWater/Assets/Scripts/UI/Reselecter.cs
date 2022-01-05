using UnityEngine;
using UnityEngine.EventSystems;

public class Reselecter : MonoBehaviour
{
    [SerializeField] 
    private EventSystem eventSystem;
    private GameObject lastButton;

    void Awake()
    {
        if(eventSystem == null)
        {
            eventSystem = gameObject.GetComponent<EventSystem>();
        }
    }

    void Update()
    {
        if(eventSystem.currentSelectedGameObject == null)
        {
            eventSystem.SetSelectedGameObject(lastButton);
        }
        else
        {
            lastButton = eventSystem.currentSelectedGameObject;
        }
    }
}
