using System.ComponentModel;
using MyGame.Domain;

namespace MyGame;

partial class CurrentLevel
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.DoubleBuffered = true;
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1920, 1080);
        this.player = new Player(currentLevel.StartPoint);
        this.bell = new Bell(currentLevel.BellLocation);
        this.finish = new Finish(currentLevel.FinishLocation);
        this.enemies1 = new Enemy1[currentLevel.Enemies1Locations.Count];
        this.traps = new Trap[currentLevel.TrapsLocations.Count];
        this.BackgroundImage = (Bitmap)Resources.ResourceManager.GetObject("fon");

        for (int i = 0; i < enemies1.Length; i++)
        {
            enemies1[i] = new Enemy1(currentLevel.Enemies1Locations[i]);
        }
        
        for (int i = 0; i < traps.Length; i++)
        {
            traps[i] = new Trap(currentLevel.TrapsLocations[i]);
        }
        
        MouseClick += (sender, args) => 
        {
            if (MouseOnObject(bell))
            {
                if (currentLevelNumber == 4)
                    finish.StartMoveToObject(currentLevel.BellLocation);
                foreach (var enemy in enemies1)
                {
                    enemy.StartMoveToObject(currentLevel.BellLocation);
                }
                return;
            }
            if (player.IsAlive)
                this.player.StartMoveToObject(new(MousePosition.X - 25, MousePosition.Y - 40));
        };

        if (currentLevelNumber == 6)
        {
            MouseDown += (sender, args) =>
            {
                foreach (var enemy in enemies1)
                {
                    if (MouseOnObject(enemy))
                    {
                        enemy.MoveByMouse(MousePosition);
                        MouseMove += (o, eventArgs) =>
                        {
                            if (enemy.IsCarried)
                                enemy.MoveByMouse(MousePosition);
                        };
                        MouseUp += (o, eventArgs) => enemy.IsCarried = false;
                    }
                }
            };
        }

        KeyDown += (sender, args) =>
        {
            if (args.KeyCode == Keys.Escape)
                IsClosed = true;
        };


        MouseDoubleClick += (sender, args) =>
        {
            if (!player.IsAlive)
                InitializeComponent();
        };
        
        Paint += (sender, args) =>
        {
            PaintAmbientAndGUI(args);
            PaintTraps(args);
            PaintPlayer(args);
            PaintEnemies(args);
        };
    }

    private bool MouseOnObject(IGameObject gameObject) =>
        MousePosition.X > gameObject.Location.X
        && MousePosition.Y > gameObject.Location.Y
        && MousePosition.X < gameObject.Location.X + gameObject.Size.Width
        && MousePosition.Y < gameObject.Location.Y + gameObject.Size.Height;

        private void PaintPlayer(PaintEventArgs args)
    {
        if (!player.IsAlive && player.AnimationNumber >= 4)
            args.Graphics.DrawImage(Resources.PlayerDead4, 
                this.player.Location.X, this.player.Location.Y, this.player.Size.Width, this.player.Size.Height);
        
        else if (!player.IsAlive)
            args.Graphics.DrawImage((Bitmap)Resources.ResourceManager.GetObject($"PlayerDead{player.AnimationNumber}"), 
                this.player.Location.X, this.player.Location.Y, this.player.Size.Width, this.player.Size.Height);

        else if (!player.IsMove)
            args.Graphics.DrawImage((Bitmap)Resources.ResourceManager.GetObject($"PlayerIdle{player.AnimationNumber}"), 
                this.player.Location.X, this.player.Location.Y, this.player.Size.Width, this.player.Size.Height);
        
        else if (player.Direction == Direcion.Right) 
            args.Graphics.DrawImage((Bitmap)Resources.ResourceManager.GetObject($"PlayerWalk{player.AnimationNumber}"), 
                this.player.Location.X, this.player.Location.Y, this.player.Size.Width, this.player.Size.Height);

        else
        {
            var currentPlayerSprite = (Bitmap)Resources.ResourceManager.GetObject($"PlayerWalk{player.AnimationNumber}");

            currentPlayerSprite.RotateFlip(RotateFlipType.RotateNoneFlipX);
            
            args.Graphics.DrawImage(currentPlayerSprite, 
                this.player.Location.X, this.player.Location.Y, this.player.Size.Width, this.player.Size.Height);
        }
    }

    private void PaintEnemies(PaintEventArgs args)
    {
        foreach (var enemy in this.enemies1)
        {
            if (!enemy.IsAlive && enemy.AnimationNumber > 4)
                return;
            else if (!enemy.IsAlive && enemy.AnimationNumber < 5)
            {
                args.Graphics.DrawImage(
                    (Bitmap)Resources.ResourceManager.GetObject($"Enemy1Dead{enemy.AnimationNumber}"),
                    enemy.Location.X, enemy.Location.Y, enemy.Size.Width, enemy.Size.Height);
            }
            else if (enemy.IsAttack)
            {
                if (enemy.Direction == Direcion.Left)
                {
                    var currentEnemySprite =
                        (Bitmap)Resources.ResourceManager.GetObject($"Enemy1Attack{enemy.AnimationNumber}");

                    currentEnemySprite.RotateFlip(RotateFlipType.RotateNoneFlipX);

                    args.Graphics.DrawImage(currentEnemySprite,
                        enemy.Location.X, enemy.Location.Y, 90, 80);
                }
                else
                    args.Graphics.DrawImage(
                        (Bitmap)Resources.ResourceManager.GetObject($"Enemy1Attack{enemy.AnimationNumber}"),
                        enemy.Location.X, enemy.Location.Y, 90, 80);
            }
            else if (!enemy.IsMove)
                args.Graphics.DrawImage(
                    (Bitmap)Resources.ResourceManager.GetObject($"Enemy1Idle{enemy.AnimationNumber}"),
                    enemy.Location.X, enemy.Location.Y, enemy.Size.Width, enemy.Size.Height);

            else if (enemy.Direction == Direcion.Right)
                args.Graphics.DrawImage(
                    (Bitmap)Resources.ResourceManager.GetObject($"Enemy1Run{enemy.AnimationNumber}"),
                    enemy.Location.X, enemy.Location.Y, enemy.Size.Width, enemy.Size.Height);
            else
            {
                var currentEnemySprite =
                    (Bitmap)Resources.ResourceManager.GetObject($"Enemy1Run{enemy.AnimationNumber}");

                currentEnemySprite.RotateFlip(RotateFlipType.RotateNoneFlipX);

                args.Graphics.DrawImage(currentEnemySprite, enemy.Location.X, enemy.Location.Y, enemy.Size.Width,
                    enemy.Size.Height);
            }
        }
    }

    private void PaintTraps(PaintEventArgs args)
    {
        
        foreach (var trap in this.traps)
        {
            if (trap.IsActive)
                args.Graphics.DrawImage(Resources.Trap1, trap.Location.X, trap.Location.Y,
                    trap.Size.Width, trap.Size.Height);
            else
            {
                args.Graphics.DrawImage((Bitmap)Resources.ResourceManager.GetObject($"Trap{trap.AnimationNumber}"),
                    trap.Location.X, trap.Location.Y,
                    trap.Size.Width, trap.Size.Height);
            }
        }
    }

    private void PaintAmbientAndGUI(PaintEventArgs args)
    {
        if (!player.IsAlive)
            args.Graphics.DrawImage(Resources.Restart, 
                525, 400, 500, 400);
        
        args.Graphics.DrawString(currentLevel.DescriptionText, 
            new Font("Times New Roman", 30), new SolidBrush(Color.Tomato), 
            740 - currentLevel.DescriptionText.Length * 8, 300);
        
        args.Graphics.DrawString($"{MousePosition.X} {MousePosition.Y}", 
            new Font("Times New Roman", 30), new SolidBrush(Color.Black), 
            0, 0);
        
        if (currentLevel.BellLocation.X != 0)
            args.Graphics.DrawImage(Resources.Bell, 
                currentLevel.BellLocation.X, currentLevel.BellLocation.Y, 50, 50);
        
        args.Graphics.DrawImage(Resources.finish, this.finish.Location.X, this.finish.Location.Y, 50, 90);
        
        args.Graphics.DrawImage(Resources.DangerIcon, 
            125, 400, 60, 60);
    }
    private Trap[] traps;
    private Finish finish;
    private Enemy1[] enemies1;
    private Player player;
    private Bell bell;

    #endregion
}