using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothSpeed;

    public Transform target;

    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        if (target)
        {
            Vector3 delta = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, transform.position.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, smoothSpeed);
        }
    }
}
