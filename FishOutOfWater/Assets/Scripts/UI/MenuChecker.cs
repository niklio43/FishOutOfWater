using UnityEngine;
using System.IO;

public class MenuChecker : MonoBehaviour
{
    public GameObject MainMenuFirst, MainMenuSecond;

    void Start()
    {
        if (File.Exists(Application.persistentDataPath + "/fot.dat"))
            MainMenuSecond.SetActive(true);
        else
            MainMenuFirst.SetActive(true);
    }
}
