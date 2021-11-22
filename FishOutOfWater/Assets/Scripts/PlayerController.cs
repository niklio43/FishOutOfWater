using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D Body;
    //private Vector3 PlayerPos;
    //private Quaternion PlayerRotation;
    private float moveSpeed;
    private float x;
    private float y;

    float Horizontal;
    float Vertical;

    private GameObject Gun;
    private GunController gunController;
    void Start()
    {
        Gun = GameObject.FindGameObjectWithTag("Gun");
        gunController = Gun.GetComponent<GunController>();
        Body = GetComponent<Rigidbody2D>();
        //PlayerPos = transform.position;
        //PlayerRotation = transform.rotation;
        moveSpeed = 10.0f;
        x = 0;
        y = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");
        Vertical = Input.GetAxisRaw("Vertical");
        if (Horizontal > 0)
        {
            Vertical = 0;
            x = 1;
            transform.eulerAngles = new Vector3(0, 0, 0);
            gunController.Fire(-x, 0);
        }
        else if (Vertical > 0)
        {
            Horizontal = 0;
            y = 1;
            transform.eulerAngles = new Vector3(0, 0, 90);
            gunController.Fire(0, -y);
        }
        if (Horizontal < 0)
        {
            Vertical = 0;
            x = -1;
            transform.eulerAngles = new Vector3(0, 180, 0);
            gunController.Fire(-x, 0);
        }
        else if (Vertical < 0)
        {
            Horizontal = 0;
            y = -1;
            transform.eulerAngles = new Vector3(0, 0, -90);
            gunController.Fire(0, -y);
        }
    }

    public void Move()
    {
        Body.velocity = new Vector2(Horizontal * moveSpeed, Vertical * moveSpeed);
    }

}
