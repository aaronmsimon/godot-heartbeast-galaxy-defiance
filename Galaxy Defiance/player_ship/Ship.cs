using Godot;

public partial class Ship : Node2D
{
    private Marker2D leftMuzzle;
    private Marker2D rightMuzzle;
    private SpawnerComponent spawnerComponent;
    private Timer fireRateTimer;
    private ScaleComponent scaleComponent;

    public override void _Ready()
    {
        leftMuzzle = GetNode<Marker2D>("LeftMuzzle");
        rightMuzzle = GetNode<Marker2D>("RightMuzzle");
        spawnerComponent = GetNode<SpawnerComponent>("SpawnerComponent");
        fireRateTimer = GetNode<Timer>("FireRateTimer");
        scaleComponent = GetNode<ScaleComponent>("ScaleComponent");

        fireRateTimer.Timeout += FireLasers;
    }

    public void FireLasers()
    {
        spawnerComponent.Spawn(leftMuzzle.GlobalPosition);
        spawnerComponent.Spawn(rightMuzzle.GlobalPosition);

        scaleComponent.TweenScale();
    }
}
