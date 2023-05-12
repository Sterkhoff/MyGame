namespace MyGame.Domain;

public class Finish
{
    public Finish(Point location)
    {
        Location = location;
        HitBox = new PictureBox{Size = new (20, 20), BackColor = Color.Green, Location = location};
    }

    public Point Location { get; }
    public PictureBox HitBox { get; }
}