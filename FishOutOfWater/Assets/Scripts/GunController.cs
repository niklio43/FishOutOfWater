using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    private PlayerController playerController;
    public GameObject Bullet;
    private GameObject Player;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        playerController = Player.GetComponent<PlayerController>();
    }

    public void Fire(float Horizontal, float Vertical)
    {
        GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);
        Destroy(bullet, 3);
        Rigidbody2D Body = bullet.GetComponent<Rigidbody2D>();
        Body.velocity = new Vector2(Horizontal, Vertical) * 5f;
        playerController.Move();
    }
}
