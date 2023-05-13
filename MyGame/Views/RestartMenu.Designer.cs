using System.ComponentModel;

namespace MyGame;

partial class RestartMenu
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary> 
    /// Clean up any resources being used.
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

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.DoubleBuffered = true;
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(1920, 1080);

        this.restartButton = new Button();
        restartButton.Location = new Point(560, 500);
        restartButton.Size = new Size(400, 100);
        restartButton.Text = "Restart";
        restartButton.Click += (sender, args) => { Hide(); };
        this.Controls.Add(restartButton);
    }

    private Button restartButton;

    #endregion
}