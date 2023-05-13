namespace MyGame.Domain;

public class Trap : IGameObject
{
    public Trap(Point location)
    {
        Location = location;
        Size = new Size(50, 50);
    }
    public Size Size { get; }
    public Point Location { get; }
}