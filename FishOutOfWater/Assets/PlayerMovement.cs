using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public KeyCode MoveRight;
    public KeyCode MoveLeft;



    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetKey(MoveRight))
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(MoveLeft))
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }

    }
}
