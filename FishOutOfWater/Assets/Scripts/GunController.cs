using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunController : MonoBehaviour
{
    public Transform shotPoint;
    public GameObject projectile;

    private float timeBtwShots, startTimeBtwShots;

    private PlayerController playerController;
    private PlayerHealth playerHealth;

    public int ammo;

    public ParticleSystem reloadPS;

    public Animator anim;
    private bool isShooting;

    private WeaponUpgrades state;
    private GameObject sound;
    private GameObject Player;

    private DisplayAmmo displayAmmo;

    private void Start()
    {
        isShooting = false;
        Player = GameObject.FindGameObjectWithTag("Player");
        sound = GameObject.FindGameObjectWithTag("AudioManager");
        displayAmmo = Player.GetComponent<DisplayAmmo>();
        state = WeaponUpgrades.Regular;
        ammo = 12;
        startTimeBtwShots = 0.1f;
        playerHealth = Player.GetComponent<PlayerHealth>();
        playerController = Player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        anim.SetBool("isShooting", isShooting);
        if (timeBtwShots <= 0 && playerHealth.currentHealth > 0 && state == WeaponUpgrades.Regular)
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
                playerController.SwitchGravity(8.92f);
                Fire(0, 1);
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                playerController.SwitchGravity(8.92f);
                Fire(0, -1);
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }

        if (state == WeaponUpgrades.Spray && playerHealth.currentHealth > 0 && timeBtwShots <= 0)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                playerController.SetPlayerRotation(1, 0);
                playerController.SwitchGravity(0f);
                Fire(1, 0);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                playerController.SetPlayerRotation(-1, 0);
                playerController.SwitchGravity(0f);
                Fire(-1, 0);
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                playerController.SetPlayerRotation(0, 1);
                playerController.SwitchGravity(8.92f);
                Fire(0, 1);
            }
            else if (Input.GetKey(KeyCode.UpArrow))
            {
                playerController.SetPlayerRotation(0, -1);
                playerController.SwitchGravity(8.92f);
                Fire(0, -1);
            }
        }

        if (playerController.rb.velocity.x < 4f && playerController.rb.velocity.x > -4f)
        {
            playerController.SwitchGravity(8.92f);
        }

    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerController.isGrounded)
        {
            reloadPS.Play();
            Invoke("Reload", 0f); //reload timer
            sound.GetComponent<AudioController>().Play("Reload");
        }
    }

    public void Fire(int directionX, int directionY)
    {
        if (!playerController.isGrounded && ammo >= 0)
        {
            displayAmmo.removeAmmo();
            ammo--;
        }
        if (ammo >= 0)
        {
            GameObject bullet = Instantiate(projectile, shotPoint.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(directionX, directionY) * 20f;
            playerController.Movement(directionX, directionY);
            timeBtwShots = startTimeBtwShots;
            isShooting = true;
            Invoke("ResetBool", 0.5f);
            sound.GetComponent<AudioController>().Play("Player Fire");
            Destroy(bullet, 3);
        }
    }

    private void ResetBool()
    {
        isShooting = false;
    }

    public void Reload()
    {
        displayAmmo.addAmmo();
        ammo = 12;
    }
}