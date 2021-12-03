using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public static CameraShake instance;
    Vector3 startPos;
    float elapsedTime;

    void Awake()
    {
        elapsedTime = 0;
        instance = this;
    }

    void Update()
    {
        startPos = transform.position;
    }

    IEnumerator Shake(float duration)
    {
        while(elapsedTime < duration)
        {
            transform.position = new Vector3(startPos.x + Random.Range(-0.3f, 0.3f), startPos.y + Random.Range(-0.3f, 0.3f), transform.position.z);
            yield return new WaitForSeconds(0.05f);
            elapsedTime += Time.deltaTime * 35;
        }
        transform.position = startPos;
    }

    public void ShakeMe(float duration)
    {
        StartCoroutine(Shake(duration));
    }

}