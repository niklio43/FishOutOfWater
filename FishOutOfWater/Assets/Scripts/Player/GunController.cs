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

    private WeaponUpgrades state;
    private GameObject sound;
    private GameObject Player;

    private DisplayAmmo displayAmmo;

    private Vector2 playerGunArm;

    private FishNetController fishNetController;

    private GameObject fishNet;

    private void Awake()
    {
        ammo = 12;
    }

    private void Start()
    {
        fishNet = GameObject.FindGameObjectWithTag("FishNet");
        if (GameObject.FindGameObjectWithTag("FishNet") != null)
            fishNetController = GameObject.FindGameObjectWithTag("FishNet").GetComponent<FishNetController>();
        Player = GameObject.FindGameObjectWithTag("Player");
        sound = GameObject.FindGameObjectWithTag("AudioManager");
        displayAmmo = GameObject.FindGameObjectWithTag("AmmoCounterHolder").GetComponent<DisplayAmmo>();
        state = WeaponUpgrades.Spray;
        startTimeBtwShots = 0.15f;
        playerHealth = Player.GetComponent<PlayerHealth>();
        playerController = Player.GetComponent<PlayerController>();
    }

    private void Update()
    {
        playerGunArm = GameObject.FindGameObjectWithTag("PlayerGunArm").transform.position;
        transform.rotation = GameObject.FindGameObjectWithTag("PlayerGunArm").transform.rotation;
        transform.position = playerGunArm;

        if (state == WeaponUpgrades.Spray && playerHealth.currentHealth > 0 && timeBtwShots <= 0 && !displayAmmo.isReloading)
        {
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                if (fishNet == null)
                {
                    playerController.SetPlayerRotation(1, 0);
                    playerController.SwitchGravity(0f);
                    Fire(1, 0);
                }
                else if (fishNet != null && !fishNetController.caughtByFishNet)
                {
                    playerController.SetPlayerRotation(1, 0);
                    playerController.SwitchGravity(0f);
                    Fire(1, 0);
                }
            }
            else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                if (fishNet == null)
                {
                    playerController.SetPlayerRotation(-1, 0);
                    playerController.SwitchGravity(0f);
                    Fire(-1, 0);
                }
                else if (fishNet != null && !fishNetController.caughtByFishNet)
                {
                    playerController.SetPlayerRotation(-1, 0);
                    playerController.SwitchGravity(0f);
                    Fire(-1, 0);
                }
            }
            else if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                if (fishNet == null)
                {
                    playerController.SetPlayerRotation(0, 1);
                    playerController.SwitchGravity(8.92f);
                    Fire(0, 1);
                }
                else if (fishNet != null && !fishNetController.caughtByFishNet)
                {
                    playerController.SetPlayerRotation(0, 1);
                    playerController.SwitchGravity(8.92f);
                    Fire(0, 1);
                }
            }
            else if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
            {
                if (fishNet == null)
                {
                    playerController.SetPlayerRotation(0, -1);
                    playerController.SwitchGravity(8.92f);
                    Fire(0, -1);
                }
                else if (fishNet != null && !fishNetController.caughtByFishNet)
                {
                    playerController.SetPlayerRotation(0, -1);
                    playerController.SwitchGravity(8.92f);
                    Fire(0, -1);
                }
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
        if (playerController.isGrounded && ammo <= 0 || Input.GetKeyDown(KeyCode.Space) && playerController.isGrounded)
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
            if (directionX > 0 && directionY == 0 || directionX < 0 && directionY == 0)
            {
                anim.SetTrigger("isShooting");
            }
            if (directionY > 0 && directionX == 0)
            {
                anim.SetTrigger("isShootingUp");
            }
            if (directionY < 0 && directionX == 0)
            {
                anim.SetTrigger("isShootingDown");
            }
            sound.GetComponent<AudioController>().Play("Player Fire");
            Destroy(bullet, 3);
        }
    }

    public void Reload()
    {
        displayAmmo.addAmmo();
        ammo = 12;
    }
}