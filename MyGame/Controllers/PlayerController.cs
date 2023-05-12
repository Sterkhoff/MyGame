using MyGame.Domain;

namespace MyGame;

public class PlayerController
{
    public PlayerController(Player player)
    {
        this.player = player;
    }
    private Player player; 

    public Point positionAfterStep;

    public int moves;

    public void Update()
    {
        if (moves > 0)
        {
            player.MoveToMouse(positionAfterStep);
            moves--;
        }
    }

    public void StartMovePlayerToMouse(Point mousePosition)
    {
        moves = 40;
        positionAfterStep = mousePosition;
    }
}