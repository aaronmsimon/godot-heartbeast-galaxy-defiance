using Godot;

public partial class Menu : Control
{
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("ui_accept"))
        {
            GetTree().ChangeSceneToFile("res://world.tscn");
        }
    }
}
