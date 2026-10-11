using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Linear part of the recovered Parachute Rigidbody before its first scene
/// collision. Unity's fixed step applies forward force and gravity, then
/// multiplies velocity by one minus drag times the fixed time step.
/// Rotation moves the rendered root slightly around its center of mass;
/// landing still needs a compound-collider scene contact solver.
/// </summary>
internal sealed class CardParachutePreContactMotion
{
    internal const float FixedSeconds = 0.02f;
    internal const float Gravity = -9.81f;
    internal const float DragFactor = 0.8f;
    internal const float ForwardForce = 23f;

    private readonly Vector3 acceleration;

    internal int FixedFrame { get; private set; }
    internal Vector3 Position { get; private set; }
    internal Vector3 Velocity { get; private set; }

    internal CardParachutePreContactMotion(Vector3 spawnPosition,
        int ownerFraction)
    {
        if (!PlayerHitbox.Finite(spawnPosition) ||
            ownerFraction is not (1 or 2))
            throw new InvalidDataException("Parachute needs a source spawn and faction.");
        Position = spawnPosition;
        float direction = ownerFraction == 1 ? 1f : -1f;
        acceleration = new Vector3(direction * ForwardForce, Gravity, 0f);
    }

    internal void AdvanceFixedStep()
    {
        if (FixedFrame >= 1200)
            throw new InvalidDataException("Parachute free flight exceeded its bound.");
        Velocity = (Velocity + acceleration * FixedSeconds) * DragFactor;
        Position += Velocity * FixedSeconds;
        FixedFrame++;
    }
}
