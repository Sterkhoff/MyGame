﻿namespace MyGame.Domain;

public class Finish : IGameObject
{
    public Finish(Point location)
    {
        Location = location;
        Size = new Size(50, 50);
    }

    public Point Location { get; }
    public Size Size { get; }
}