namespace MyGame.Domain;

public class Game
{
    public LevelInfo[] Levels;

    public void StartGame()
    {
        Levels = LevelCreator.MakeLevels();
        var gameForm = new MainForm(Levels);
        var timer = new System.Windows.Forms.Timer();
        timer.Interval = 5;
        timer.Tick += (sender, args) =>
        {
            gameForm.CheckUpdates();
        };
        timer.Start();
        Application.Run(gameForm);
    }
}