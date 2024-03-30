using Godot;

public partial class PositionClampComponent : Node2D
{
    // Export the actor who's position will be clamped
    [Export] private Node2D actor;

    // Export a margin for left and right (margin.x) and top and bottom (margin.y)
    [Export] private int margin = 8;

    // Define the left and right borders to bounce on
    private int leftBorder = 0;
    // Use the display viewport width to get the right border of the screen
    int rightBorder = (int)ProjectSettings.GetSetting("display/window/size/viewport_width");

    public override void _Process(double delta)
    {
        // clamp the x position of the actor between the left border and the right border (accounting for the margin)
        actor.GlobalPosition = new Vector2(Mathf.Clamp(actor.GlobalPosition.X, leftBorder + margin, rightBorder - margin), actor.GlobalPosition.Y);
    }
}
