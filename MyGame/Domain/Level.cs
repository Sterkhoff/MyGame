using System.Runtime.CompilerServices;

namespace MyGame.Domain;

public class Level
{
    public string DescriptionText = "";
    public List<Point> Enemies2Locations = new ();
    public List<Point> TrapsLocations = new ();
    public Point FinishLocation;
    public Point StartPoint;
    public Point BellLocation;
    public List<Point> Enemies1Locations = new ();
    public bool IsFinished { get; private set; }

    public void FinishLevel()
    {
        IsFinished = true;
    }
}