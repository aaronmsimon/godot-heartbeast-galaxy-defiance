using Godot;

public partial class PinkEnemyProjectile : Node2D
{
    private HitboxComponent hitboxComponent;
    private VisibleOnScreenNotifier2D visibleOnScreenNotifier2D;
    private ScaleComponent scaleComponent;

    public override void _Ready()
    {
        hitboxComponent = GetNode<HitboxComponent>("Anchor/HitboxComponent");
        visibleOnScreenNotifier2D = GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D");
        scaleComponent = GetNode<ScaleComponent>("ScaleComponent");

        scaleComponent.TweenScale();
        visibleOnScreenNotifier2D.ScreenExited += QueueFree;
        hitboxComponent.HitHurtbox += (HurtboxComponent hurtbox) => QueueFree();
    }
}
