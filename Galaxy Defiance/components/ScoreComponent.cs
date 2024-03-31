using Godot;

public partial class ScoreComponent : Node
{
    // Export the game stats so we can manipulate the game score
    [Export] private GameStats gameStats;

    // Export the amount the score should be adjusted
    [Export] private int adjustAmount = 5;

    // This is the function that we call to activate this component. By default it will use the adjust_amount when called but we could optionally pass in a different amount.
    public void AdjustScore()
    {
        gameStats.Score += adjustAmount;
    }

    public void AdjustScore(int amount)
    {
        gameStats.Score += amount;
    }
}
