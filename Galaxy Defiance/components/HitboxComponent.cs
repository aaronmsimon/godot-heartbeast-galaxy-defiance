using Godot;

public partial class HitboxComponent : Area2D
{
    // Export the damage amount this hitbox deals
    [Export] private float damage = 1f;

    // Create a signal for when the hitbox hits a hurtbox
    [Signal]
    public delegate void HitHurtboxEventHandler(HurtboxComponent hurtbox);

    public override void _Ready()
    {
        // Connect on area entered to our hurtbox entered function
        // AreaEntered += OnHurtboxEntered;
    }

    public void OnHurtboxEntered(HurtboxComponent hurtbox)
    {
        // Make sure the area we are overlapping is a hurtbox
        if (hurtbox is not HurtboxComponent) return;
        // Make sure the hurtbox isn't invincible
        if (hurtbox.IsInvincible) return;
        // Signal out that we hit a hurtbox (this is useful for destroying projectiles when they hit something)
        EmitSignal(SignalName.HitHurtbox, hurtbox);
        // Have the hurtbox signal out that it was hit
        EmitSignal(SignalName.Hurt);
        // hurtbox.hurt.emit(self)
    }
}
