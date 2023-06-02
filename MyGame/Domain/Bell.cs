namespace MyGame.Domain;

public class Bell : SimplyMoveableObject
{
    public Bell(Point location) : base(location, new Size(40, 40))
    {
    }
}