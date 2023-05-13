using MyGame.Domain;

namespace MyGame;

partial class MainForm
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
        this.enemies = new Enemy1[currentLevel.EnemiesLocations.Length];
        this.traps = new Trap[currentLevel.TrapsLocations.Length];
        this.restartMenu = new RestartMenu();
        
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i] = new Enemy1(currentLevel.EnemiesLocations[i]);
        }
        
        for (int i = 0; i < traps.Length; i++)
        {
            traps[i] = new Trap(currentLevel.TrapsLocations[i]);
        }
        
        MouseClick += (sender, args) =>
        {
            this.player.Controller.StartMovePlayerToMouse(MousePosition);

            foreach (var enemy in this.enemies)
            {
                enemy.Controller.StartMoveEnemyToPlayer(this.player.Location);
            }
        };
        
        Paint += (sender, args) =>
        {
            args.Graphics.FillRectangle
                (Brushes.Blue, this.player.Location.X, this.player.Location.Y, 50, 80);
            
            args.Graphics.FillRectangle
                (Brushes.GreenYellow, finish.Location.X, finish.Location.Y, 50, 50);
            
            foreach (var enemy in this.enemies)
            {
                if (enemy.IsAlive)
                    args.Graphics.FillRectangle
                        (Brushes.Red, enemy.Location.X, enemy.Location.Y, 50, 80);
            }

            foreach (var trap in this.traps)
            {
                args.Graphics.FillRectangle(Brushes.Black, trap.Location.X, trap.Location.Y, 50, 50);
            }
        };
    }

    private Trap[] traps;
    private Finish finish;
    private RestartMenu restartMenu;
    private Enemy1[] enemies;
    private Player player;

    #endregion
}