using UnityEngine;

public class BulletController : MonoBehaviour
{
    public ParticleSystem bulletExplode;

    private GameObject child;
    private GameObject toxicChild;
    private AudioController sound;
    private CameraShake cameraShake;
    private LayingDolphin layingDolphin;
    private StandingDolphin standingDolphin;
    private FishNetDolphin fishNetDolphin;
    private FishNetController fishNetController;

    private void Start()
    {
        if(GameObject.FindGameObjectWithTag("AudioManager") != null)
            sound = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioController>();
        cameraShake = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraShake>();
        Physics2D.IgnoreLayerCollision(3, 8, true);
        Physics2D.IgnoreLayerCollision(7, 3, true);
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
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("Spike") || collision.gameObject.CompareTag("Wall"))
        {
            bulletExplode.Play();
            Destroy(child);
            Destroy(gameObject, 0.1f);
        }
        if (gameObject.tag == "Bullet" && collision.gameObject.CompareTag("StandingDolphin"))
        {
            standingDolphin = collision.gameObject.GetComponent<StandingDolphin>();
            bulletExplode.Play();
            Destroy(child);
            Destroy(gameObject, 0.1f);
            standingDolphin.TakeDamage(20);
            if(!standingDolphin.isDead)
                sound.Play("Dolphin Damage");
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
            sound.Play("Toxic Explode");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameObject.tag == "Bullet" && collision.gameObject.CompareTag("LayingDolphin"))
        {
            layingDolphin = collision.gameObject.GetComponent<LayingDolphin>();
            bulletExplode.Play();
            Destroy(child);
            Destroy(gameObject, 0.1f);
            layingDolphin.TakeDamage(20);
            if(!layingDolphin.isDead)
                sound.Play("Dolphin Damage");
        }
        if (collision.gameObject.CompareTag("FishNet"))
        {
            fishNetController = collision.gameObject.GetComponent<FishNetController>();
            if (!fishNetController.copy)
            {
                fishNetDolphin = collision.gameObject.GetComponentInParent<FishNetDolphin>();
                bulletExplode.Play();
                Destroy(child);
                Destroy(gameObject, 0.1f);
                fishNetDolphin.TakeDamage(20);
                if (!fishNetDolphin.dead)
                    sound.Play("Dolphin Damage");
            }
        }
    }
}