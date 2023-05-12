using MyGame.Domain;

namespace MyGame;

public class Enemy1Controller
{
    public Enemy1Controller(Enemy1 enemy)
    {
        this.enemy = enemy;
    }
    private Enemy1 enemy; 

    public Point positionAfterStep;

    public int moves;

    public void Update()
    {
        if (moves > 0)
        {
            enemy.MoveToPlayer(positionAfterStep);
            moves--;
        }
    }

    public void StartMoveEnemyToPlayer(Point mousePosition)
    {
        moves = 40;
        positionAfterStep = mousePosition;
    }
}