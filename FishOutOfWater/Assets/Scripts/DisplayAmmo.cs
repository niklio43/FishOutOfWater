using System.Collections.Generic;
using UnityEngine;

public class DisplayAmmo : MonoBehaviour
{
    public GameObject ammoCounter;
    private GunController gunController;
    private float radius, radians, vertical, horizontal;
    private Vector2 point, spawnDir, spawnPos;
    private int numOfAmmo;
    public List<GameObject> ammoCounterList = new List<GameObject>();
    private SpriteRenderer spriteRenderer;
    private GameObject[] bullets;

    private void Start()
    {
        gunController = gameObject.transform.GetChild(0).GetComponent<GunController>();
        point = transform.position;
        radius = 2;
        numOfAmmo = gunController.ammo - 1;
        CreateAmmoAroundPoint();
    }

    private void Update()
    {
        point = transform.position;
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

            spawnPos = new Vector2(point.x, point.y + 1.8f) + spawnDir * radius;

            ammoCounterList.Add(Instantiate(ammoCounter, spawnPos, Quaternion.Euler(0, 0, 0), gameObject.transform) as GameObject);
        }
    }

    public void removeAmmo()
    {
        if(ammoCounterList.Count > 0)
        {
            spriteRenderer = ammoCounterList[0].GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color(1f, 1f, 1f, .3f);
            ammoCounterList.Remove(ammoCounterList[0]);
        }
    }

    public void addAmmo()
    {
        ammoCounterList.Clear();
        for(int i = 0; i < bullets.Length; i++)
            Destroy(bullets[i]);
        CreateAmmoAroundPoint();
    }
}
