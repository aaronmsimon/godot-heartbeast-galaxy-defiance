using Godot;

public partial class ScaleComponent : Node
{
    // Export the sprite that this component will be scaling
    [Export] private Node2D sprite;

    // Export the scale amount (as a vector)
    [Export] private Vector2 scale_amount = new Vector2(1.5f, 1.5f);

    // Export the scale duration
    [Export] private float scaleDuration = 0.4f;

    // This is the function that will activate this component
    public void TweenScale()
    {
        // We are going to scale the sprite using a tween (so we can make is smooth)
        // First we create the tween and set it's transition type and easing type
        Tween tween = CreateTween().SetTrans(Tween.TransitionType.Expo).SetEase(Tween.EaseType.Out);
        
        // Next we scale the sprite from its current scale to the scale amount (in 1/10th of the scale duration)
        tween.TweenProperty(sprite, "scale", scale_amount, scaleDuration * 0.1).FromCurrent();
        // Finally we scale back to a value of 1 for the other 9/10ths of the scale duration
        // Consider that we always scale back to a value of 1, you could store the starting scale amount for the sprite as well for games where your character doesn't start with a scale of 1
        tween.TweenProperty(sprite, "scale", Vector2.One, scaleDuration * 0.9).From(scale_amount);
    }
}
