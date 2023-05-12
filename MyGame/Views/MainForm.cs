using MyGame.Domain;

namespace MyGame;

public partial class MainForm : Form
{
    private Game game;
    public MainForm(Game game)
    {
        this.game = game;
        InitializeComponent();
    }

    public void CheckUpdates()
    {
        game.CurrentLevel.Player.Controller.Update();
        foreach (var enemy in game.CurrentLevel.Enemies)
        {
            enemy.Controller.Update();
        }
    }
}