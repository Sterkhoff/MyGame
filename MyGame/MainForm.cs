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
                Controls.Remove(currentLevel);
                currentLevel = new CurrentLevel(levels[++currentLevelNumber], currentLevelNumber);
                Controls.Add(currentLevel);
            }

            if (currentLevel.IsClosed)
            {
                Controls.Remove(currentLevel);
                currentLevel = null;
                InitializeComponent();
            }
        }
    }
    
    public void AddLevelsButtons()
    {
        var location = new Point(316, 212);
        Controls.Add(new Button()
        {
            Location = new Point(480, 150),
            Size = new Size(600, 40),
            BackColor = Color.Goldenrod,
            Text = "Выбере уровень",
            Font = new Font("Times New Roman", 30)
        });
        
        for (var i = 0; i < levels.Count; i++)
        {
            var button = new Button();
            var levelNumber = i;
            button.Click += (sender, args) =>
            {
                Controls.Clear();
                currentLevelNumber = levelNumber + 1;
                currentLevel = new CurrentLevel(levels[levelNumber], currentLevelNumber);
                Controls.Add(currentLevel);
            };
            
            button.Size = new Size(40, 40);
            button.Location = location;
            button.Text = (i+1).ToString();
            button.Name = "LevelNumbers";
            button.BackColor = Color.Goldenrod;
            Controls.Add(button);
            location = new Point(location.X + 100, location.Y);
        }
    }
}