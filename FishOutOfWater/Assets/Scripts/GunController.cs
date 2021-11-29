using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;

    private PlayerController playerController;
    private float timeBtwShots, startTimeBtwShots;
    private PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        startTimeBtwShots = 0.2f;
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
            if (timeBtwShots <= 0 && playerHealth.currentHealth > 0)
            {

                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    playerController.SetPlayerRotation(1, 0);
                    Fire(1, 0);
                    playerController.SwitchGravity(0f);
                }
                else if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    playerController.SetPlayerRotation(-1, 0);
                    Fire(-1, 0);
                    playerController.SwitchGravity(0f);
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    playerController.SetPlayerRotation(0, 1);
                    Fire(0, 1);
                    playerController.SwitchGravity(8.92f);
                }
                else if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    playerController.SetPlayerRotation(0, -1);
                    Fire(0, -1);
                    playerController.SwitchGravity(8.92f);
                }
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }

            if (playerController.rb.velocity.x < 4f && playerController.rb.velocity.x > -4f)
            {
                playerController.SwitchGravity(8.92f);
            }
        
    }

    public void Fire(int directionX, int directionY)
    {
        GameObject bullet = Instantiate(projectile, shotPoint.position, transform.rotation);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(directionX, directionY) * 20f;
        playerController.Movement(directionX, directionY);
        timeBtwShots = startTimeBtwShots;
        Destroy(bullet, 3);
    }
}