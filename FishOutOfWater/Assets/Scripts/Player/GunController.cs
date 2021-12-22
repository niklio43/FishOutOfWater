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
    private AudioController sound;
    private GameObject Player;

    private DisplayAmmo displayAmmo;
    private bool playOnce;
    private Vector2 playerGunArm;

    private FishNetController fishNetController;

    private GameObject fishNet;

    private GroundChecker groundChecker;

    private void Awake()
    {
        ammo = 13;
    }

    private void Start()
    {
        fishNet = GameObject.FindGameObjectWithTag("FishNet");
        if (GameObject.FindGameObjectWithTag("FishNet") != null)
            fishNetController = GameObject.FindGameObjectWithTag("FishNet").GetComponent<FishNetController>();
        Player = GameObject.FindGameObjectWithTag("Player");
        sound = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioController>();
        displayAmmo = GameObject.FindGameObjectWithTag("AmmoCounterHolder").GetComponent<DisplayAmmo>();
        state = WeaponUpgrades.Spray;
        startTimeBtwShots = 0.15f;
        playOnce = false;
        playerHealth = Player.GetComponent<PlayerHealth>();
        playerController = Player.GetComponent<PlayerController>();
        groundChecker = GameObject.FindGameObjectWithTag("PlayerBottom").GetComponent<GroundChecker>();
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
        if (groundChecker.isGrounded && ammo < 12 || Input.GetKeyDown(KeyCode.Space) && groundChecker.isGrounded)
        {
            reloadPS.Play();
            Invoke("Reload", 0f); //reload timer
            sound.Play("Reload");
        }
    }

    public void Fire(int directionX, int directionY)
    {
        if (!groundChecker.isGrounded && ammo > 0)
        {
            displayAmmo.RemoveAmmo();
            ammo--;
        }
        if (ammo > 0)
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
            sound.Play("Player Fire");
            Destroy(bullet, 3);
        }
        else if(ammo <= 0 && !playOnce)
        {
            StartCoroutine(OutOfAmmo());
            playOnce = true;
        }
    }

    public void Reload()
    {
        displayAmmo.AddAmmo();
        ammo = 13;
    }

    private IEnumerator OutOfAmmo()
    {
        sound.Play("Gun Click");
        yield return new WaitForSeconds(0.2f);
        playOnce = false;
    }
}