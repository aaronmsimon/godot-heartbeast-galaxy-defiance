using Godot;

public partial class Laser : Node2D
{
    private VisibleOnScreenNotifier2D visibleOnScreenNotifier2D;
    private ScaleComponent scaleComponent;
    private FlashComponent flashComponent;

    public override async void _Ready()
    {
        visibleOnScreenNotifier2D = GetNode<VisibleOnScreenNotifier2D>("VisibleOnScreenNotifier2D");
        scaleComponent = GetNode<ScaleComponent>("ScaleComponent");
        flashComponent = GetNode<FlashComponent>("FlashComponent");

        scaleComponent.TweenScale();
        await flashComponent.Flash();
        visibleOnScreenNotifier2D.ScreenExited += () => QueueFree();
    }
}
