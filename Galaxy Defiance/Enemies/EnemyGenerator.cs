using System;
using Godot;
using System.Diagnostics;

public partial class EnemyGenerator : Node2D
{
    [ExportGroup("Margin Settings")]
    [Export] private int margin = 8;
    [Export] private int topMargin = 16;

    [ExportGroup("Difficulty Settings")]
    [Export] private int yellowMinScore = 10;
    [Export] private int pinkMinScore = 50;

    [ExportGroup("Game Data")]
    [Export] private PackedScene greenEnemyScene;
    [Export] private PackedScene yellowEnemyScene;
    [Export] private PackedScene pinkEnemyScene;
    [Export] private GameStats gameStats;

    private SpawnerComponent spawnerComponent;
    private Timer greenEnemySpawnTimer;
    private Timer yellowEnemySpawnTimer;
    private Timer pinkEnemySpawnTimer;

    private int screenWidth = (int)ProjectSettings.GetSetting("display/window/size/viewport_width");

    public override void _Ready()
    {
        spawnerComponent = GetNode<SpawnerComponent>("SpawnerComponent");
        greenEnemySpawnTimer = GetNode<Timer>("GreenEnemySpawnTimer");
        yellowEnemySpawnTimer = GetNode<Timer>("YellowEnemySpawnTimer");
        pinkEnemySpawnTimer = GetNode<Timer>("PinkEnemySpawnTimer");

        greenEnemySpawnTimer.Timeout += () => HandleSpawn(greenEnemyScene, greenEnemySpawnTimer);
        yellowEnemySpawnTimer.Timeout += () => HandleSpawn(yellowEnemyScene, yellowEnemySpawnTimer, 5f);
        pinkEnemySpawnTimer.Timeout += () => HandleSpawn(pinkEnemyScene, pinkEnemySpawnTimer, 10f);

        gameStats.ScoreChanged += (int newScore) => enemySpawnLogicEventHandler(newScore);
    }

    // public override void _ExitTree()
    // {
    //     gameStats.ScoreChanged -= enemySpawnLogicEventHandler;
    // }
 
    protected override void Dispose(bool disposing)
    {
        gameStats.ScoreChanged -= enemySpawnLogicEventHandler;
        base.Dispose(disposing);
    }

    private void HandleSpawn(PackedScene enemyScene, Timer timer, float timeOffset = 1f)
    {
        spawnerComponent.Scene = enemyScene;
        spawnerComponent.Spawn(new Vector2(GD.RandRange(margin, screenWidth - margin), -topMargin));

        float spawnRate = timeOffset / (0.5f + (gameStats.Score * 0.01f)); // demonstrated with http://www.desmos.com
        timer.Start(spawnRate + GD.RandRange(0.25f, 0.5f));
    }

    private void enemySpawnLogicEventHandler(int newScore)
    {
        if (newScore > yellowMinScore)
        {
            yellowEnemySpawnTimer.ProcessMode = ProcessModeEnum.Inherit;
        }
        if (newScore > pinkMinScore)
        {
            pinkEnemySpawnTimer.ProcessMode = ProcessModeEnum.Inherit;
        }
    }
}
