using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
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
        this.BackColor = Color.Chartreuse;
        this.start = new PictureBox()
        {
            Image = Resources.Start, SizeMode = PictureBoxSizeMode.StretchImage,
            Location = new(435, 200), Size = new(600, 350), BackColor = Color.Transparent,
        };
        this.exit = new PictureBox()
        {
            Image = Resources.Exit, SizeMode = PictureBoxSizeMode.StretchImage,
            Location = new(535, 550), Size = new(400, 200), BackColor = Color.Transparent,
        };
        this.Controls.Add(start);
        this.Controls.Add(exit);
        
        start.Click += (sender, args) =>
        {
            Controls.Clear();
            this.AddLevelsButtons();
        };

        exit.Click += (sender, args) =>
        {
            this.Close();
        };
    }

    private PictureBox start;
    private PictureBox exit;
    private CurrentLevel currentLevel;

    #endregion
}