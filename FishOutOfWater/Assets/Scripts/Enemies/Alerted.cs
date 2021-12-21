using UnityEngine;

public class Alerted : MonoBehaviour
{
    public bool isActive, playSound;
    public GameObject AlertedPrefab;

    private Vector3 pos;
    private AudioController sound;
    private GameObject exclamation;
    private StandingDolphin standingDolphin;

    //hover speed
    [SerializeField]
    float speed = 5f;
    //max height
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
        sound = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioController>();
    }

    private void Update()
    {
        var distance = Vector3.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);
        if(distance < 14 && distance > 9)
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

        if(isActive)
        {
            //kalkylerar nya y positionen
            float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
            //sätter nya positionen
            exclamation.transform.position = new Vector3(exclamation.transform.position.x, newY, exclamation.transform.position.z);
        }

        if(isActive && !playSound && !standingDolphin.isDead)
        {
            sound.PlayOnce("Alert Sound");
            playSound = true;
        }
    }

    void DrawAlerted()
    {
        exclamation = Instantiate(AlertedPrefab, new Vector2(transform.position.x, transform.position.y + 5f), transform.rotation);
    }
}
