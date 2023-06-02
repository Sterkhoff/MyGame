public class LevelInfo
{
    public string DescriptionText = "";
    public List<Point> TrapsLocations = new ();
    public Point FinishLocation;
    public Point StartPosition;
    public Point BellLocation;
    public List<Point> EnemiesLocations = new ();
    public bool IsFinished { get; private set; }

    public void FinishLevel()
    {
        IsFinished = true;
    }
}