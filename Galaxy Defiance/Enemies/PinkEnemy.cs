using System;
using Godot;

public partial class PinkEnemy : Enemy
{
    [Export] private int horizontalSpeed = 20;

    private Node states;
    private TimedStateComponent moveDownState;
    private TimedStateComponent moveSideState;
    private TimedStateComponent pauseState;
    private MoveComponent moveSideComponent;
    private StateComponent fireState;
    private SpawnerComponent projectileSpawnerComponent;

    public override void _Ready()
    {
        base._Ready();

        states = GetParent().GetNode<Node>("States");
        moveDownState = GetParent().GetNode<TimedStateComponent>("%MoveDownState");
        moveSideState = GetParent().GetNode<TimedStateComponent>("%MoveSideState");
        pauseState = GetParent().GetNode<TimedStateComponent>("%PauseState");
        moveSideComponent = GetParent().GetNode<MoveComponent>("%MoveSideComponent");
        fireState = GetParent().GetNode<StateComponent>("%FireState");
        projectileSpawnerComponent = GetParent().GetNode<SpawnerComponent>("%ProjectileSpawnerComponent");

        foreach (StateComponent state in states.GetChildren())
        {
            state.Disable();
        }

        Random rand = new();
        moveSideComponent.velocity.X = (rand.NextDouble() - .5f) < 0 ? -horizontalSpeed : horizontalSpeed;

        moveDownState.StateFinished += () => moveSideState.Enable();
        moveSideState.StateFinished += () => {
            fireState.Enable();
            scaleComponent.TweenScale();
            projectileSpawnerComponent.Spawn(GlobalPosition);
            fireState.Disable();
            fireState.StateFinish();
        };
        fireState.StateFinished += () => pauseState.Enable();
        pauseState.StateFinished += () => moveDownState.Enable();

        moveDownState.Enable();
    }
}
