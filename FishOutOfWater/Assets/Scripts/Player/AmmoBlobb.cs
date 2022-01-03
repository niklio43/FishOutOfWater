using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBlobb : MonoBehaviour
{
    private AudioController sound;
    private DisplayAmmo displayAmmo;
    private GunController gunController;

    private void Start()
    {
        sound = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioController>();
        displayAmmo = GameObject.FindGameObjectWithTag("AmmoCounterHolder").GetComponent<DisplayAmmo>();
        gunController = GameObject.FindGameObjectWithTag("Gun").GetComponent<GunController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gunController.ammo = 13;
            displayAmmo.ReloadAmmoNoTimer();
            sound.Play("Reload");
            Destroy(gameObject);
        }
    }

}
