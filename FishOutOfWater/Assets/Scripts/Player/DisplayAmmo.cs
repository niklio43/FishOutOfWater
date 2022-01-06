using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class DisplayAmmo : MonoBehaviour
{
    public int shotsTaken;
    public bool isReloading;
    public GameObject ammoCounter;
    public List<GameObject> ammoCounterList = new List<GameObject>();

    private GameObject Player;
    private Vector2 spawnDir, spawnPos;
    private SpriteRenderer spriteRenderer;
    private float radius, radians, vertical, horizontal;

    private void Start()
    {
        radius = 2;
        shotsTaken = 0;
        isReloading = false;
        Player = GameObject.FindGameObjectWithTag("Player");
        CreateAmmoAroundPoint();
    }

    private void Update()
    {
        transform.position = Player.transform.position;
    }

    public void CreateAmmoAroundPoint()
    {
        for (int i = 0; i <= 11; i++)
        {

            radians = Mathf.PI / 11 * i;

            vertical = Mathf.Sin(radians);
            horizontal = Mathf.Cos(radians);

            spawnDir = new Vector2(horizontal, vertical);

            spawnPos = new Vector2(transform.position.x, transform.position.y + 1.8f) + spawnDir * radius;

            ammoCounterList.Add(Instantiate(ammoCounter, spawnPos, Quaternion.Euler(0, 0, 0), gameObject.transform) as GameObject);
        }
    }

    public IEnumerator ReloadAmmo()
    {
        for (int i = shotsTaken - 1; i >= 0; i--)
        {
            isReloading = true;

            spriteRenderer = ammoCounterList[i].GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.white;

            yield return new WaitForSeconds(0.02f);
        }
        shotsTaken = 0;
        isReloading = false;
    }

    public void ReloadAmmoNoTimer()
    {
        for (int i = 0; i < shotsTaken; i++)
        {
            isReloading = true;

            spriteRenderer = ammoCounterList[i].GetComponent<SpriteRenderer>();
            spriteRenderer.color = Color.white;
        }
        shotsTaken = 0;
        isReloading = false;
    }

    public void RemoveAmmo()
    {
        if (shotsTaken < 12)
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