namespace MyGame.Domain;

public class SimplyMoveableObject : IGameObject
{
    public SimplyMoveableObject(Point location, Size size)
    {
        Location = location;
        Size = size;
    }
    public Size Size { get; }
    public bool IsCarried;
    internal Point positionAfterStep;
    public bool IsMove;
    public int Moves { get; internal set; }
    public Directions Directions { get; private set; }
    public Point Location { get; private set; }
    
    internal void MoveToObject(Point objectLocation)
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
            Directions = Directions.Right;

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
            Directions = Directions.Left;
        }
    }

    public void MoveByMouse(Point MousePoition)
    {
        Location = new Point(MousePoition.X - Size.Width / 2, MousePoition.Y - Size.Height / 2);
        IsCarried = true;
    }
    
    public virtual void Update(int tickNumber)
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