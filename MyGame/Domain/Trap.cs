namespace MyGame.Domain;

public class Trap : IGameObject
{
    public Trap(Point location)
    {
        Location = location;
        Size = new Size(50, 50);
    }

    public int AnimationNumber = 1;
    public Size Size { get; }
    public Point Location { get; }
    public bool IsActive = true;
}