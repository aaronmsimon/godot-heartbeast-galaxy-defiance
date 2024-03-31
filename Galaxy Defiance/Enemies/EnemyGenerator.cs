using Godot;

public partial class EnemyGenerator : Node2D
{
    [Export] private int margin = 8;
    [Export] private int topMargin = 16;
    [Export] private PackedScene greenEnemyScene;

    private SpawnerComponent spawnerComponent;
    private Timer greenEnemySpawnTimer;

    private int screenWidth = (int)ProjectSettings.GetSetting("display/window/size/viewport_width");

    public override void _Ready()
    {
        spawnerComponent = GetNode<SpawnerComponent>("SpawnerComponent");
        greenEnemySpawnTimer = GetNode<Timer>("GreenEnemySpawnTimer");

        greenEnemySpawnTimer.Timeout += () => HandleSpawn(greenEnemyScene, greenEnemySpawnTimer);
    }

    private void HandleSpawn(PackedScene enemyScene, Timer timer)
    {
        spawnerComponent.Scene = enemyScene;
        spawnerComponent.Spawn(new Vector2(GD.RandRange(margin, screenWidth - margin), -topMargin));
        timer.Start();
    }
}
