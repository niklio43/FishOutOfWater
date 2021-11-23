using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D Body;
    private float moveSpeed;
    float Horizontal;
    float Vertical;

    private GameObject Gun;
    private GunController gunController;
    void Start()
    {
        Gun = GameObject.FindGameObjectWithTag("Gun");
        gunController = Gun.GetComponent<GunController>();
        Body = GetComponent<Rigidbody2D>();
        moveSpeed = 10.0f;
    }

    void Update()
    {
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
    }

    public void Move()
    {
        Body.velocity = new Vector2(Horizontal * moveSpeed, Vertical * moveSpeed);
    }

}
