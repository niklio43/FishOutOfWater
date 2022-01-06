using UnityEngine;

public class Alerted : MonoBehaviour
{
    public bool isActive, playSound;
    public GameObject AlertedPrefab;

    private Vector3 pos;
    private GameObject exclamation;
    private StandingDolphin standingDolphin;

    //Hover speed
    [SerializeField]
    float speed = 5f;
    //Max height
    [SerializeField]
    float height = 0.2f;

    void Start()
    {
        standingDolphin = GetComponent<StandingDolphin>();
        DrawAlerted();
        pos = exclamation.transform.position;
        exclamation.SetActive(false);
        isActive = false;
        playSound = false;
    }

    private void Update()
    {
        var distance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        if (distance < 14 && distance > 9 && standingDolphin.isDead == false)
        {
            exclamation.SetActive(true);
            isActive = true;
        }
        else
        {
            exclamation.SetActive(false);
            isActive = false;
            playSound = false;
        }

        if (standingDolphin.isDead)
        {
            isActive = false;
        }

        if(isActive)
        {
            //Calculates new y position
            float newY = Mathf.Sin(Time.time * speed) * height + pos.y;

            //Sets the new y position
            exclamation.transform.position = new Vector3(exclamation.transform.position.x, newY, exclamation.transform.position.z);
        }
    }

    void DrawAlerted()
    {
        exclamation = Instantiate(AlertedPrefab, new Vector2(transform.position.x, transform.position.y + 5f), transform.rotation);
    }
}
