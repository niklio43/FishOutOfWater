using UnityEngine;

public class FishNetDolphin : MonoBehaviour
{
    public bool netActive;

    public bool dead;
    private int Health;
    private bool isAttacking;

    public Animator anim;
    private GameObject sound;
    private GameObject Player;
    private SpriteRenderer[] bodyParts;

    public Vector3 fishNetStartPos;

    public Vector3 rightArmPos;

    private GameObject fishNet;

    private GameObject fishNetDolphinArm;

    private NetTrigger netTrigger;

    void Start()
    {
        netTrigger = transform.GetChild(1).gameObject.GetComponent<NetTrigger>();
        fishNetDolphinArm = transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
        fishNet = transform.GetChild(0).gameObject;
        rightArmPos = transform.GetChild(3).gameObject.transform.position;
        fishNetStartPos = GameObject.FindGameObjectWithTag("FishNet").transform.position;
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

        if (!netTrigger.throwing)
        {
            fishNet.transform.position = new Vector3(fishNetDolphinArm.transform.position.x - 0.5f, fishNetDolphinArm.transform.position.y - 0.5f, fishNetDolphinArm.transform.transform.position.z);
        }
        else
        {
            fishNet.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y + 5, Player.transform.position.z);
            fishNet.GetComponent<Rigidbody2D>().gravityScale = 3f;
            //netTrigger.throwing = false;
        }

        rightArmPos = transform.GetChild(3).gameObject.transform.position;

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
            if(!dead)
                sound.GetComponent<AudioController>().Play("Dolphin Damage");
        }
    }

    public void TakeDamage(int damage)
    {
        if (!dead)
        {
            Health = Health - damage;
            foreach (SpriteRenderer part in bodyParts)
            {
                part.color = Color.red;
            }
            Invoke("ReturnColor", 0.1f);
        }
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

    private void CollectBody() //Gathers the different parts of the prefab with sprite renderers
    {
        bodyParts = new SpriteRenderer[4];

        for (int i = 0; i < bodyParts.Length; i++)
        {
            bodyParts[i] = transform.GetChild(i + 3).gameObject.GetComponent<SpriteRenderer>();
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
