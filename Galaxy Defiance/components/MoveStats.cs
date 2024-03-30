using Godot;

public partial class MoveStats : Resource
{
    [Export] public float speed { get; set; }

    public MoveStats()
    {
        speed = 100f;
    }
}
