using System.Collections.Generic;
using UnityEngine;

public class DisplayAmmo : MonoBehaviour
{
    public GameObject enemyPefab;
    private GunController gunController;
    private float radius, radians, vertical, horizontal;
    private Vector2 point, spawnDir, spawnPos;
    private int numOfAmmo;
    public List<GameObject> ammoCounterList = new List<GameObject>();
    public List<GameObject> reloadList = new List<GameObject>();
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        gunController = gameObject.transform.GetChild(0).GetComponent<GunController>();
        point = transform.position;
        radius = 2;
        numOfAmmo = gunController.ammo - 1;
        CreateAmmoAroundPoint();
    }


    public void CreateAmmoAroundPoint()
    {
        for (int i = 0; i <= numOfAmmo; i++)
        {
            radians = Mathf.PI / numOfAmmo * i;

            vertical = Mathf.Sin(radians);
            horizontal = Mathf.Cos(radians);

            spawnDir = new Vector2(horizontal, vertical);

            spawnPos = point + spawnDir * radius;

            ammoCounterList.Add(Instantiate(enemyPefab, spawnPos, Quaternion.Euler(0, 0, 0), gameObject.transform) as GameObject);
        }
    }

    public void removeAmmo()
    {
        if(ammoCounterList.Count > 0)
        {
            spriteRenderer = ammoCounterList[0].GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color(1f, 1f, 1f, .3f);
            reloadList.Add(ammoCounterList[0]);
            ammoCounterList.Remove(ammoCounterList[0]);

        }
    }

    public void addAmmo()
    {
        for (int i = 0; i < reloadList.Count; i++)
        {
            Debug.Log("name: " + reloadList[i].name);
            Debug.Log("i: " + i);
            spriteRenderer = reloadList[i].GetComponent<SpriteRenderer>();
            spriteRenderer.color = new Color(1f, 1f, 1f, 1f);
            ammoCounterList.Add(reloadList[i]);
            if(i == reloadList.Count -1)
                reloadList.Clear();
        }
    }
}
