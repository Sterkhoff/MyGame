namespace MyGame.Domain;

public class Level
{
    public Level(Player player, Finish finish, params Enemy[] enemies)
    {
        Player = player;
        Enemies = enemies;
        Finish = finish;
    }

    public Finish Finish;
    public Player Player;
    public Enemy[] Enemies;
    public bool Finished = false;
}