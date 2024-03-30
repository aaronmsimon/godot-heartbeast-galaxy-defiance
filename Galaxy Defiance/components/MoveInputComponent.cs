using Godot;

public partial class MoveInputComponent : Node
{
    [Export] private MoveComponent moveComponent;
    [Export] private MoveStats moveStats;

    public override void _Input(InputEvent @event)
    {
        float input_axis = Input.GetAxis("ui_left", "ui_right");
        moveComponent.velocity = new Vector2(input_axis * moveStats.speed, 0);
    }
}
