using System;
using Godot;

public partial class YellowEnemy : Enemy
{
    [Export] private int horizontalSpeed = 20;

    public override void _Ready()
    {
        base._Ready();

        Random rand = new();
        moveComponent.velocity.X = (rand.NextDouble() - .5f) < 0 ? -horizontalSpeed : horizontalSpeed;
    }
}
