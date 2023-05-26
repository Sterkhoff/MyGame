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
        
        MouseDown += (sender, args) =>
        {
            var flag = false;
            if (currentLevelNumber == 7)
                foreach (var enemy in enemies1)
                {
                    if (MouseOnObject(enemy))
                    {
                        flag = true;
                        enemy.MoveByMouse(MousePosition);
                        MouseMove += (o, eventArgs) =>
                        {
                            if (enemy.IsCarried)
                                enemy.MoveByMouse(MousePosition);
                        };
                        MouseUp += (o, eventArgs) => enemy.IsCarried = false;
                    }
                }
            
            if (currentLevelNumber == 8) 
                if (MouseOnObject(bell))
                {
                    flag = true;
                    bell.MoveByMouse(MousePosition);
                    MouseMove += (o, eventArgs) =>
                    {
                        if (bell.IsCarried)
                            bell.MoveByMouse(MousePosition);
                    };
                    MouseUp += (o, eventArgs) => bell.IsCarried = false;
                }

            if (currentLevelNumber == 9)
            {
                this.finish.StartMoveToObject(new Point(MousePosition.X - 50, MousePosition.Y - 90));
                foreach (var enemy in enemies1)
                {
                    enemy.StartMoveToObject(player.Location);
                }
                return;
            }

            if (currentLevelNumber == 10)
            {
                foreach (var trap in traps)
                {
                    if (MouseOnObject(trap))
                    {
                        trap.IsActive = false;
                        flag = true;
                    }
                }
            }

            if (MouseOnObject(bell))
            {
                if (currentLevelNumber == 4)
                    finish.StartMoveToObject(bell.Location);
                foreach (var enemy in enemies1)
                {
                    enemy.StartMoveToObject(bell.Location);
                }
                return;
            }
            if (!flag)
                if (player.IsAlive)
                    this.player.StartMoveToObject(new(MousePosition.X - 25, MousePosition.Y - 80));
        };

        KeyDown += (sender, args) =>
        {
            if (args.KeyCode == Keys.Escape)
                IsClosed = true;
            if (args.KeyCode == Keys.R)
                Restarted = true;
        };


        MouseDoubleClick += (sender, args) =>
        {
            if (!player.IsAlive)
                Restarted = true;
        };
        
        Paint += (sender, args) =>
        {
            PaintAmbientAndGUI(args);
            PaintTraps(args);
            PaintPlayer(args);
            PaintEnemies(args);
            args.Graphics.DrawString(currentLevel.DescriptionText, 
                new Font("Times New Roman", 30, FontStyle.Bold), new SolidBrush(Color.Black), 
                690 - currentLevel.DescriptionText.Length * 8, 80);
            
            if (!player.IsAlive)
                args.Graphics.DrawImage(Resources.Restart, 
                    525, 400, 500, 400);
            if (currentLevelNumber == 1)
                args.Graphics.DrawString("Нажмите ЛКМ чтобы двигаться\nНажмите R для рестарта\nНажмите ESC для выхода", 
                    new Font("Times New Roman", 20, FontStyle.Bold), new SolidBrush(Color.Black), 
                    284, 179);
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
            return;
        
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
                continue;
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
        args.Graphics.DrawString($"{MousePosition.X} {MousePosition.Y}", 
            new Font("Times New Roman", 30), new SolidBrush(Color.Black), 
            0, 0);
        
        if (bell.Location.X != 0)
            args.Graphics.DrawImage(Resources.Bell, 
                bell.Location.X, bell.Location.Y, 50, 50);
        
        args.Graphics.DrawImage(Resources.finish, this.finish.Location.X, this.finish.Location.Y, 50, 90);
        
        args.Graphics.DrawImage(Resources.DangerIcon, 90, 400, 80, 80);
    }
    private Trap[] traps;
    private Finish finish;
    private Enemy1[] enemies1;
    private Player player;
    private Bell bell;

    #endregion
}