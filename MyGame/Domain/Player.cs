﻿namespace MyGame.Domain;

public class Player : SimplyMoveableObject
{
    public int AnimationNumber = 1;
    public bool IsAlive = true;

    public override void Update(int tickNumber)
    {
        IsMove = Moves > 0;
        if (Moves > 0)
        {
            MoveToObject(positionAfterStep);
            Moves--;
        }
        
        if (tickNumber % 10 == 0)
        {
            AnimationNumber++;
        }
        
        if (AnimationNumber > 4 && IsAlive)
            AnimationNumber = 1;
    }

    public Player(Point location) : base(location, new Size(50, 80))
    {
    }
}