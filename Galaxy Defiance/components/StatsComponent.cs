using Godot;

public partial class StatsComponent : Node
{
    // Create the health variable and connect a setter
    [Export] private int health = 1;

    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;

            // Signal out that the health has changed
            EmitSignal(SignalName.HealthChanged);
            
            // Signal out when health is at 0
            if (health == 0) EmitSignal(SignalName.NoHealth);
        }

    }

    // Create our signals for health
    [Signal]
    public delegate void HealthChangedEventHandler(); // Emit when the health value has changed

    [Signal]
    public delegate void NoHealthEventHandler(); // Emit when there is no health left
}
