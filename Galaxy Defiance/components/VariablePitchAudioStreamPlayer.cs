using Godot;

public partial class VariablePitchAudioStreamPlayer : AudioStreamPlayer
{
    // This custom node is used to easily play a sound with a variable pitch

    // Export the minimum and maximum pitch amounts
    [Export] private float pitchMin = 0.6f;
    [Export] private float pitchMax = 1.2f;

    // Allow the node to automatically play the sound with the pitch variance
    [Export] private bool autoPlayWithVariance = false;

    public override void _Ready()
    {
        // If auto play with variance is on, call the function to play the sound in the ready function
        if (autoPlayWithVariance)
        {
            PlayWithVariance(0.0f);
        }
    }

    // This is the function for playing the sound using a variance in the pitch
    public void PlayWithVariance(float fromPosition = 0f)
    {
        // Set the pitch scale before playing the sound (picking a random amount between the minimum and maximum)
        PitchScale = (float)GD.RandRange(pitchMin, pitchMax);
        Play(fromPosition);
    }
}
