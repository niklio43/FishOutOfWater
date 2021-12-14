using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alerted : MonoBehaviour
{
    public GameObject AlertedPrefab;

    private GameObject exclamation;

    public bool isActive;

    //hover hastighet
    [SerializeField]
    float speed = 5f;
    //max höjd
    [SerializeField]
    float height = 0.2f;

    Vector3 pos;

    void Start()
    {
        DrawAlerted();
        pos = exclamation.transform.position;
        exclamation.SetActive(false);
        isActive = false;
    }

    private void Update()
    {
        var distance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        if(distance < 14 && distance > 9)
        {
            exclamation.SetActive(true);
            isActive = true;
        }
        else
        {
            exclamation.SetActive(false);
            isActive = false;
        }

        if(isActive)
        {
            //kalkylerar nya y positionen
            float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
            //sätter nya positionen
            exclamation.transform.position = new Vector3(exclamation.transform.position.x, newY, exclamation.transform.position.z);
        }
    }

    void DrawAlerted()
    {
        exclamation = Instantiate(AlertedPrefab, new Vector2(transform.position.x, transform.position.y + 5.5f), transform.rotation);
    }
}
