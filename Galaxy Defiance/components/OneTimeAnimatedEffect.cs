using Godot;

public partial class OneTimeAnimatedEffect : AnimatedSprite2D
{
    // This effect exports animated sprite so we can give it a sprite frames resource (to animate the effect)
    // and so we can connect to the animation_finished signal to free it

    public override void _Ready()
    {
        // Free this node when the animation is finished
        AnimationFinished += () => QueueFree();
        AnimationLooped += () => QueueFree();
    }
}
