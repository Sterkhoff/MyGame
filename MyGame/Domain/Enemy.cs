namespace MyGame.Domain;

public interface Enemy
{
    public void MoveToPlayer(Point playerPosition);

    PictureBox HitBox
    {
        get;
    }

    Enemy1Controller Controller
    {
        get;
    }
}