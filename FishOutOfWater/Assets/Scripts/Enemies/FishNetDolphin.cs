using UnityEngine;
using System.Collections;

public class FishNetDolphin : MonoBehaviour
{
    public bool dead;
    public bool setPos;
    public Animator anim;
    public bool netActive;
    public Vector3 rightArmPos;
    private Vector3 net, target;
    public Vector3 fishNetStartPos;

    private int Health;
    private bool isAttacking;
    private GameObject sound;
    private bool reachedTarget;
    private GameObject fishNet;
    private NetTrigger netTrigger;
    private SpriteRenderer[] bodyParts;
    private GameObject fishNetDolphinArm;

    void Start()
    {
        reachedTarget = false;
        netTrigger = transform.GetChild(1).gameObject.GetComponent<NetTrigger>();
        fishNetDolphinArm = transform.GetChild(2).gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).gameObject.transform.GetChild(0).gameObject;
        fishNet = transform.GetChild(0).gameObject;
        fishNetStartPos = fishNet.transform.position;
        isAttacking = false;
        Health = 60;
        dead = false;
        setPos = false;
        netActive = false;
        sound = GameObject.FindGameObjectWithTag("AudioManager");
        CollectBody();
    }

    void Update()
    {
        anim.SetBool("isAttacking", isAttacking);

        net = new Vector3(fishNet.transform.position.x, 0, 0);
        target = new Vector3(netTrigger.targetPos.x, 0, 0);

        if (!netTrigger.throwing)
        {
            fishNet.transform.position = new Vector3(fishNetDolphinArm.transform.position.x - 0.5f, fishNetDolphinArm.transform.position.y - 0.5f, fishNetDolphinArm.transform.transform.position.z);
            reachedTarget = false;
        }
        else if (netTrigger.throwing && !reachedTarget)
        {
            fishNet.transform.position = Vector3.Lerp(fishNet.transform.position, netTrigger.targetPos, 0.1f);
            isAttacking = true;
        }
        
        if (Vector3.Distance(net, target) <= 0.3f)
        {
            reachedTarget = true;
            isAttacking = false;
        }
    }

    private void FixedUpdate()
    {
        if (reachedTarget || fishNet.GetComponent<FishNetController>().caughtByFishNet)
        {
            fishNet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -1500 * Time.deltaTime);
        }
        else
        {
            fishNet.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(collision.gameObject);
            TakeDamage(20);
            if (!dead)
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
