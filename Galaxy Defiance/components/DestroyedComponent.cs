using Godot;

public partial class DestroyedComponent : Node
{
    // Export the actor this component will operate on
    [Export] private Node2D actor;

    // Grab access to the stats so we can tell when the health has reached zero
    [Export] private StatsComponent statsComponent;

    // Export and grab access to a spawner component so we can create an effect on death
    [Export] private SpawnerComponent destroyEffectSpawnerComponent;

    public override void _Ready()
    {
        // Connect the the no health signal on our stats to the destroy function
        statsComponent.NoHealth += () => Destroy();
    }

    public void Destroy()
    {
        // create an effect (from the spawner component) and free the actor
        destroyEffectSpawnerComponent.Spawn(actor.GlobalPosition);
        actor.QueueFree();
    }
}
