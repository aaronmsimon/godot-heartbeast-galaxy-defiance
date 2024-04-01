using Godot;

public partial class StateComponent : Node
{
    // Create some signals for the state
    [Signal]
    public delegate void EnabledEventHandler(); // Emit when the state has been enabled

    [Signal]
    public delegate void DisabledEventHandler(); // Emit when the state has been disabled

    [Signal]
    public delegate void StateFinishedEventHandler(); // Emit when the state is finished (not always the same as diabling it)

    // This function is used to disable the state (and all its children)
    public virtual void Disable()
    {
        EmitSignal(SignalName.Disabled);
        // We can set the process mode to disabled to disable the node and its children
        ProcessMode = ProcessModeEnum.Disabled;
    }

    // This function is used to enable the state (and all its children)
    public virtual void Enable()
    {
        EmitSignal(SignalName.Enabled);
        // We can set the process mode to inherit to enable the node and its children
        // We use inheirt so this node will still pause if the game is paused or a parent is disabled
        ProcessMode = ProcessModeEnum.Inherit;
    }

    public void StateFinish()
    {
        EmitSignal(SignalName.StateFinished);
    }
}
