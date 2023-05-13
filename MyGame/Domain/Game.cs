
namespace MyGame.Domain;

public class Game
{
    public Level[] Levels =
    {
        new (new(100, 100), 
            new (500, 500), 
            new []{ new Point(800, 800)}, 
            new [] {new Point(300, 300) })
    };
    
    public void StartGame()
    {
        var m = new MainForm(Levels);
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