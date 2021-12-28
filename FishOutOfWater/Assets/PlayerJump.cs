using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpforce = 10f;
    public KeyCode MoveUp;
    //Rigidbody rb;
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if (Input.GetKey(MoveUp))
        {
            transform.Translate(Vector2.up * jumpforce * Time.deltaTime);
           //rb.AddForce(Vector3.up * jumpforce);
        }
    }
}
 