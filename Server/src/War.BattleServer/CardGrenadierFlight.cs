using System.Numerics;

namespace War.BattleServer;

internal sealed record CardGrenadierExplosion(ulong ProjectileId,
    ulong SoldierEntityKey, Vector3 Position, ulong Tick,
    bool ShotTriggered = false);

/// <summary>
/// GrenadeAmmoBase starts its fuse on the first static or destroyable contact.
/// The body keeps moving with higher drag until the fuse expires.
/// </summary>
internal sealed class CardGrenadierFlight
{
    private const float Gravity = 9.81f;
    private const float AirDrag = .2f;
    private const float ContactDrag = 6f;
    // GrenadeEnemy's capsule radius .05486127 sits under a scale-two child.
    private const float ColliderRadius = .10972254f;
    // GrenadeAmmoEnemy.prefab's DestroyableObject starts at 1000 HP.
    internal const float SourceShotHealth = 1000f;

    private readonly ulong projectileId;
    private readonly ulong soldierEntityKey;
    private readonly Func<Vector3, Vector3, float, ShotCollision?> trace;
    private readonly ulong fuseTicks;
    private readonly ulong expiryTick;
    private ulong tick;
    private ulong? firstContactTick;
    private bool collisionEnabled;

    internal Vector3 Position { get; private set; }
    internal Vector3 Velocity { get; private set; }
    internal bool Finished { get; private set; }
    internal float ShotHealth { get; private set; } = SourceShotHealth;
    internal ulong? FirstContactTick => firstContactTick;
    internal ulong CurrentTick => tick;
    internal bool ShotColliderEnabled => collisionEnabled;

    internal CardGrenadierFlight(ulong projectileId, ulong soldierEntityKey,
        ArmyCardGrenadierRuntime setup, Vector3 muzzlePosition,
        Vector3 launchVelocity, ulong launchTick,
        Func<Vector3, Vector3, float, ShotCollision?> trace)
    {
        if (projectileId == 0 || soldierEntityKey == 0 || setup == null ||
            !float.IsFinite(setup.FuseSeconds) || setup.FuseSeconds < 0f || setup.FuseSeconds > 3f ||
            !PlayerHitbox.Finite(muzzlePosition) ||
            !PlayerHitbox.Finite(launchVelocity) ||
            launchVelocity.LengthSquared() < 1e-10f ||
            launchTick > 10_000_000 || trace == null)
            throw new InvalidDataException("Invalid card Grenadier launch.");

        this.projectileId = projectileId;
        this.soldierEntityKey = soldierEntityKey;
        this.trace = trace;
        tick = launchTick;
        Position = muzzlePosition;
        Velocity = launchVelocity;
        fuseTicks = (ulong)MathF.Ceiling(setup.FuseSeconds * MatchManifest.TickRate);
        expiryTick = checked(launchTick + 15u * MatchManifest.TickRate);
    }

    internal CardGrenadierExplosion? Advance(ulong nextTick)
    {
        if (Finished || nextTick != tick + 1 || nextTick > 10_000_000)
            throw new InvalidOperationException(
                "Advance each card grenade exactly once per tick.");

        tick = nextTick;
        float secondsPerTick = 1f / MatchManifest.TickRate;
        Vector3 previousPosition = Position;
        Velocity += -Gravity * secondsPerTick * Vector3.UnitY;
        float drag = firstContactTick.HasValue ? ContactDrag : AirDrag;
        Velocity /= 1f + drag * secondsPerTick;
        Position += Velocity * secondsPerTick;
        if (!PlayerHitbox.Finite(Position) || !PlayerHitbox.Finite(Velocity))
            throw new InvalidDataException("Card grenade escaped finite flight authority.");

        if (collisionEnabled)
        {
            Vector3 movement = Position - previousPosition;
            float distance = movement.Length();
            if (distance > 0f)
            {
                ShotCollision? hit = trace(previousPosition, movement,
                    distance + .001f);
                if (hit != null)
                    ApplyContact(hit, movement, distance);
            }
        }
        if (Velocity.Y < 0f)
            collisionEnabled = true;

        if (firstContactTick.HasValue &&
            tick >= firstContactTick.Value + fuseTicks)
        {
            Finished = true;
            return new CardGrenadierExplosion(projectileId,
                soldierEntityKey, Position, tick);
        }
        if (tick >= expiryTick)
            throw new InvalidDataException(
                "Card grenade never reached a source contact surface.");
        return null;
    }

    internal CardGrenadierExplosion? ApplyShot(float damage, ulong impactTick)
    {
        if (Finished || !collisionEnabled || impactTick != tick ||
            !float.IsFinite(damage) ||
            damage <= 0f || damage > 10_000_000f)
            throw new InvalidDataException("Invalid card grenade shot damage.");
        ShotHealth = Math.Max(0f, ShotHealth - damage);
        if (ShotHealth > 0f)
            return null;

        // GrenadeAmmoEnemy.OnDeath calls Explode immediately. A lethal shot
        // does not wait for the first ground contact or the remaining fuse.
        Finished = true;
        return new CardGrenadierExplosion(projectileId, soldierEntityKey,
            Position, impactTick, ShotTriggered: true);
    }

    private void ApplyContact(ShotCollision hit, Vector3 movement,
        float distance)
    {
        if (!float.IsFinite(hit.Distance) || hit.Distance < 0f ||
            hit.Distance > distance + .001f ||
            !PlayerHitbox.Finite(hit.Position))
            throw new InvalidDataException("Invalid card grenade collision.");
        if (!hit.Static && !hit.SourceDestroyable)
            return;

        Vector3 normal = hit.SurfaceNormal ?? -Vector3.Normalize(movement);
        if (!PlayerHitbox.Finite(normal) ||
            Math.Abs(normal.LengthSquared() - 1f) > .001f)
            throw new InvalidDataException("Invalid card grenade contact normal.");
        if (!firstContactTick.HasValue)
            firstContactTick = tick;

        // The prefab has no PhysicMaterial, so no configured restitution.
        // Remove velocity entering the surface; retain tangent travel while
        // the recovered contact drag slows the body during its fuse.
        float enteringSpeed = Vector3.Dot(Velocity, normal);
        if (enteringSpeed < 0f)
            Velocity -= enteringSpeed * normal;
        Position = hit.Position + normal * ColliderRadius;
        if (!PlayerHitbox.Finite(Position))
            throw new InvalidDataException("Card grenade contact left scene bounds.");
    }
}
