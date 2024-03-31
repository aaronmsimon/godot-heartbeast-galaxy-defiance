using Godot;

public partial class GameOver : Control
{
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("ui_accept"))
        {
            GetTree().ChangeSceneToFile("res://menus/menu.tscn");
        }
    }
}
