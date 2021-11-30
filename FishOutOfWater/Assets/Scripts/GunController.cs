using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Transform shotPoint;
    public GameObject projectile;

    private float timeBtwShots, startTimeBtwShots;
    private PlayerController playerController;
    private PlayerHealth playerHealth;

    private int ammo;

    private void Start()
    {

        ammo = 12;
        startTimeBtwShots = 0.2f;
        playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (timeBtwShots <= 0 && playerHealth.currentHealth > 0)
        {

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                playerController.SetPlayerRotation(1, 0);
                playerController.SwitchGravity(0f);
                Fire(1, 0);
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                playerController.SetPlayerRotation(-1, 0);
                playerController.SwitchGravity(0f);
                Fire(-1, 0);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                playerController.SetPlayerRotation(0, 1);
                playerController.SwitchGravity(8.92f);
                Fire(0, 1);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerController.SetPlayerRotation(0, -1);
                playerController.SwitchGravity(8.92f);
                Fire(0, -1);
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

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && ammo <= 0)
        {
            Invoke("Reload", 1.0f);
        }
    }

    public void Fire(int directionX, int directionY)
    {
        if(playerController.isGrounded == false)
        {
            ammo--;
        }
        if (ammo >= 0)
        {
            Debug.Log("Ammo: " + ammo);
            GameObject bullet = Instantiate(projectile, shotPoint.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(directionX, directionY) * 20f;
            playerController.Movement(directionX, directionY);
            timeBtwShots = startTimeBtwShots;
            Destroy(bullet, 3);
        }

        if (ammo < 0)
        {
            Debug.Log("Out of ammo, press Space to reload");
        }
    }

    public void Reload()
    {
        ammo = 12;
        Debug.Log("Chamber filled!");
    }
}