using Godot;

public partial class HurtboxComponent : Area2D
{
    // Create the is_invincible boolean
    private bool isInvincible = false;

    public bool IsInvincible
    {
        get
        {
            return isInvincible;
        }
        // Here we create an inline setter so we can disable and enable collision shapes on
        // the hurtbox when is_invincible is changed.
        set
        {
            isInvincible = value;
            // Disable any collisions shapes on this hurtbox when it is invincible
            // And reenable them when it isn't invincible
            foreach (Node child in GetChildren())
            {
                if (child is not CollisionShape2D && child is not CollisionPolygon2D) continue;
                // Use call deferred to make sure this doesn't happen in the middle of the physics process
                child.SetDeferred("disabled", isInvincible);
            }
        }
    }

    // Create a signal for when this hurtbox is hit by a hitbox
    [Signal]
    public delegate void HurtEventHandler(HitboxComponent hitbox);
}
