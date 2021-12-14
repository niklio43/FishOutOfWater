using UnityEngine;

public class CheckpointMaster : MonoBehaviour
{
    public Vector2 lastCPPos;

    private static CheckpointMaster instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
