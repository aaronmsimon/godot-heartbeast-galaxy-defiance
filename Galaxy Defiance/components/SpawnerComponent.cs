using Godot;

public partial class SpawnerComponent : Node2D
{
    // Export the dependencies for this component
    // The scene we want to spawn
    [Export] private PackedScene scene;

    // Spawn an instance of the scene at a specific global position on a parent
    // By default the parent is the current "main" scene , but you can pass in an alternative parent if you so choose.
    public Node Spawn(Vector2? globalSpawnPosition = null, Node parent = null)
    {
// func spawn(global_spawn_position: Vector2 = global_position, parent: Node = get_tree().current_scene) -> Node:
        Debug.Assert(scene is PackedScene, "Error: The scene export was never set on this spawner component.");
        // Instance the scene
        Node2D instance = (Node2D)scene.Instantiate();
        // Add it as a child of the parent
        parent = parent == null ? GetTree().CurrentScene : parent;
        parent.AddChild(instance);
        // Update the global position of the instance.
        // (This must be done after adding it as a child)
        globalSpawnPosition = globalSpawnPosition == null ? GlobalPosition : globalSpawnPosition;
        instance.GlobalPosition = (Vector2)globalSpawnPosition;
        // Return the instance in case we want to perform any other operations on it after instancing it.
        return instance;
    }
}
