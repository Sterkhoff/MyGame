namespace MyGame.Domain;

public class Player : SimplyMoveableObject
{
    public Player(Point location)
    {
        Location = location;
        Size = new Size(50, 80);
    }
    
    public int AnimationNumber = 1;
    public bool IsAlive = true;
}