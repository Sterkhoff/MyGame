using MyGame.Domain;

namespace MyGame;

public partial class CurrentLevelForm : Form
{
    private List<Level> levels;
    private int currentLevelNumber;
    private int tickNumber;
    public CurrentLevelForm(List<Level> levels)
    {
        this.levels = levels;
        InitializeComponent();
    }

    public void CheckUpdates()
    {
        if (currentLevel != null)
        {
            currentLevel.CheckUpdates();
            if (currentLevel.IsFinished)
            {
                if (currentLevelNumber == 10)
                {
                    Controls.Remove(currentLevel);
                    currentLevel = null;
                    InitializeComponent();
                    return;
                }
                Controls.Remove(currentLevel);
                currentLevel = new CurrentLevel(levels[++currentLevelNumber-1], currentLevelNumber);
                Controls.Add(currentLevel);
            }

            if (currentLevel.IsClosed)
            {
                Controls.Remove(currentLevel);
                currentLevel = null;
                InitializeComponent();
                return;
            }

            if (currentLevel.Restarted)
            {
                Controls.Remove(currentLevel);
                currentLevel = new CurrentLevel(levels[currentLevelNumber - 1], currentLevelNumber);
                Controls.Add(currentLevel);
            }
        }
    }
    
    public void AddLevelsButtons()
    {
        var location = new Point(316, 400);
        Controls.Add(new Button()
        {
            Location = new Point(480, 300),
            Size = new Size(600, 40),
            BackColor = Color.Moccasin,
            Text = "Выберите уровень",
            Font = new Font("Comic sans MS", 22),
            Enabled = false
        });

        for (var i = 0; i < levels.Count; i++)
        {
            var button = new Button()
            {
                Size = new Size(60, 60),
                Location = location,
                Text = (i+1).ToString(),
                BackColor = Color.Moccasin,
                Font = new Font("Comic sans MS", 22),
                ForeColor = Color.Sienna
            };
            var levelNumber = i;
            button.Click += (sender, args) =>
            {
                BackgroundImage = null;
                Controls.Clear();
                currentLevelNumber = levelNumber + 1;
                currentLevel = new CurrentLevel(levels[levelNumber], currentLevelNumber);
                Controls.Add(currentLevel);
            };
            Controls.Add(button);
            location = new Point(location.X + 100, location.Y);
        }
    }
}