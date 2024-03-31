using Godot;

public partial class GameStats : Resource
{
    [Export] private int score = 0;
    [Export] private int highScore = 0;

    [Signal]
    public delegate void ScoreChangedEventHandler(int newScore);

    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            EmitSignal(SignalName.ScoreChanged, score);
        }
    }

    public int HighScore { get; set; }
}
