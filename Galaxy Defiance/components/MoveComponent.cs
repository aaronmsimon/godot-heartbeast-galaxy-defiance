using Godot;

public partial class MoveComponent : Node
{
    [Export] private Node2D actor;
    [Export] public Vector2 velocity;

    public override void _Process(double delta)
    {
        actor.Translate(velocity * (float)delta);
    }
}
