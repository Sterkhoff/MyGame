using MyGame.Domain;

namespace MyGame;

public partial class PlayerControl : UserControl
{
    private PictureBox playerHitBox;
    
    private Game game;

    private Point positionAfterStep;

    private int moves;

    public PlayerControl()
    {
        InitializeComponent();
    }
    
    public void Configure(Game game)
    {
        if (this.game != null)
            return;

        playerHitBox = new PictureBox()
            { Size = game.player.PlayerSize, Location = game.player.Location, BackColor = Color.Blue };
        
        Controls.Add(playerHitBox);

        this.game = game;

        MouseClick += (sender, args) =>
        {
            positionAfterStep = MousePosition;
            moves = 40;
        };
    }

    public void MoveToMouse(Point MousePosition)
    {
        var newMousePos = new Point(MousePosition.X - 50, MousePosition.Y - 50);
        
        var angle = Math.Atan(Math.Abs(newMousePos.Y - game.player.Location.Y) /
                              (double)Math.Abs(newMousePos.X - game.player.Location.X));

        if (newMousePos.X > game.player.Location.X && newMousePos.Y > game.player.Location.Y)
        {
                game.player.Location =
                    new Point(game.player.Location.X + (int)Math.Round(2 * Math.Cos(angle)),
                        game.player.Location.Y + (int)Math.Round(2 * Math.Sin(angle)));
        }

        else if (newMousePos.X < game.player.Location.X && newMousePos.Y > game.player.Location.Y)
        {
                game.player.Location =
                    new Point(game.player.Location.X - (int)Math.Round(2 * Math.Cos(angle)),
                        game.player.Location.Y + (int)Math.Round(2 * Math.Sin(angle)));
        }

        else if (newMousePos.X < game.player.Location.X && newMousePos.Y < game.player.Location.Y)
        {
                game.player.Location =
                    new Point(game.player.Location.X - (int)Math.Round(2 * Math.Cos(angle)),
                        game.player.Location.Y - (int)Math.Round(2 * Math.Sin(angle)));
        }

        else if (newMousePos.X > game.player.Location.X && newMousePos.Y < game.player.Location.Y)
        {
                game.player.Location =
                    new Point(game.player.Location.X + (int)Math.Round(2 * Math.Cos(angle)),
                        game.player.Location.Y - (int)Math.Round(2 * Math.Sin(angle)));
        }

        playerHitBox.Location = game.player.Location;
    }

    public void CheckUpdates()
    {
        if (moves > 0)
        {
            MoveToMouse(positionAfterStep);
            moves--;
        }
    }
}