using UnityEngine;

public class CutsceneMove : MonoBehaviour
{
    public Vector3 targetPos;

    //private int randomNumber;
    private float speed = 0.1f;
    private bool stopMoving;
    private float startTime;
    private float length;

    void Start()
    {
        startTime = Time.time;
        length = Vector3.Distance(transform.position, targetPos);
        stopMoving = false;
    }

    void Update()
    {
        if (!stopMoving)
        {
            Move();
        }
    }

    private void Move()
    {
        float distance = (Time.time - startTime) * speed;
        float remaining = distance / length;

        transform.position = Vector3.Lerp(transform.position, targetPos, remaining);

        if (transform.position == targetPos)
        {
            stopMoving = true;
        }
    }

}
