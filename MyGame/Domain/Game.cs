
namespace MyGame.Domain;

public class Game
{
    public Player player = new ();
    

    public void StartGame()
    {
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