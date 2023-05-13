using MyGame.Domain;

namespace MyGame;

public partial class MainForm : Form
{
    private Level[] levels;
    private Level currentLevel;
    private int currentLevelNumber;
    public MainForm(Level[] levels)
    {
        currentLevel = levels[0];
        this.levels = levels;
        InitializeComponent();
    }

    public void CheckUpdates()
    {
        player.Controller.Update();
        foreach (var enemy in enemies)
        {
            if (enemy.IsAlive)
                enemy.Controller.Update();
        }

        if (Collide(finish, player))
            currentLevel.Finished = true;

        foreach (var enemy in enemies)
        {
            if (Collide(enemy, player) && enemy.IsAlive)
                player.IsAlive = false;
        }

        foreach (var trap in traps)
        {
            if (Collide(trap, player))
                player.IsAlive = false;
            
            foreach (var enemy in enemies)
            {
                if (Collide(enemy, trap))
                    enemy.IsAlive = false;
            }
        }

        if (currentLevel.Finished)
        {
            currentLevel = levels[++currentLevelNumber];
            InitializeComponent();
        }

        if (!player.IsAlive)
        {
            Controls.Add(restartMenu);
            InitializeComponent();
        }

        Invalidate();
    }

    public bool Collide(IGameObject firstObject, IGameObject secondObject)
    {
        return Math.Abs(firstObject.Location.X + firstObject.Size.Width / 2
                        - secondObject.Location.X - secondObject.Size.Width / 2) < secondObject.Size.Width / 2
               && Math.Abs(firstObject.Location.Y + firstObject.Size.Height / 2
                           - secondObject.Location.Y - secondObject.Size.Height / 2) < secondObject.Size.Height / 2;
    }
}