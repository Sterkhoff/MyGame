using MyGame.Domain;

namespace MyGame;

static class Program
{
    [STAThread]
    static void Main()
    {
        var game = new Game();
        game.StartGame();
    }
}