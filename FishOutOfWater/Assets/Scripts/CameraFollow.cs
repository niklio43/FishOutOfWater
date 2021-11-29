using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float smoothSpeed = 0.125f;

    public Transform target;

    private Vector3 offest;

    private void Start()
    {
        offest = new Vector3(0, 2, -20);
    }
    private void FixedUpdate()
    {
        Vector3 desiredPosition = target.position + offest;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
