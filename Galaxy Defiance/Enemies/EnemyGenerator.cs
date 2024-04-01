using Godot;

public partial class EnemyGenerator : Node2D
{
    [Export] private int margin = 8;
    [Export] private int topMargin = 16;
    [Export] private PackedScene greenEnemyScene;
    [Export] private PackedScene yellowEnemyScene;

    private SpawnerComponent spawnerComponent;
    private Timer greenEnemySpawnTimer;
    private Timer yellowEnemySpawnTimer;

    private int screenWidth = (int)ProjectSettings.GetSetting("display/window/size/viewport_width");

    public override void _Ready()
    {
        spawnerComponent = GetNode<SpawnerComponent>("SpawnerComponent");
        greenEnemySpawnTimer = GetNode<Timer>("GreenEnemySpawnTimer");
        yellowEnemySpawnTimer = GetNode<Timer>("YellowEnemySpawnTimer");

        greenEnemySpawnTimer.Timeout += () => HandleSpawn(greenEnemyScene, greenEnemySpawnTimer);
        yellowEnemySpawnTimer.Timeout += () => HandleSpawn(yellowEnemyScene, yellowEnemySpawnTimer);
    }

    private void HandleSpawn(PackedScene enemyScene, Timer timer)
    {
        spawnerComponent.Scene = enemyScene;
        spawnerComponent.Spawn(new Vector2(GD.RandRange(margin, screenWidth - margin), -topMargin));
        timer.Start();
    }
}
