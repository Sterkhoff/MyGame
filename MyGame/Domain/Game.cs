
namespace MyGame.Domain;

public class Game
{
    public List<Level> Levels;

    public void StartGame()
    {
        MakeLevels();
        var gameForm = new CurrentLevelForm(Levels);
        var timer = new System.Windows.Forms.Timer();
        timer.Interval = 5;
        timer.Tick += (sender, args) =>
        {
            gameForm.CheckUpdates();
        };
        timer.Start();
        Application.Run(gameForm);
    }
    
    public void MakeLevels()
    {
        Levels = new()
        {
            new Level
            {
                StartPoint = new (450, 400),
                TrapsLocations = new (){new Point(700, 440)},
                FinishLocation = new (1050, 400),
                DescriptionText = "Не наступайте в капканы!"
            },
            
            new Level
            {
                StartPoint = new(450, 200),
                Enemies1Locations = new List<Point> { new(450, 450) },
                FinishLocation = new(1050, 400),
                DescriptionText = "Враги вас не видят, но слышат когда выходите!"
            },
            
            new Level
            {
                StartPoint = new(450, 400),
                Enemies1Locations = new List<Point> { new(700, 400) },
                FinishLocation = new(1050, 400),
                BellLocation = new(700, 250),
                DescriptionText = "Колокольчик может отвлечь врага"
            },
            
            new Level
            {
                StartPoint = new (450, 400),
                FinishLocation = new (1400, 200),
                BellLocation = new (1050, 400),
                DescriptionText = "???"
            },
            
            new Level
            {
                StartPoint = new (450, 400),
                FinishLocation = new (1050, 400),
                TrapsLocations = new List<Point>
                {
                    new (700, 440), new (700, 510),
                    new (700, 580), new (700, 650),
                    new (700, 170), new (700, 310),
                    new (700, 370), new (700, 240)
                },
                Enemies1Locations = new List<Point>{new (900, 210), new (900, 550)}
            }
        };
    }
}