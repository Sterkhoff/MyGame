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
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1920, 1080);
        this.WindowState = FormWindowState.Maximized;
        this.FormBorderStyle = FormBorderStyle.None;
        this.Text = "Form1";
        
        this.Controls.Add(game.CurrentLevel.Finish.HitBox);
        this.Controls.Add(game.CurrentLevel.Player.HitBox);
        foreach (var enemy in game.CurrentLevel.Enemies)
        {
            this.Controls.Add(enemy.HitBox);
        }
        MouseClick += (sender, args) =>
        {
            game.CurrentLevel.Player.Controller.StartMovePlayerToMouse(MousePosition);

            foreach (var enemy in game.CurrentLevel.Enemies)
            {
                enemy.Controller.StartMoveEnemyToPlayer(game.CurrentLevel.Player.Location);
            }
        };
    }
    #endregion
}