using Godot;

public partial class ShakeComponent : Node2D
{
    // You should shake the sprite and not the root node or you'll get unexpected behavior since we are manipulating the position of the node and moving it to 0,0

    // Export the node that this component will be shaking
    [Export] private Node2D node;

    // Export the shake amount
    [Export] private float shakeAmount = 2f;

    // Export the shake duration
    [Export] private float shakeDuration = 0.4f;

    // Store the current amount we are shaking the node (this value will decrease over time)
    private float shake = 0f;

    // This is the function that activates this component
    public void TweenShake()
    {
        // Set the shake to the shake amount (shake is the value used in the process function to shake the node)
        shake = shakeAmount;
        
        // Create a tween
        Tween tween = CreateTween();
        
        // Tween the shake value from current down to 0 over the shake duration
        tween.TweenProperty(this, "shake", 0f, shakeDuration).FromCurrent();
    }

    public override void _PhysicsProcess(double delta)
    {
        // Manipulate the position of the node by the shake amount every physics frame
        // Use randf_range to pick a random x and y value using the shake value
        node.Position = new Vector2((float)GD.RandRange(-shake, shake), (float)GD.RandRange(-shake, shake));
    }
}
