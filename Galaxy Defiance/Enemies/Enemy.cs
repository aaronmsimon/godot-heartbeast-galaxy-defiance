using Godot;

public partial class Enemy : Node2D
{
    protected StatsComponent statsComponent;
    protected MoveComponent moveComponent;
    protected VisibleOnScreenNotifier2D visibleOnScreenNotifier2D;
    protected ScaleComponent scaleComponent;
    protected FlashComponent flashComponent;
    protected ShakeComponent shakeComponent;
    protected HurtboxComponent hurtboxComponent;
    protected HitboxComponent hitboxComponent;
    protected DestroyedComponent destroyedComponent;
    protected ScoreComponent scoreComponent;

    public override void _Ready()
    {
        statsComponent = GetParent().GetNode<StatsComponent>("StatsComponent");
        moveComponent = GetParent().GetNode<MoveComponent>("MoveComponent");
        visibleOnScreenNotifier2D = GetParent().GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D");
        scaleComponent = GetParent().GetNode<ScaleComponent>("ScaleComponent");
        flashComponent = GetParent().GetNode<FlashComponent>("FlashComponent");
        shakeComponent = GetParent().GetNode<ShakeComponent>("ShakeComponent");
        hurtboxComponent = GetParent().GetNode<HurtboxComponent>("HurtboxComponent");
        hitboxComponent = GetParent().GetNode<HitboxComponent>("HitboxComponent");
        destroyedComponent = GetParent().GetNode<DestroyedComponent>("DestroyedComponent");
        scoreComponent = GetParent().GetNode<ScoreComponent>("ScoreComponent");

        statsComponent.NoHealth += () => {
            scoreComponent.AdjustScore();
        };

        visibleOnScreenNotifier2D.ScreenExited += () => QueueFree();
        hurtboxComponent.Hurt += async (hitboxComponent) => {
            scaleComponent.TweenScale();
            await flashComponent.Flash();
            shakeComponent.TweenShake();
        };

        statsComponent.NoHealth += () => QueueFree();

        hitboxComponent.HitHurtbox += (hurtboxComponent) => destroyedComponent.Destroy();
    }
}
