using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetTrigger : MonoBehaviour
{

    private FishNetDolphin fishNetDolphin;
    private GameObject Player;
    public GameObject fishNet;

    public bool throwing;

    public bool isActive;

    private void Start()
    {
        throwing = false;
        fishNetDolphin = transform.GetComponentInParent<FishNetDolphin>();
        Player = GameObject.FindGameObjectWithTag("Player");
        isActive = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !fishNetDolphin.dead && Player != null)
        {
            throwing = true;
            if (!isActive)
            {
                Instantiate(fishNet, new Vector2(fishNetDolphin.fishNetStartPos.x, fishNetDolphin.fishNetStartPos.y), transform.rotation);
                isActive = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !fishNetDolphin.dead && Player != null)
        {
            throwing = false;
        }
    }
}
