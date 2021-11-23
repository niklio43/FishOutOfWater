using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject Bullet;
    private GameObject Player;
    private float FireRate;
    private float NextFire;

    private void Start()
    {
        FireRate = 0.1f;
        NextFire = -1f;
        Player = GameObject.FindGameObjectWithTag("Player");
        playerController = Player.GetComponent<PlayerController>();
    }

    void Update()
    {
        if (NextFire > 0)
        {
            NextFire -= Time.deltaTime;
        }
    }

    public void Fire(float Horizontal, float Vertical)
    {
        if(NextFire < 0)
        {
            GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);
            Destroy(bullet, 3);
            Rigidbody2D Body = bullet.GetComponent<Rigidbody2D>();
            Body.velocity = new Vector2(Horizontal, Vertical) * 10f;
            NextFire = FireRate;
        }
    }
}
