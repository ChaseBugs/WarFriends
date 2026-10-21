using System.Numerics;

namespace War.BattleServer;

/// <summary>
/// Recovered Parachute Rigidbody motion before its first scene collision.
/// The Client applies forward force and an alternating tilt torque at each
/// fixed step. Unity moves the Rigidbody center of mass, so the rendered root
/// also shifts as the parachute rotates. Collision response is separate.
/// </summary>
internal sealed class CardParachutePreContactMotion
{
    internal const float FixedSeconds = 0.02f;
    internal const float Gravity = -9.81f;
    internal const float DragFactor = 0.8f;
    internal const float ForwardForce = 23f;
    internal const float AngularDragFactor = 0.99f;
    private const float ParachuteDrag = 5f;
    private static readonly Vector3 LocalCenterOfMass =
        new(-0.03914738f, 0.9514052f, 0.00076295f);

    private readonly Vector3 acceleration;
    private readonly Vector3 forward;
    private readonly float initialSwayPhase;
    private Vector3 centerOfMassPosition;

    internal int FixedFrame { get; private set; }
    internal Vector3 Position { get; private set; }
    internal Vector3 Velocity { get; private set; }
    internal Quaternion Rotation { get; private set; }
    internal Vector3 AngularVelocity { get; private set; }

    internal CardParachutePreContactMotion(Vector3 spawnPosition,
        int ownerFraction, float initialSwayPhase = 0f)
    {
        if (!PlayerHitbox.Finite(spawnPosition) ||
            ownerFraction is not (1 or 2) ||
            !float.IsFinite(initialSwayPhase) ||
            initialSwayPhase < 0f || initialSwayPhase >= 2f)
            throw new InvalidDataException("Parachute needs a source spawn and faction.");
        // The caller can pass (Unity Time.time / 2 + hangingTimeOffset) % 2.
        // The disposable Unity probe starts at phase zero.
        this.initialSwayPhase = initialSwayPhase;
        Position = spawnPosition;
        float direction = ownerFraction == 1 ? 1f : -1f;
        forward = new Vector3(direction, 0f, 0f);
        acceleration = new Vector3(direction * ForwardForce, Gravity, 0f);
        Rotation = Quaternion.CreateFromAxisAngle(Vector3.UnitY,
            direction * MathF.PI / 2f);
        centerOfMassPosition = Position +
            Vector3.Transform(LocalCenterOfMass, Rotation);
    }

    internal void AdvanceFixedStep()
    {
        if (FixedFrame >= 1200)
            throw new InvalidDataException("Parachute free flight exceeded its bound.");
        Velocity = (Velocity + acceleration * FixedSeconds) * DragFactor;
        centerOfMassPosition += Velocity * FixedSeconds;

        // The Client's integer cast changes sway every two seconds. At 50 Hz
        // one fixed step adds 0.01 to its half-time phase.
        int swayInterval = (int)MathF.Floor(initialSwayPhase +
            FixedFrame * FixedSeconds * 0.5f);
        float sway = swayInterval % 2 == 0 ? 1f : -1f;
        Vector3 desiredUp = Vector3.Normalize(Vector3.UnitY +
            0.3f * sway * Vector3.Cross(Vector3.UnitY, forward));
        Vector3 currentUp = Vector3.Transform(Vector3.UnitY, Rotation);
        float dot = Math.Clamp(Vector3.Dot(desiredUp, currentUp), -1f, 1f);
        float tilt = MathF.Acos(dot) / MathF.PI;
        Vector3 targetAngularVelocity = Vector3.Cross(Vector3.UnitY,
            desiredUp) * ParachuteDrag * tilt;
        AngularVelocity = targetAngularVelocity * AngularDragFactor;
        float angle = AngularVelocity.Length() * FixedSeconds;
        if (angle > 0f)
        {
            Quaternion turn = Quaternion.CreateFromAxisAngle(
                Vector3.Normalize(AngularVelocity), angle);
            Rotation = Quaternion.Normalize(turn * Rotation);
        }
        Position = centerOfMassPosition -
            Vector3.Transform(LocalCenterOfMass, Rotation);
        FixedFrame++;
    }
}
