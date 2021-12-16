using System.Collections.Generic;
using UnityEngine;

public class DisplayAmmo : MonoBehaviour
{
    public GameObject ammoCounter;
    public List<GameObject> ammoCounterList = new List<GameObject>();

    private int numOfAmmo;
    private Vector2 spawnDir, spawnPos;
    private float radius, radians, vertical, horizontal;

    private GameObject[] bullets;
    private GunController gunController;
    private SpriteRenderer spriteRenderer;

    private GameObject Player;

    private void Start()
    {
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
        Debug.Log(gunController.ammo);
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

    public void removeAmmo()
    {
        if (ammoCounterList.Count > 0)
        {
            spriteRenderer = ammoCounterList[0].GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color(1f, 1f, 1f, .3f);
            ammoCounterList.Remove(ammoCounterList[0]);
        }
    }

    public void addAmmo()
    {
        ammoCounterList.Clear();
        for (int i = 0; i < bullets.Length; i++)
            Destroy(bullets[i]);
        CreateAmmoAroundPoint();
    }
}