namespace MyGame.Domain;

public interface IEnemy : IGameObject
{
    public void MoveToPlayer(Point playerPosition);

    Enemy1Controller Controller { get; }

    Point Location { get; set; }
    
}