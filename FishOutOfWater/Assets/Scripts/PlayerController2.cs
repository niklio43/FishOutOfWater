using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    private float thrust;

    private void Start()
    {
        thrust = 35f;
        rb = GetComponent<Rigidbody2D>();
    }

    public void Movement(int directionX, int directionY)
    {
        rb.velocity = new Vector2(-directionX, -directionY) * thrust;
    }

    public void SetPlayerRotation(int Horizontal, int Vertical)
    {
        if (Horizontal > 0 && Vertical == 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
        else if(Horizontal < 0 && Vertical == 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        if (Vertical > 0 && Horizontal == 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
        else if (Vertical < 0 && Horizontal == 0)
        {
            transform.eulerAngles = new Vector3(0, 0, -90);
        }
    }


    public void SwitchGravity(float GravityScale)
    {
        rb.gravityScale = GravityScale;
    }
}
