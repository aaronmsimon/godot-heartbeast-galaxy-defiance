using Godot;

public partial class GameOver : Control
{
    [Export] private GameStats gameStats;

    private Label scoreValue;
    private Label highScoreValue;

    public override void _Ready()
    {
        scoreValue = GetNode<Label>("%ScoreValue");
        highScoreValue = GetNode<Label>("%HighScoreValue");

        if (gameStats.Score > gameStats.HighScore)
        {
            gameStats.HighScore = gameStats.Score;
        }

        scoreValue.Text = gameStats.Score.ToString();
        highScoreValue.Text = gameStats.HighScore.ToString();
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("ui_accept"))
        {
            gameStats.Score = 0;
            GetTree().ChangeSceneToFile("res://menus/menu.tscn");
        }
    }
}
