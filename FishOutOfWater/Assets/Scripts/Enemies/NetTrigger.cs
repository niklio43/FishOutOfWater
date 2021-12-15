using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetTrigger : MonoBehaviour
{

    private FishNetDolphin fishNetDolphin;
    private GameObject Player;
    public GameObject fishNet;
    public Vector3 targetPos;

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
            fishNetDolphin.setPos = true;
            targetPos = new Vector3(Player.transform.position.x, Player.transform.position.y + 5, Player.transform.position.z); 
            GetComponent<Collider2D>().enabled = false;
            Invoke("EnableCollider", 2f);
        }
    }

    void EnableCollider()
    {
        GetComponent<Collider2D>().enabled = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !fishNetDolphin.dead && Player != null && Player.GetComponent<PlayerController>().isGrounded)
        {
            throwing = false;
        }
    }
}
