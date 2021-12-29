using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public int startingPoint;
    public Transform[] points;

    private int i;
    // Startposition between the two existing points
    void Start()
    {
        transform.position = points[startingPoint].position;
    }

    // If position is less than, change position between two said points
    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].position) < 0.02f)
        {
            i++;
            if (i == points.Length)
            {
                i = 0;
            }
        }
        //Go to next position, existing points in unity
        transform.position = Vector2.MoveTowards(transform.position, points[i].position, speed * Time.deltaTime);
    }

    //
    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }

   /* if (collision.gameObject.CompareTag("EnemyBullet"))
        {
            Destroy(collision.gameObject);
    playerHealth.TakeDamage(20);
            sound.GetComponent<AudioController>().Play("Player Damage");*/
}

