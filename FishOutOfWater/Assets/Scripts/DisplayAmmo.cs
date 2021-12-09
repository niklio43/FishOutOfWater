using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayAmmo : MonoBehaviour
{
    public GameObject enemyPefab;
    private GunController gunController;
    private float radius, radians, vertical, horizontal;
    private Vector2 point, spawnDir, spawnPos;
    private int numOfAmmo;
    private GameObject ammoCounter;
    private bool finished;
    public List<GameObject> ammoCounterList = new List<GameObject>();

    private void Start()
    {
        finished = false;
        gunController = gameObject.transform.GetChild(0).GetComponent<GunController>();
        point = transform.position;
        radius = 2;
    }

    private void Update()
    {
        numOfAmmo = gunController.ammo;
        if (!finished)
        {
            for (int i = 0; i <= numOfAmmo; i++)
            {
                radians = Mathf.PI / numOfAmmo * i;

                vertical = Mathf.Sin(radians);
                horizontal = Mathf.Cos(radians);

                spawnDir = new Vector2(horizontal, vertical);

                spawnPos = point + spawnDir * radius;

                if(i == numOfAmmo)
                {
                    finished = true;
                }
                CreateAmmoAroundPoint();
            }
        }
    }

    public void CreateAmmoAroundPoint()
    {
        ammoCounterList.Add(Instantiate(enemyPefab, spawnPos, transform.rotation, gameObject.transform) as GameObject);
    }

    public void RemoveAmmoAroundPoint()
    {
        ammoCounterList.Remove(ammoCounterList[0]);
    }
}
