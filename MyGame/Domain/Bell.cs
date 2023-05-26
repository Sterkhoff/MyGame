namespace MyGame.Domain;

public class Bell : SimplyMoveableObject
{
    public Bell(Point location)
    {
        Location = location;
        Size = new Size(40, 40);
    }
}