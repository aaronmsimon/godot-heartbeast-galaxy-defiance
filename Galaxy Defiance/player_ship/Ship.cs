using Godot;

public partial class Ship : Node2D
{
    private Marker2D leftMuzzle;
    private Marker2D rightMuzzle;
    private SpawnerComponent spawnerComponent;
    private Timer fireRateTimer;
    private ScaleComponent scaleComponent;
    private AnimatedSprite2D shipSprite;
    private MoveComponent moveComponent;
    private AnimatedSprite2D flameSprite;
    private VariablePitchAudioStreamPlayer variablePitchAudioStreamPlayer;

    public override void _Ready()
    {
        leftMuzzle = GetNode<Marker2D>("LeftMuzzle");
        rightMuzzle = GetNode<Marker2D>("RightMuzzle");
        spawnerComponent = GetNode<SpawnerComponent>("SpawnerComponent");
        fireRateTimer = GetNode<Timer>("FireRateTimer");
        scaleComponent = GetNode<ScaleComponent>("ScaleComponent");
        shipSprite = GetNode<AnimatedSprite2D>("Anchor/ShipSprite");
        moveComponent = GetNode<MoveComponent>("MoveComponent");
        flameSprite = GetNode<AnimatedSprite2D>("Anchor/FlameAnimatedSprite");
        variablePitchAudioStreamPlayer = GetNode<VariablePitchAudioStreamPlayer>("VariablePitchAudioStreamPlayer");

        fireRateTimer.Timeout += FireLasers;
    }

    public override void _Process(double delta)
    {
        AnimateTheShip();
    }

    private void FireLasers()
    {
        variablePitchAudioStreamPlayer.PlayWithVariance();
        
        spawnerComponent.Spawn(leftMuzzle.GlobalPosition);
        spawnerComponent.Spawn(rightMuzzle.GlobalPosition);

        scaleComponent.TweenScale();
    }

    private void AnimateTheShip()
    {
        if (moveComponent.velocity.X < 0)
        {
            shipSprite.Play("bank_left");
            flameSprite.Play("bank_left");
        }
        else if (moveComponent.velocity.X > 0)
        {
            shipSprite.Play("bank_right");
            flameSprite.Play("bank_right");
        }
        else
        {
            shipSprite.Play("center");
            flameSprite.Play("center");
        }
    }
}
