using UnityEngine;

public class FishNetDolphin : MonoBehaviour
{
    public bool netActive;
    public GameObject fishNet;

    private bool dead;
    private int Health;
    private float timer;
    private Vector3 target;
    private GameObject net;
    private GameObject sound;
    private GameObject Player;
    private SpriteRenderer[] bodyParts;


    void Start()
    {
        timer = 0;
        Health = 60;
        dead = false;
        netActive = false;
        Player = GameObject.FindGameObjectWithTag("Player");
        sound = GameObject.FindGameObjectWithTag("AudioManager");
        CollectBody();
    }

    void Update()
    {
        if (Player != null)
            target = Player.transform.position;

        timer += Time.deltaTime;
        if (!dead && timer >= 2 && Player != null)
        {
            Attack();
            timer = 0;
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
        Destroy(gameObject, 2);
    }

    private void Attack()
    {
        Vector3 enemyDirectionLocal = transform.InverseTransformPoint(Player.transform.position);

        //If Player is within these coordinates from the Enemy, it may attack
        if (enemyDirectionLocal.y > -5 && enemyDirectionLocal.y < 0)
        {
            if (enemyDirectionLocal.x < 16 && enemyDirectionLocal.x > -16)
            {
                if (enemyDirectionLocal.x < 4 && enemyDirectionLocal.x > -4)
                {
                    netActive = false;
                }
                else if (enemyDirectionLocal.x < 0 && !netActive)
                {
                    net = Instantiate(fishNet, new Vector2(target.x, transform.position.y), transform.rotation);
                    netActive = true;
                }
                else if (enemyDirectionLocal.x > 0 && !netActive)
                {
                    net = Instantiate(fishNet, new Vector2(target.x, transform.position.y), transform.rotation);
                    netActive = true;
                }
            }
        }

        if (net == null)
        {
            netActive = false;
        }
    }

    private void CollectBody()
    {
        bodyParts = new SpriteRenderer[4];

        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyParts[i] = transform.GetChild(i + 1).gameObject.GetComponent<SpriteRenderer>();
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
