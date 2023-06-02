namespace MyGame.Domain;

public class Enemy : SimplyMoveableObject
{
    public bool IsAttack = false;
    public bool IsAlive = true;
    public int AnimationNumber = 1;
    
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
            if (AnimationNumber > 4 && IsAlive)
            {
                IsAttack = false;
                AnimationNumber = 1;
            }
        }
    }


    public Enemy(Point location) : base(location, new Size(50, 80))
    {
    }
}