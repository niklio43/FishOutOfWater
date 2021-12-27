using UnityEngine;
using UnityEngine.EventSystems;

public class FakeButton : MonoBehaviour
{
    public GameObject nextButton;

    public void Update()
    {
        if(EventSystem.current.currentSelectedGameObject == gameObject)
            EventSystem.current.SetSelectedGameObject(nextButton);
    }
}
