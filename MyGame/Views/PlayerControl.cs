using MyGame.Domain;

namespace MyGame;

public partial class PlayerControl : UserControl
{
    private readonly Dictionary<string, Bitmap> bitmaps = new ();
    
    private PictureBox playerHitBox;
    
    private Game game;

    private int tickNumber;

    private int animationNumber = 1;

    private Point positionAfterStep;

    private int moves;

    public PlayerControl()
    {
        InitializeComponent();
    }
    
    public void Configure(Game game, DirectoryInfo imagesDirectory = null)
    {
        if (this.game != null)
            return;

        playerHitBox = new PictureBox()
            { Size = game.player.PlayerSize, Location = game.player.Location, 
                SizeMode = PictureBoxSizeMode.CenterImage};
        
        if (imagesDirectory == null)
            imagesDirectory = new DirectoryInfo("C:\\Users\\Markm\\RiderProjects\\MyGame\\MyGame\\Images");
        
        foreach (var e in imagesDirectory.GetFiles("*.png"))
            bitmaps[e.Name] = (Bitmap) Image.FromFile(e.FullName);
        
        playerHitBox.Image = bitmaps["Idle1.png"];

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
        var newMousePos = new Point(MousePosition.X - 25, MousePosition.Y - 40);
        
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
        if (tickNumber % 5 == 0)
        {
            if (animationNumber > 5)
                animationNumber = 1;
            
            playerHitBox.Image = bitmaps[$"Idle{animationNumber}.png"];
            animationNumber++;
            tickNumber = 0;
        }

        tickNumber++;
        
        if (moves > 0)
        {
            MoveToMouse(positionAfterStep);
            moves--;
        }
    }
}