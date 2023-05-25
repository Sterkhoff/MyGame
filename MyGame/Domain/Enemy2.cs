namespace MyGame.Domain;

public class Enemy2 : IGameObject
{
    public Enemy2(Point location)
    {
        Location = location;
        Size = new Size(50, 80);
        Controller = new Enemy2Controller(this);
    }
    
    public enum Direcion
    {
        Right,
        Left
    }

    public Direcion direction = Direcion.Left;
    public Point Location { get; set; }
    public Size Size { get; }
    public bool IsAlive = true;
    public Enemy2Controller Controller { get; }

    public void MoveToPlayer(Point playerPosition)
    {
        var angle = Math.Atan(Math.Abs(playerPosition.Y - Location.Y) /
                              (double)Math.Abs(playerPosition.X - Location.X));

        if (playerPosition.X > Location.X && playerPosition.Y > Location.Y)
        {
            Location =
                new Point(Location.X + 2 * (int)Math.Round(2 * Math.Cos(angle)),
                    Location.Y + 2 * (int)Math.Round(2 * Math.Sin(angle)));

        }

        else if (playerPosition.X < Location.X && playerPosition.Y > Location.Y)
        {
            Location =
                new Point(Location.X - 2 * (int)Math.Round(2 * Math.Cos(angle)),
                    Location.Y + 2 * (int)Math.Round(2 * Math.Sin(angle)));
        }

        else if (playerPosition.X < Location.X && playerPosition.Y < Location.Y)
        {
            Location =
                new Point(Location.X - 2 * (int)Math.Round(2 * Math.Cos(angle)),
                    Location.Y - 2 * (int)Math.Round(2 * Math.Sin(angle)));
        }

        else if (playerPosition.X > Location.X && playerPosition.Y < Location.Y)
        {
            Location =
                new Point(Location.X + 2 * (int)Math.Round(2 * Math.Cos(angle)),
                    Location.Y - 2 * (int)Math.Round(2 * Math.Sin(angle)));
        }
    }
}