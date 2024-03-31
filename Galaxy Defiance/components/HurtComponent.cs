using Godot;

public partial class HurtComponent : Node
{
    // Grab the stats so we can alter the health
    [Export] private StatsComponent statsComponent;

    // Grab a hurtbox so we know when we have taken a hiet
    [Export] private HurtboxComponent hurtboxComponent;

    public override void _Ready()
    {
        // Connect the hurt signal on the hurtbox component to an anonymous function that removes health equal to the damage from the hitbox
        hurtboxComponent.Hurt += (HitboxComponent hitbox) => statsComponent.Health -= hitbox.Damage;
    }
}
