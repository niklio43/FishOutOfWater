using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject Bullet;

    private float fireRate;
    private float nextFire;

    private GameObject Player;
    private PlayerController playerController;

    private void Start()
    {
        fireRate = 0.1f;
        nextFire = -1f;
        Player = GameObject.FindGameObjectWithTag("Player");
        playerController = Player.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (nextFire > 0)
        {
            nextFire -= Time.deltaTime;
        }
    }

    public void Fire(float Horizontal, float Vertical)
    {
        if(nextFire < 0)
        {
            GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);
            Destroy(bullet, 2);
            Rigidbody2D Body = bullet.GetComponent<Rigidbody2D>();
            Body.velocity = new Vector2(Horizontal, Vertical) * 10f;
            nextFire = fireRate;
        }
    }
}
