using UnityEngine;
using UnityEngine.EventSystems;

public class BetweenScreens : MonoBehaviour
{
    public GameObject firstButton;

    void Start()
    {
        EventSystem.current.SetSelectedGameObject(firstButton);
    }
}
