using MyGame.Domain;

namespace MyGame;

public partial class MainForm : Form
{
    private Game game;
    public MainForm(Game game)
    {
        InitializeComponent();
        this.game = game;
        ShowGame();
    }

    public void ShowGame()
    {
        playerControl.Configure(game);
        playerControl.Show();
    }

    public void CheckUpdates()
    {
        playerControl.CheckUpdates();
    }
}