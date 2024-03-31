using Godot;

public partial class SpaceBackground : ParallaxBackground
{
    private ParallaxLayer spaceLayer;
    private ParallaxLayer farStarsLayer;
    private ParallaxLayer closeStarsLayer;

    public override void _Ready()
    {
        spaceLayer = GetNode<ParallaxLayer>("%SpaceLayer");
        farStarsLayer = GetNode<ParallaxLayer>("%FarStarsLayer");
        closeStarsLayer = GetNode<ParallaxLayer>("%CloseStarsLayer");
    }

    public override void _Process(double delta)
    {
        spaceLayer.MotionOffset += new Vector2(0, 2f * (float)delta);
        closeStarsLayer.MotionOffset += new Vector2(0, 20f * (float)delta);
        farStarsLayer.MotionOffset += new Vector2(0, 5f * (float)delta);
    }
}
