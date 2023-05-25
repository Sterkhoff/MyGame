namespace MyGame.Domain;

public class Enemy1 : SimplyMoveableObject
{
    public Enemy1(Point location)
    {
        Location = location;
        Size = new Size(50, 80);
    }

    public bool IsAttack = false;
    public bool IsAlive = true;
    public int AnimationNumber = 1;
}