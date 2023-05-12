﻿namespace MyGame.Domain;

public class Player
{
    public Player(Point location)
    {
        Location = location;
        HitBox = new PictureBox()
        {
            Size = new Size(50, 80), Location = location,
            SizeMode = PictureBoxSizeMode.CenterImage, BackColor = Color.Red
        };
        Controller = new PlayerController(this);
    }
    
    public enum Direcion
    {
        Right,
        Left
    }

    public Direcion direction = Direcion.Left;
    public Point Location;
    public Size PlayerSize = new (50, 80);
    public bool IsAlive = true;
    public PlayerController Controller { get; }
    public PictureBox HitBox { get; }
    
    public void MoveToMouse(Point MousePosition)
    {
        var newMousePos = new Point(MousePosition.X - 25, MousePosition.Y - 40);
        
        var angle = Math.Atan(Math.Abs(newMousePos.Y - Location.Y) /
                              (double)Math.Abs(newMousePos.X - Location.X));

        if (newMousePos.X > Location.X && newMousePos.Y > Location.Y)
        {
            Location =
                new Point(Location.X + (int)Math.Round(2 * Math.Cos(angle)),
                    Location.Y + (int)Math.Round(2 * Math.Sin(angle)));

        }

        else if (newMousePos.X < Location.X && newMousePos.Y > Location.Y)
        {
            Location =
                new Point(Location.X - (int)Math.Round(2 * Math.Cos(angle)),
                    Location.Y + (int)Math.Round(2 * Math.Sin(angle)));
        }

        else if (newMousePos.X < Location.X && newMousePos.Y < Location.Y)
        {
            Location =
                new Point(Location.X - (int)Math.Round(2 * Math.Cos(angle)),
                    Location.Y - (int)Math.Round(2 * Math.Sin(angle)));
        }

        else if (newMousePos.X > Location.X && newMousePos.Y < Location.Y)
        {
            Location =
                new Point(Location.X + (int)Math.Round(2 * Math.Cos(angle)),
                    Location.Y - (int)Math.Round(2 * Math.Sin(angle)));
        }

        HitBox.Location = Location;
    }
}