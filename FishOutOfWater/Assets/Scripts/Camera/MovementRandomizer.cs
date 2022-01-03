using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementRandomizer : MonoBehaviour
{
    private Vector3 startPos;

    private Vector3 min, max;

    private float lerpSpeed = 0.05f;

    private void Awake()
    {
        startPos = new Vector3(0, 0, -70);
        min = new Vector3(-5, -5, -70);
        max = new Vector3(5, 5, -70);
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, startPos, Time.deltaTime * lerpSpeed);

        if(Vector3.Distance(transform.position, startPos) < 1f)
        {
            GetNewPosition();
        }
    }

    void GetNewPosition()
    {
        var xPos = Random.Range(min.x, max.x);
        var yPos = Random.Range(min.y, max.y);
        startPos = new Vector3(xPos, yPos, -70);
    }
}
