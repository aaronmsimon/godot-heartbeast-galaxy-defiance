using Godot;

public partial class BorderBounceComponent : Node
{
    // The margin is used to allow actors to bounce before reaching the edge of the border
    [Export] private int margin;

    // Export the actor that this component will operate on
    [Export] private Node2D actor;

    // We need to grab the move component of the actor in order to change its velocity when bouncing
    [Export] private MoveComponent moveComponent;

    // Define the left and right borders to bounce on
    private int leftBorder = 0;
    // Use the display viewport width to get the right border of the screen
    private int rightBorder = (int)ProjectSettings.GetSetting("display/window/size/viewport_width");

    public override void _Process(double delta)
    {
        // If the actor's x position is less than the left border plus the margin, bounce off the left side of the screen
        if (actor.GlobalPosition.X < leftBorder + margin)
        {
            // Prevent the actor for going past the border + the margin
            actor.GlobalPosition = new Vector2(leftBorder + margin, actor.GlobalPosition.Y);
            // When bouncing we use the .bounce function which takes a wall normal
            // This wall normal is the direction of the face of the wall
            // (it's a bit counter intuitive but a wall on the left would have a wall face with a normal of RIGHT)
            moveComponent.velocity = moveComponent.velocity.Bounce(Vector2.Right);
        }
        // If the actor's x position is greater than the right border plus the margin, bounce off the right side of the screen
        else if (actor.GlobalPosition.X > rightBorder - margin)
        {
            // Prevent the actor for going past the border + the margin
            actor.GlobalPosition = new Vector2(rightBorder - margin, actor.GlobalPosition.Y);
            // When bouncing we use the .bounce function which takes a wall normal
            // This wall normal is the direction of the face of the wall
            // (it's a bit counter intuitive but a wall on the right would have a wall face with a normal of LEFT)
            moveComponent.velocity = moveComponent.velocity.Bounce(Vector2.Left);
        }
    }
}
