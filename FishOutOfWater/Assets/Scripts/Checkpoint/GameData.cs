[System.Serializable]
public class GameData
{
    public int scene;
    public float timePlayed;

    public GameData(Checkpoint checkpoint)
    {
        scene = checkpoint.scene;
        timePlayed = checkpoint.timePlayed;
    }
}
