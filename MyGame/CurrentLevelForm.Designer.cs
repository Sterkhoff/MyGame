using MyGame.Domain;

namespace MyGame;

partial class CurrentLevelForm
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
        this.WindowState = FormWindowState.Maximized;
        this.FormBorderStyle = FormBorderStyle.None;
        this.Text = "Game";
        this.player = new Player(currentLevel.StartPoint);
        this.finish = new Finish(currentLevel.FinishLocation);
        this.enemies1 = new Enemy1[currentLevel.Enemies1Locations.Count];
        this.enemies2 = new Enemy2[currentLevel.Enemies2Locations.Count];
        this.traps = new Trap[currentLevel.TrapsLocations.Count];
        if (currentLevel.BellLocation.X != 0)
        {
            this.bellButton = new PictureBox();
            bellButton.Location = currentLevel.BellLocation;
            bellButton.Size = new Size(50, 50);
            bellButton.BackColor = Color.Transparent;
            Controls.Add(bellButton);
        }
        
        this.BackgroundImage = new Bitmap(@"C:\Users\Markm\RiderProjects\MyGame\MyGame\Images\fon.png");

        for (int i = 0; i < enemies1.Length; i++)
        {
            enemies1[i] = new Enemy1(currentLevel.Enemies1Locations[i]);
        }
        
        for (int i = 0; i < enemies2.Length; i++)
        {
            enemies2[i] = new Enemy2(currentLevel.Enemies2Locations[i]);
        }
        
        for (int i = 0; i < traps.Length; i++)
        {
            traps[i] = new Trap(currentLevel.TrapsLocations[i]);
        }

        bellButton.Click += (sender, args) =>
        {
            if (this.currentLevelNumber == 0)
                this.finish.StartMoveToObject(bellButton.Location);
            
            foreach (var enemy in enemies1)
            {
                enemy.StartMoveToObject(bellButton.Location);
            }
        };
        
        MouseClick += (sender, args) =>
        {
            if (player.IsAlive)
                this.player.StartMoveToObject(new(MousePosition.X - 25, MousePosition.Y - 40));
        };


        MouseDoubleClick += (sender, args) =>
        {
            if (!player.IsAlive)
                InitializeComponent();
        };
        
        Paint += (sender, args) =>
        {
            if (!player.IsAlive)
                args.Graphics.DrawImage(Image.FromFile
                        ($"C:\\Users\\Markm\\RiderProjects\\MyGame\\MyGame\\Images\\Restart.png"), 
                    500, 400, 500, 300);
            
            args.Graphics.DrawImage(Image.FromFile
                    ($"C:\\Users\\Markm\\RiderProjects\\MyGame\\MyGame\\Images\\DangerIcon.png"), 
                61, 381, 70, 90);
            
            if (currentLevel.BellLocation.X != 0)
                args.Graphics.DrawImage(Image.FromFile
                        ($"C:\\Users\\Markm\\RiderProjects\\MyGame\\MyGame\\Images\\Bell.png"), 
                    currentLevel.BellLocation.X, currentLevel.BellLocation.Y, 50, 50);
            
            args.Graphics.DrawString
                ($"{this.tickNumber}", new Font("Serif", 24), Brushes.Black, new PointF());
            
            args.Graphics.DrawString
                (this.currentLevel.DescriptionText, new Font("Serif", 24), Brushes.Black, 
                    new PointF(768 - currentLevel.DescriptionText.Length * 8, 300));
            
            args.Graphics.DrawImage(Image.FromFile
                ($"C:\\Users\\Markm\\RiderProjects\\MyGame\\MyGame\\Images\\Finish.png"), 
                finish.Location.X, finish.Location.Y, finish.Size.Width, finish.Size.Height);
            
            foreach (var trap in this.traps)
            {
                PaintTrap(sender, args, trap);
            }

            PaintPlayer(sender, args);

            foreach (var enemy in this.enemies1)
            {
                PaintEnemy(sender, args, enemy);
            }
        };
    }
    
    private void PaintPlayer(object sender, PaintEventArgs args)
    {
        if (!player.IsAlive && player.AnimationNumber >= 4)
            args.Graphics.DrawImage(Image.FromFile
                    ("C:\\Users\\Markm\\RiderProjects\\MyGame\\MyGame\\Images\\PlayerSprites\\PlayerDead4.png"), 
                this.player.Location.X, this.player.Location.Y, this.player.Size.Width, this.player.Size.Height);
        
        else if (!player.IsAlive)
            args.Graphics.DrawImage(Image.FromFile
                    ($"C:\\Users\\Markm\\RiderProjects\\MyGame\\MyGame\\Images\\PlayerSprites\\PlayerDead{player.AnimationNumber}.png"), 
                this.player.Location.X, this.player.Location.Y, this.player.Size.Width, this.player.Size.Height);

        else if (!player.IsMove)
            args.Graphics.DrawImage(Image.FromFile
                    ($"C:\\Users\\Markm\\RiderProjects\\MyGame\\MyGame\\Images\\PlayerSprites\\PlayerIdle{player.AnimationNumber}.png"), 
                this.player.Location.X, this.player.Location.Y, this.player.Size.Width, this.player.Size.Height);
        
        else if (player.Direction == Direcion.Right) 
            args.Graphics.DrawImage(Image.FromFile
                    ($"C:\\Users\\Markm\\RiderProjects\\MyGame\\MyGame\\Images\\PlayerSprites\\PlayerWalk{player.AnimationNumber}.png"), 
                this.player.Location.X, this.player.Location.Y, this.player.Size.Width, this.player.Size.Height);

        else
        {
            var currentPlayerSprite =
                Image.FromFile
                    ($"C:\\Users\\Markm\\RiderProjects\\MyGame\\MyGame\\Images\\PlayerSprites\\PlayerWalk{player.AnimationNumber}.png");

            currentPlayerSprite.RotateFlip(RotateFlipType.RotateNoneFlipX);
            
            args.Graphics.DrawImage(currentPlayerSprite, 
                this.player.Location.X, this.player.Location.Y, this.player.Size.Width, this.player.Size.Height);
        }
    }

    private void PaintEnemy(object sender, PaintEventArgs args, Enemy1 enemy)
    {
        if (!enemy.IsAlive && enemy.AnimationNumber > 4)
            return;
        else if (!enemy.IsAlive && enemy.AnimationNumber < 5)
        {
            args.Graphics.DrawImage(Image.FromFile
                    ($"C:\\Users\\Markm\\RiderProjects\\MyGame\\MyGame\\Images\\Enemy1Sprites\\Enemy1Dead{enemy.AnimationNumber}.png"),
                enemy.Location.X, enemy.Location.Y, enemy.Size.Width, enemy.Size.Height);
        }
        else if (enemy.IsAttack)
        {
            if (enemy.Direction == Direcion.Left)
            {
                var currentEnemySprite = Image.FromFile
                    ($"C:\\Users\\Markm\\RiderProjects\\MyGame\\MyGame\\Images\\Enemy1Sprites\\Enemy1Attack{enemy.AnimationNumber}.png");

                currentEnemySprite.RotateFlip(RotateFlipType.RotateNoneFlipX);

                args.Graphics.DrawImage(currentEnemySprite,
                    enemy.Location.X, enemy.Location.Y, 90, 80);
            }
            else
                args.Graphics.DrawImage(Image.FromFile
                        ($"C:\\Users\\Markm\\RiderProjects\\MyGame\\MyGame\\Images\\Enemy1Sprites\\Enemy1Attack{enemy.AnimationNumber}.png"),
                    enemy.Location.X, enemy.Location.Y, 90, 80);
        }
        else if (!enemy.IsMove)
            args.Graphics.DrawImage(Image.FromFile
                    ($"C:\\Users\\Markm\\RiderProjects\\MyGame\\MyGame\\Images\\Enemy1Sprites\\Enemy1Idle{enemy.AnimationNumber}.png"),
                enemy.Location.X, enemy.Location.Y, enemy.Size.Width, enemy.Size.Height);
        
        else if (enemy.Direction == Direcion.Right) 
            args.Graphics.DrawImage(Image.FromFile
                    ($"C:\\Users\\Markm\\RiderProjects\\MyGame\\MyGame\\Images\\Enemy1Sprites\\Enemy1Run{enemy.AnimationNumber}.png"),
                enemy.Location.X, enemy.Location.Y, enemy.Size.Width, enemy.Size.Height);
        else
        { 
            var currentEnemySprite = 
                Image.FromFile
                    ($"C:\\Users\\Markm\\RiderProjects\\MyGame\\MyGame\\Images\\Enemy1Sprites\\Enemy1Run{enemy.AnimationNumber}.png"); 
            
            currentEnemySprite.RotateFlip(RotateFlipType.RotateNoneFlipX);

            args.Graphics.DrawImage(currentEnemySprite, enemy.Location.X, enemy.Location.Y, enemy.Size.Width,
                enemy.Size.Height);
        }
    }

    private void PaintTrap(object sender, PaintEventArgs args, Trap trap)
    {
        if (trap.IsActive)
            args.Graphics.DrawImage(Image.FromFile
                ("C:\\Users\\Markm\\RiderProjects\\MyGame\\MyGame\\Images\\TrapSprites\\Trap1.png"), trap.Location.X, trap.Location.Y,
                trap.Size.Width, trap.Size.Height);
        else
        {
            args.Graphics.DrawImage(Image.FromFile
                    ($"C:\\Users\\Markm\\RiderProjects\\MyGame\\MyGame\\Images\\TrapSprites\\Trap{trap.AnimationNumber}.png"), trap.Location.X, trap.Location.Y,
                trap.Size.Width, trap.Size.Height);
        }
    }

    private PictureBox bellButton;
    private Enemy2[] enemies2;
    private Trap[] traps;
    private Finish finish;
    private Enemy1[] enemies1;
    private Player player;

    #endregion
}