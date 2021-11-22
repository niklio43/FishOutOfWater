using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D Body;
    private Vector3 PlayerPos;
    private float moveSpeed;
    private float x;
    private float y;

    private GameObject Gun;
    private GunController gunController;
    void Start()
    {
        Gun = GameObject.FindGameObjectWithTag("Gun");
        gunController = Gun.GetComponent<GunController>();
        Body = GetComponent<Rigidbody2D>();
        PlayerPos = transform.position;
        moveSpeed = 90f;
        x = 0;
        y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            x = -1;
            gunController.Fire(-x, 0);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            x = 1;
            gunController.Fire(-x, 0);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            y = 1;
            gunController.Fire(0, -y);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            y = -1;
            gunController.Fire(0, -y);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            x = 0;
        }
        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            y = 0;
        }
        Move();
    }

    void Move()
    {
        Vector3 Movement = new Vector3(x, y) * moveSpeed * Time.deltaTime;
        Body.velocity = Movement;
    }

}
