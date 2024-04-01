using Godot;

public partial class TimedStateComponent : StateComponent
{
    // This component is used to create a state that automatically disables itself after a duration

    // Export the duration for this state
    [Export] float duration = 1f;

    // Create a new timer
    private Timer timer = new Timer();

    public TimedStateComponent()
    {
        // Add the timer as a child so we can use it
        AddChild(timer);
        
        // Connect to the timeout functino on the timer
        timer.Timeout += () => {
            // Emit finished because this state is finished
            EmitSignal(SignalName.StateFinished);
            
            // Disable this state
            Disable();
        };
        
        // Start the timer whenever this state is enabled
        Enabled += () => {
            timer.Start(duration);
        };
    }
}
