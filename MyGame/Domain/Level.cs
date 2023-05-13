namespace MyGame.Domain;

public class Level
{
    public Level(Point startPoint, Point finishLocation, Point[] enemiesLocations, Point[] trapsLocations)
    {
        TrapsLocations = trapsLocations;
        StartPoint = startPoint;
        EnemiesLocations = enemiesLocations;
        FinishLocation = finishLocation;
    }

    public Point[] TrapsLocations;
    public Point FinishLocation;
    public Point StartPoint;
    public Point[] EnemiesLocations;
    public bool Finished = false;
}