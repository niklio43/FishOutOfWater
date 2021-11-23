using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingDolphin : MonoBehaviour
{
    States state;
    PlayerController playerController;
    public GameObject Bullet;
    private GameObject Player;
    private Vector3 Target;
    private float FireRate;
    private float NextFire;
    void Start()
    {
        FireRate = 0.2f;
        NextFire = -1f;
        Player = GameObject.FindGameObjectWithTag("Player");
        playerController = Player.GetComponent<PlayerController>();
        state = States.Alive;
    }

    void Update()
    {
        if(Player != null)
        {
            if (Player.transform.position.x > transform.parent.position.x)
            {
                transform.parent.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                transform.parent.eulerAngles = new Vector3(0, 0, 0);
            }
        }
        if (NextFire > 0)
        {
            NextFire -= Time.deltaTime;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (state == States.Alive)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                if (NextFire < 0)
                {
                    GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);
                    Target = Player.transform.position - transform.position;
                    bullet.GetComponent<Rigidbody2D>().velocity = Target * 5f;
                    NextFire = FireRate;
                }
            }
        }
    }
}
