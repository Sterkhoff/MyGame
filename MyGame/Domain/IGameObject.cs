namespace MyGame.Domain;

public interface IGameObject
{
    Size Size
    {
        get;
    }

    Point Location
    {
        get;
    }
}