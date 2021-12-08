using UnityEngine;

public class BulletController : MonoBehaviour
{
    public ParticleSystem bulletExplode;

    private GameObject sound;
    private GameObject child;
    private GameObject toxicChild;
    private CameraShake cameraShake;
    private LayingDolphin layingDolphin;
    private StandingDolphin standingDolphin;

    private void Start()
    {
        sound = GameObject.FindGameObjectWithTag("AudioManager");
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
    }

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
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Spike"))
        {
            bulletExplode.Play();
            Destroy(child);
            Destroy(gameObject, 0.1f);
        }
        if (gameObject.tag == "Bullet" && collision.gameObject.CompareTag("LayingDolphin"))
        {
            layingDolphin = collision.gameObject.GetComponent<LayingDolphin>();
            bulletExplode.Play();
            Destroy(child);
            Destroy(gameObject, 0.1f);
            layingDolphin.TakeDamage(20);
            sound.GetComponent<AudioController>().Play("Dolphin Damage");
        }
        if (gameObject.tag == "Bullet" && collision.gameObject.CompareTag("StandingDolphin"))
        {
            standingDolphin = collision.gameObject.GetComponent<StandingDolphin>();
            bulletExplode.Play();
            Destroy(child);
            Destroy(gameObject, 0.1f);
            standingDolphin.TakeDamage(20);
            sound.GetComponent<AudioController>().Play("Dolphin Damage");
        }
        if (gameObject.tag == "Bullet" && collision.gameObject.CompareTag("ToxicBarrel"))
        {
            cameraShake.ShakeMe(1f);
            toxicChild = collision.gameObject.transform.GetChild(0).gameObject;
            var toxicExplosion = collision.gameObject.transform.GetChild(1).gameObject.GetComponent<ToxicBarrel>();
            toxicExplosion.CreateToxicExplosion();
            collision.gameObject.GetComponent<Collider2D>().enabled = false;
            Destroy(child);
            Destroy(gameObject, 0.1f);
            Destroy(toxicChild);
            Destroy(collision.gameObject, 1f);
            sound.GetComponent<AudioController>().Play("Toxic Explode");
        }
    }
}