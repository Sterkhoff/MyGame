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
        this.playerControl = new PlayerControl();

        this.playerControl.Dock = System.Windows.Forms.DockStyle.Fill;
        this.playerControl.Location = new System.Drawing.Point(0, 0);
        this.playerControl.Name = "playerControl";
        this.playerControl.Size = new System.Drawing.Size(1920, 1080);
        this.playerControl.TabIndex = 2;
        
        this.Controls.Add(playerControl);
    }
    
    private PlayerControl playerControl;
    #endregion
}