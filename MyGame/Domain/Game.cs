
namespace MyGame.Domain;

public class Game
{
    public Level[] Levels;

    public void StartGame()
    {
        MakeLevels();
        var m = new CurrentLevelForm(Levels);
        var timer = new System.Windows.Forms.Timer();
        timer.Interval = 5;
        timer.Tick += (sender, args) =>
        {
            m.CheckUpdates();
        };
        timer.Start();
        Application.Run(m);
    }
    
    public void MakeLevels()
    {
        Levels = new[]
        {
            // new Level
            // {
            //     StartPoint = new (450, 400),
            //     TrapsLocations = new (){new Point(700, 440)},
            //     FinishLocation = new (1050, 400),
            //     DescriptionText = "Не наступайте в капканы!"
            // },
            //
            // new Level
            // {
            //     StartPoint = new(450, 200),
            //     Enemies1Locations = new List<Point> { new(450, 450) },
            //     FinishLocation = new(1050, 400),
            //     DescriptionText = "Враги вас не видят, но слышат когда выходите!"
            // },
            
            // new Level
            // {
            //     StartPoint = new(450, 400),
            //     Enemies1Locations = new List<Point> { new(700, 400) },
            //     FinishLocation = new(1050, 400),
            //     BellLocation = new(700, 250),
            //     DescriptionText = "Колокольчик может отвлечь врага"
            // }
            
            new Level
            {
                StartPoint = new (450, 400),
                FinishLocation = new (1400, 200),
                BellLocation = new (1050, 400)
            }
        };
    }
}