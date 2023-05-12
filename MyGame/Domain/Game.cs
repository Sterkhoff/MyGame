
namespace MyGame.Domain;

public class Game
{
    public List<Level> Levels = new () {
        new Level(new Player(new (100, 100)), 
            new Finish(new (800, 800)), 
            new Enemy1(new (500, 500)))};

    public Level CurrentLevel;
    public void StartGame()
    {
        CurrentLevel = Levels[0];
        var m = new MainForm(this);
        var timer = new System.Windows.Forms.Timer();
        timer.Interval = 10;
        timer.Tick += (sender, args) =>
        {
            m.CheckUpdates();
        };
        timer.Start();
        Application.Run(m);
    }
}