namespace MyGame.Domain;

public class Bell : IGameObject
{
    public Bell(Point location)
    {
        Location = location;
    }
    public Size Size => new (40, 40);
    public Point Location { get; }
}