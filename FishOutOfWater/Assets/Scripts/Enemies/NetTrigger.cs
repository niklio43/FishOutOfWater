using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetTrigger : MonoBehaviour
{

    private FishNetDolphin fishNetDolphin;
    private GameObject Player;
    public GameObject fishNet;

    public bool throwing;


    private void Start()
    {
        throwing = false;
        fishNetDolphin = transform.GetComponentInParent<FishNetDolphin>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !fishNetDolphin.dead && Player != null)
        {
            throwing = true;
            fishNetDolphin.SetNewFishnetPos();
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
