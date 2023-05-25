using MyGame.Domain;

namespace MyGame;

public class Enemy2Controller
{
    public Enemy2Controller(Enemy2 enemy)
    {
        this.enemy = enemy;
    }
    private Enemy2 enemy; 

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
        moves = 70;
        positionAfterStep = mousePosition;
    }
}