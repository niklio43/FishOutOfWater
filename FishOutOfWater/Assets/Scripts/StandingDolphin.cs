using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingDolphin : MonoBehaviour
{
    public States state;
    public GameObject Bullet;

    private Vector3 Target;
    private float fireRate;
    private float nextFire;

    private GameObject Player;
    private PlayerHealth playerHealth;

    void Start()
    {
        fireRate = 0.2f;
        nextFire = -1f;
        state = States.Alive;
        Player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = Player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        if (Player != null && state == States.Alive)
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
        if (nextFire > 0)
        {
            nextFire -= Time.deltaTime;
        }
    }

    //If player enters trigger, dolphin starts shooting towards player
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (playerHealth.state == States.Alive && state == States.Alive)
        {
            if (collision.gameObject.CompareTag("Player") && nextFire < 0)
            {
                GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);
                Target = Player.transform.position - transform.position;
                bullet.GetComponent<Rigidbody2D>().velocity = Target * 5f;
                nextFire = fireRate;
            }
        }
    }
}
