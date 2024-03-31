using Godot;

public partial class World : Node2D
{
    [Export] private double deathToGameOverTime = 1;

    private Ship ship;

    public override void _Ready()
    {
        ship = GetNode<Ship>("Ship");

        ship.TreeExiting += async () => {
            await ToSignal(GetTree().CreateTimer(deathToGameOverTime), Timer.SignalName.Timeout);
            GetTree().ChangeSceneToFile("res://menus/game_over.tscn");
        };
    }
}
