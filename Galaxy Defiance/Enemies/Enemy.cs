using Godot;

public partial class Enemy : Node2D
{
    private StatsComponent statsComponent;
    private MoveComponent moveComponent;
    private VisibleOnScreenNotifier2D visibleOnScreenNotifier2D;
    private ScaleComponent scaleComponent;
    private FlashComponent flashComponent;
    private ShakeComponent shakeComponent;

    public override void _Ready()
    {
        statsComponent = GetNode<StatsComponent>("StatsComponent");
        moveComponent = GetNode<MoveComponent>("MoveComponent");
        visibleOnScreenNotifier2D = GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D");
        scaleComponent = GetNode<ScaleComponent>("ScaleComponent");
        flashComponent = GetNode<FlashComponent>("FlashComponent");
        shakeComponent = GetNode<ShakeComponent>("ShakeComponent");

        visibleOnScreenNotifier2D.ScreenExited += () => QueueFree();
    }
}
