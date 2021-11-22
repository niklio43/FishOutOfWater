using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject Bullet;
    public void Fire(float x, float y)
    {   
        GameObject bullet = Instantiate(Bullet, transform.position, transform.rotation);
        Destroy(bullet, 5);
        Rigidbody2D Body = bullet.GetComponent<Rigidbody2D>();
        Body.velocity = new Vector2(x, y);
    }
}
