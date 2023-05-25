namespace MyGame.Domain;

public class Finish : SimplyMoveableObject
{
    public Finish(Point location)
    {
        Location = location;
        Size = new Size(50, 90);
    }
}