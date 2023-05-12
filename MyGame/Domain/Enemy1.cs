namespace MyGame.Domain;

public class Enemy1 : Enemy
{
    public Enemy1(Point location)
    {
        Location = location;
        HitBox = new PictureBox()
        {
            Size = new Size(50, 80), Location = location,
            SizeMode = PictureBoxSizeMode.CenterImage, BackColor = Color.Black
        };
        Controller = new Enemy1Controller(this);
    }
    
    public enum Direcion
    {
        Right,
        Left
    }

    public Direcion direction = Direcion.Left;
    public Point Location;
    public Size Size = new (50, 80);
    public bool IsAlive = true;
    public PictureBox HitBox {get;}
    public Enemy1Controller Controller { get; }

    public void MoveToPlayer(Point playerPosition)
    {
        var angle = Math.Atan(Math.Abs(playerPosition.Y - Location.Y) /
                              (double)Math.Abs(playerPosition.X - Location.X));

        if (playerPosition.X > Location.X && playerPosition.Y > Location.Y)
        {
            Location =
                new Point(Location.X + (int)Math.Round(2 * Math.Cos(angle)),
                    Location.Y + (int)Math.Round(2 * Math.Sin(angle)));

        }

        else if (playerPosition.X < Location.X && playerPosition.Y > Location.Y)
        {
            Location =
                new Point(Location.X - (int)Math.Round(2 * Math.Cos(angle)),
                    Location.Y + (int)Math.Round(2 * Math.Sin(angle)));
        }

        else if (playerPosition.X < Location.X && playerPosition.Y < Location.Y)
        {
            Location =
                new Point(Location.X - (int)Math.Round(2 * Math.Cos(angle)),
                    Location.Y - (int)Math.Round(2 * Math.Sin(angle)));
        }

        else if (playerPosition.X > Location.X && playerPosition.Y < Location.Y)
        {
            Location =
                new Point(Location.X + (int)Math.Round(2 * Math.Cos(angle)),
                    Location.Y - (int)Math.Round(2 * Math.Sin(angle)));
        }

        HitBox.Location = Location;
    }
}