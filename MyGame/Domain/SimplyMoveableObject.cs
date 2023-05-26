namespace MyGame.Domain;

public enum Direcion
{
    Right,
    Left
}

public class SimplyMoveableObject : IGameObject
{
    public Size Size { get; set; }
    public bool IsCarried;
    private Point positionAfterStep;
    public bool IsMove;
    public int Moves;
    public Direcion Direction;
    public Point Location { get; set; }
    
    public void MoveToObject(Point objectLocation)
    {
        if (Math.Abs(Location.X - objectLocation.X) < 2 && Math.Abs(Location.Y - objectLocation.Y) < 2)
        {
            Moves = 0;
            return;
        }
        var angle = Math.Atan(Math.Abs(objectLocation.Y - Location.Y) /
                              (double)Math.Abs(objectLocation.X - Location.X));
        
        if ((double)Math.Abs(objectLocation.X - Location.X) == 0)
            angle = 0;
        if (objectLocation.X > Location.X)
        {
            if (objectLocation.Y > Location.Y)
                Location =
                    new Point(Location.X + (int)Math.Round(2 * Math.Cos(angle)),
                        Location.Y + (int)Math.Round(2 * Math.Sin(angle)));
            
            else
                Location =
                    new Point(Location.X + (int)Math.Round(2 * Math.Cos(angle)),
                        Location.Y - (int)Math.Round(2 * Math.Sin(angle)));
            Direction = Direcion.Right;

        }

        else
        {
            if (objectLocation.Y > Location.Y)
                Location =
                    new Point(Location.X - (int)Math.Round(2 * Math.Cos(angle)),
                        Location.Y + (int)Math.Round(2 * Math.Sin(angle)));
            
            else
                Location =
                    new Point(Location.X - (int)Math.Round(2 * Math.Cos(angle)),
                        Location.Y - (int)Math.Round(2 * Math.Sin(angle)));
            Direction = Direcion.Left;
        }
    }

    public void MoveByMouse(Point MousePoition)
    {
        Location = new Point(MousePoition.X - Size.Width / 2, MousePoition.Y - Size.Height / 2);
        IsCarried = true;
    }
    
    public void Update()
    {
        IsMove = Moves > 0;
        if (Moves > 0)
        {
            MoveToObject(positionAfterStep);
            Moves--;
        }
    }

    public void StartMoveToObject(Point objectLocation)
    {
        Moves = 40;
        positionAfterStep = objectLocation;
    }
}