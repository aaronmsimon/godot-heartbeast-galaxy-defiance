using Godot;

public partial class World : Node2D
{
    [Export] private GameStats gameStats;
    [Export] private double deathToGameOverTime = 1;

    private Ship ship;
    private Label scoreLabel;

    public override void _Ready()
    {
        ship = GetNode<Ship>("Ship");
        scoreLabel = GetNode<Label>("ScoreLabel");

        UpdateScoreLabel(gameStats.Score);
        gameStats.ScoreChanged += UpdateScoreLabel;

        ship.TreeExiting += async () => {
            await ToSignal(GetTree().CreateTimer(deathToGameOverTime), Timer.SignalName.Timeout);
            GetTree().ChangeSceneToFile("res://menus/game_over.tscn");
        };
    }

    public override void _ExitTree()
    {
        gameStats.ScoreChanged -= UpdateScoreLabel;
    }

    private void UpdateScoreLabel(int newScore)
    {
        scoreLabel.Text = "Score: " + newScore;
    }
}
