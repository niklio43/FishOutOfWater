using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    public float health;
    public Slider slider;
    public Text text;


    void Start()
    {
        
    }

    void Update()
    {
        slider.value = health;
        text.text="Health : "+health;
    }


    void OnCollisionEnter2D(Collision2D obj)
    {

        if (obj.gameObject.tag == "ToxicBarrel")
         {
            health = health -2f;
         }
    }
}

