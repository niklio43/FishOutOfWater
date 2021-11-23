using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D Body;
    private float moveSpeed;
    float Horizontal;
    float Vertical;

    private Vector2 PlayerPos;

    private GameObject[] Ground;
    private GameObject Gun;
    private GunController gunController;

    private bool maxHeightReached;
    void Start()
    {
        maxHeightReached = false;
        Ground = GameObject.FindGameObjectsWithTag("Ground");
        Gun = GameObject.FindGameObjectWithTag("Gun");
        gunController = Gun.GetComponent<GunController>();
        Body = GetComponent<Rigidbody2D>();
        moveSpeed = 10.0f;
    }

    void Update()
    {
        PlayerPos = transform.position;
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        if (Horizontal > 0)
        {
            Vertical = 0;
            transform.eulerAngles = new Vector3(0, 0, 0);
            gunController.Fire(-Horizontal, Vertical);
        }
        else if (Vertical > 0)
        {
            Horizontal = 0;
            transform.eulerAngles = new Vector3(0, 0, 90);
            gunController.Fire(Horizontal, -Vertical);
        }
        if (Horizontal < 0)
        {
            Vertical = 0;
            transform.eulerAngles = new Vector3(0, 180, 0);
            gunController.Fire(-Horizontal, Vertical);
        }
        else if (Vertical < 0)
        {
            Horizontal = 0;
            transform.eulerAngles = new Vector3(0, 0, -90);
            gunController.Fire(Horizontal, -Vertical);
        }

        if (Vertical == 0 && Horizontal == 0)
        {
            Body.gravityScale = 8f;
        }else
        {
            Move();
        }
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(new Vector2(transform.position.x, transform.position.y-1), -Vector2.up);

        if (hit.collider != null)
        {
            for(int i = 0; i < Ground.Length; i++)
            {
                GameObject obj = hit.collider.gameObject;

                Debug.Log(obj.name);
                if (PlayerPos.y - obj.transform.position.y > 5)
                {
                    maxHeightReached = true;
                    Debug.Log(obj.name);
                }else
                {
                    maxHeightReached = false;
                }
            }
        }
    }

    public void Move()
    {
        if (maxHeightReached)
        {
            Vertical = 0;
        }
        Body.gravityScale = 0f;
        Body.velocity = new Vector2(Horizontal * moveSpeed, Vertical * moveSpeed);
    }

}
