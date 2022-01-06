using UnityEngine;
//This script is legacy and is not being used anymore, saved for potential future purposes.
public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed;

    private Vector3 velocity = Vector3.zero;

    private void FixedUpdate()
    {
        if (target)
        {
            Vector3 aheadPoint = target.position +
                new Vector3(target.GetComponent<Rigidbody2D>().velocity.x * 0.8f, target.GetComponent<Rigidbody2D>().velocity.y * 0.5f, 0);

            Vector3 point = Camera.main.WorldToViewportPoint(aheadPoint);
            Vector3 delta = aheadPoint - Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
            Vector3 destination = transform.position + delta;
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, smoothSpeed);
        }
    }
}
