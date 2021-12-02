using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public ParticleSystem bulletExplode;
    private GameObject child;
    private LayingDolphin layingDolphin;
    private StandingDolphin standingDolphin;

    public void CreateBulletExplode()
    {
        bulletExplode.Play();
    }

    private void Update()
    {
        if(transform.GetChild(0).name == "Bullet")
        {
            child = transform.GetChild(0).gameObject;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            bulletExplode.Play();
            Destroy(child);
            Destroy(gameObject, 0.1f);
        }
        if (collision.gameObject.CompareTag("LayingDolphin"))
        {
            layingDolphin = collision.gameObject.GetComponent<LayingDolphin>();
            bulletExplode.Play();
            Destroy(child);
            Destroy(gameObject, 0.1f);
            layingDolphin.TakeDamage(20);
        }
        if (collision.gameObject.CompareTag("StandingDolphin"))
        {
            standingDolphin = collision.gameObject.GetComponent<StandingDolphin>();
            bulletExplode.Play();
            Destroy(child);
            Destroy(gameObject, 0.1f);
            standingDolphin.TakeDamage(20);
        }
    }

}