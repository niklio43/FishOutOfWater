using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class DisplayAmmo : MonoBehaviour
{
    public GameObject ammoCounter;
    public List<GameObject> ammoCounterList = new List<GameObject>();
    int shotsTaken;
    private int numOfAmmo;
    private Vector2 spawnDir, spawnPos;
    private float radius, radians, vertical, horizontal;

    private GameObject[] bullets;
    private GunController gunController;
    private SpriteRenderer spriteRenderer;

    private GameObject Player;

    public bool isReloading;

    private void Start()
    {
        isReloading = false;
        shotsTaken = 0;
        Player = GameObject.FindGameObjectWithTag("Player");
        radius = 2;
        gunController = GameObject.FindGameObjectWithTag("Gun").GetComponent<GunController>();
        numOfAmmo = gunController.ammo - 1;
        CreateAmmoAroundPoint();
    }

    private void Update()
    {
        transform.position = Player.transform.position;
        bullets = GameObject.FindGameObjectsWithTag("ammoCounter");
    }

    public void CreateAmmoAroundPoint()
    {
        for (int i = 0; i <= numOfAmmo; i++)
        {

            radians = Mathf.PI / numOfAmmo * i;

            vertical = Mathf.Sin(radians);
            horizontal = Mathf.Cos(radians);

            spawnDir = new Vector2(horizontal, vertical);

            spawnPos = new Vector2(transform.position.x, transform.position.y + 1.8f) + spawnDir * radius;

            ammoCounterList.Add(Instantiate(ammoCounter, spawnPos, Quaternion.Euler(0, 0, 0), gameObject.transform) as GameObject);
        }
    }

    public IEnumerator ReloadAmmo()
    {
        for(int i = 0; i < shotsTaken; i++)
        {
            isReloading = true;

            spriteRenderer = ammoCounterList[i].GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.white;

            yield return new WaitForSeconds(0.02f);
        }
        shotsTaken = 0;
        isReloading = false;
    }

    public void RemoveAmmo()
    {
        if (ammoCounterList.Count >= 0)
        {
            spriteRenderer = ammoCounterList[shotsTaken].GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.gray;
            shotsTaken++;
        }
    }

    public void AddAmmo()
    {
        StartCoroutine(ReloadAmmo());
    }
}