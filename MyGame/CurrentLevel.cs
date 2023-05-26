using System.Windows.Forms;
using MyGame.Domain;

namespace MyGame;

public partial class CurrentLevel : UserControl
{
    public bool IsClosed;
    private Level currentLevel;
    private int currentLevelNumber;
    private int tickNumber;
    public bool IsFinished;
    
    public CurrentLevel(Level level, int levelNumber)
    {
        currentLevel = level;
        currentLevelNumber = levelNumber;
        InitializeComponent();
    }
    
    public void CheckUpdates()
    {
        if (tickNumber > 500)
            tickNumber = 0;
        UpdateAnimationsNumbers();
        CheckCollides();
        player.Update();
        finish.Update();
        foreach (var enemy in enemies1)
        {
            enemy.Update();
            if (player.Moves == 39)
                enemy.StartMoveToObject(new Point(player.Location.X + player.Size.Width / 2, 
                        player.Location.Y + player.Size.Height / 2));
        }

        if (currentLevel.IsFinished)
        {
            IsFinished = true;
        }

        tickNumber++;
        Refresh();
    }

    private void UpdateAnimationsNumbers()
    {
        if (tickNumber % 10 == 0)
        {
            player.AnimationNumber++;
            foreach (var enemy in enemies1)
            {
                enemy.AnimationNumber++;
                if (enemy.AnimationNumber > 4 && enemy.IsAlive)
                {
                    enemy.IsAttack = false;
                    enemy.AnimationNumber = 1;
                }
            }
        }

        if (tickNumber % 5 == 0)
        {
            foreach (var trap in traps)
            {
                if (!trap.IsActive && trap.AnimationNumber < 4)
                    trap.AnimationNumber++;
            }
        }
        
        if (player.AnimationNumber > 4 && player.IsAlive)
            player.AnimationNumber = 1;
    }

    private void CheckCollides()
    {
        if (player.IsAlive && (player.Location.X + player.Size.Width / 2 < 250 || player.Location.X + player.Size.Width / 2 > 1270 
                                                            || player.Location.Y + player.Size.Height < 135 
                                                            || player.Location.Y + player.Size.Height > 725))
        {
            player.AnimationNumber = 1;
            player.IsAlive = false;
        }
        foreach (var enemy in enemies1)
        {
            if (Collide(player, enemy) && enemy.IsAlive && player.IsAlive)
            {
                player.AnimationNumber = 1;
                player.IsAlive = false;
                enemy.IsAttack = true;
                enemy.AnimationNumber = 1;
            }
            
            if (enemy.IsAlive && (enemy.Location.X + enemy.Size.Width / 2 < 250 || enemy.Location.X + enemy.Size.Width / 2 > 1270 
                    || enemy.Location.Y + enemy.Size.Height < 135 
                    || enemy.Location.Y + enemy.Size.Height > 725))
            {
                enemy.AnimationNumber = 1;
                enemy.IsAlive = false;
            }
        }

        if (Collide(player, finish) && player.IsAlive)
            currentLevel.FinishLevel();

        foreach (var trap in traps)
        {
            if (Collide(player, trap) && trap.IsActive)
            {
                trap.IsActive = false;
                player.AnimationNumber = 1;
                player.IsAlive = false;
            }

            foreach (var enemy in enemies1)
            {
                if (trap.IsActive && enemy.IsAlive && Collide(enemy, trap))
                {
                    enemy.AnimationNumber = 1;
                    enemy.IsAlive = false;
                    trap.IsActive = false;
                }
            }
        }
    }
    private bool Collide(IGameObject firstObject, IGameObject secondObject)
    {
        PointF delta = new PointF();
        if (secondObject.GetType() == typeof(Trap))
        {
            delta.X = (firstObject.Location.X + firstObject.Size.Width / 2) - (secondObject.Location.X + secondObject.Size.Width / 2);
            delta.Y = (firstObject.Location.Y + firstObject.Size.Height) - (secondObject.Location.Y + secondObject.Size.Height / 2);
            if (Math.Abs(delta.X) <= firstObject.Size.Width / 2 + secondObject.Size.Width / 2)
            {
                if (Math.Abs(delta.Y) <= secondObject.Size.Height / 2)
                {
                    return true;
                }
            }
            return false;
        }
        else
        {
            delta.X = (firstObject.Location.X + firstObject.Size.Width / 2) -
                      (secondObject.Location.X + secondObject.Size.Width / 2);
            delta.Y = (firstObject.Location.Y + firstObject.Size.Height / 2) -
                      (secondObject.Location.Y + secondObject.Size.Height / 2);
            if (Math.Abs(delta.X) <= firstObject.Size.Width / 2 + secondObject.Size.Width / 2)
            {
                if (Math.Abs(delta.Y) <= firstObject.Size.Height / 2 + secondObject.Size.Height / 2)
                {
                    return true;
                }
            }

            return false;
        }
    }
}