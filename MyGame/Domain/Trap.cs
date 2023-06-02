namespace MyGame.Domain;

public class Trap : SimplyMoveableObject
{
    public override void Update(int tickNumber)
    {
        if (tickNumber % 5 == 0 && !IsActive && AnimationNumber < 4)
            AnimationNumber++;
    }

    public int AnimationNumber = 1;
    
    public bool IsActive = true;

    public Trap(Point location) : base(location, new Size(50, 50))
    {
    }
}