
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
                StartPoint = new(450, 400),
                TrapsLocations = new() { new Point(700, 440) },
                FinishLocation = new(1050, 400),
                DescriptionText = "Не наступайте на капканы!"
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
                StartPoint = new(450, 400),
                FinishLocation = new(1400, 200),
                BellLocation = new(1050, 400),
                DescriptionText = "???"
            },

            new Level
            {
                StartPoint = new(450, 400),
                FinishLocation = new(1050, 400),
                TrapsLocations = new List<Point>
                {
                    new(700, 440), new(700, 510),
                    new(700, 580), new(700, 650),
                    new(700, 170), new(700, 310),
                    new(700, 370), new(700, 240)
                },
                Enemies1Locations = new List<Point> { new(1000, 210), new(900, 550) },
                DescriptionText = "Теперь их двое..."
            },

            new Level
            {
                StartPoint = new(380, 240),
                FinishLocation = new(1050, 400),
                TrapsLocations = new List<Point>
                {
                    new(640, 440), new(640, 510),
                    new(640, 580), new(640, 650), 
                    new(640, 310), new(640, 370), 
                    new(700, 440), new(700, 510),
                    new(700, 580), new(700, 650),
                    new(700, 170), new(700, 310),
                    new(700, 370), new(700, 240),
                    new(900, 440), new(900, 510),
                    new(900, 240), new(900, 170), 
                    new(900, 310), new(900, 370),
                },
                Enemies1Locations = new List<Point> { new(1015, 600) },
                BellLocation = new(780, 220),
                DescriptionText = "Лабиринтик для орка"
            },
            
            new Level
            {
                StartPoint = new(300, 180),
                Enemies1Locations = new List<Point> { new(368, 336), new(500, 280), new (530, 203) },
                FinishLocation = new(1050, 400),
                DescriptionText = "Западня, раскидать бы их..."
            },
            
            new Level
            {
                StartPoint = new(450, 400),
                FinishLocation = new(1050, 400),
                TrapsLocations = new List<Point>
                {
                    new(700, 440), new(700, 510),
                    new(700, 580), new(700, 650),
                    new(700, 170), new(700, 310),
                    new(700, 370), new(700, 240)
                },
                Enemies1Locations = new List<Point> { new(630, 210), new(630, 600) },
                BellLocation = new(450,300),
                DescriptionText = "Опять что-то передвигать???"
            },
            
            new Level
            {
                StartPoint = new(450, 400),
                TrapsLocations = new List<Point>
                {
                    new(700, 440), new(700, 510),
                    new(700, 580), new(700, 650),
                    new(700, 170), new(700, 310),
                    new(700, 370), new(700, 240)
                },
                FinishLocation = new(1050, 400),
                DescriptionText = "Хорошо, что финишь не умирает..."
            },
            
            new Level
            {
                StartPoint = new(525, 555),
                TrapsLocations = new List<Point>
                {
                    new(700, 440), new(700, 510),
                    new(700, 580), new(700, 650),
                    new(420, 440), new(420, 510),
                    new(420, 580), new(420, 650),
                    new(630, 440), new(560, 440),
                    new(490, 440), new(420, 440),
                },
                FinishLocation = new(1050, 400),
                DescriptionText = "Это последний уровень, думай сам, игра и так легкая!!"
            }
        };
    }
}