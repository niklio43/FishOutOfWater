using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBlobb : MonoBehaviour
{

    private DisplayAmmo displayAmmo;

    private void Start()
    {
        displayAmmo = GameObject.FindGameObjectWithTag("AmmoCounterHolder").GetComponent<DisplayAmmo>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            displayAmmo.ReloadAmmoNoTimer();
            Destroy(gameObject);
        }
    }

}
