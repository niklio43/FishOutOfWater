using UnityEngine;

public class FishNetDolphin : MonoBehaviour
{
    public bool netActive;
    public GameObject fishNet;

    private bool dead;
    private int Health;
    private Vector3 target;
    private GameObject net;
    private GameObject sound;
    private GameObject Player;
    private SpriteRenderer[] bodyParts;

    public Animator anim;

    private bool isAttacking;

    void Start()
    {
        isAttacking = false;
        Health = 60;
        dead = false;
        netActive = false;
        Player = GameObject.FindGameObjectWithTag("Player");
        sound = GameObject.FindGameObjectWithTag("AudioManager");
        CollectBody();
    }

    void Update()
    {
        anim.SetBool("isAttacking", isAttacking);
        if (Player != null)
            target = Player.transform.position;

        if (!GameObject.FindGameObjectWithTag("FishNet"))
        {
            netActive = false;
        }
        else
        {
            netActive = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            TakeDamage(20);
            sound.GetComponent<AudioController>().Play("Dolphin Damage");
        }
    }

    public void TakeDamage(int damage)
    {
        Health = Health - damage;
        foreach (SpriteRenderer part in bodyParts)
        {
            part.color = Color.red;
        }
        Invoke("ReturnColor", 0.1f);
        if (Health <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        dead = true;
        anim.SetTrigger("isDead");
        Destroy(gameObject, 2);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !dead && Player != null)
        {
            if(!netActive)
            {
                netActive = true;
                net = Instantiate(fishNet, new Vector2(target.x, transform.position.y), transform.rotation);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            netActive = false;
        }
    }

    private void CollectBody()
    {
        bodyParts = new SpriteRenderer[4];

        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyParts[i] = transform.GetChild(i + 2).gameObject.GetComponent<SpriteRenderer>();
        }
    }

    private void ReturnColor()
    {
        foreach (SpriteRenderer part in bodyParts)
        {
            part.color = Color.white;
        }
    }
}
