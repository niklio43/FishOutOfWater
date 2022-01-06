[System.Serializable]
public class GameData
{
    public int scene;
    public int deathCounter;
    public float timePlayed;

    public GameData(Checkpoint checkpoint)
    {
        scene = checkpoint.scene;
    }
}
