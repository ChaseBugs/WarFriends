using System.Numerics;

namespace War.BattleServer;

internal sealed record CardRocketMissileImpact(ulong ProjectileId,
    ulong SoldierEntityKey, Vector3 Position, ShotCollision? Collision,
    ulong Tick, bool IsFake);

/// <summary>
/// Straight flight from the recovered BazookaEnemy prefab and Missile.Update.
/// A completed flight reports impact evidence; it does not award damage.
/// </summary>
internal sealed class CardRocketMissileFlight
{
    internal const float MaximumSpeed = 100f;

    private readonly ulong projectileId;
    private readonly ulong soldierEntityKey;
    private readonly Vector3 start;
    private readonly Vector3 end;
    private readonly float durationSeconds;
    private readonly Func<Vector3, Vector3, float, ShotCollision?> trace;
    private readonly bool isFake;
    private ulong tick;
    private float progress;
    private bool collisionEnabled;

    internal Vector3 Position { get; private set; }
    internal Vector3 TargetPosition => end;
    internal Vector3 Velocity { get; }
    internal bool IsFake => isFake;
    internal bool Finished { get; private set; }

    internal CardRocketMissileFlight(ulong projectileId, ulong soldierEntityKey,
        ArmyCardRocketRuntime missile, Vector3 from, Vector3 to,
        ulong launchTick, bool isFake,
        Func<Vector3, Vector3, float, ShotCollision?> trace)
    {
        if (projectileId == 0 || soldierEntityKey == 0 || missile == null ||
            !float.IsFinite(missile.Speed) || missile.Speed <= 0f || missile.Speed > MaximumSpeed ||
            !float.IsFinite(missile.DirectDamage) || missile.DirectDamage < 0 ||
            !float.IsFinite(missile.ExplosionDamage) || missile.ExplosionDamage < 0 ||
            !float.IsFinite(missile.PlayerBehindShieldRatio) ||
            missile.PlayerBehindShieldRatio is < 0 or > 1 ||
            !PlayerHitbox.Finite(from) || !PlayerHitbox.Finite(to) ||
            Vector3.DistanceSquared(from, to) < 1e-10f ||
            launchTick > 10_000_000 || trace == null)
            throw new InvalidDataException("Card Rocket has invalid launch authority.");

        this.projectileId = projectileId;
        this.soldierEntityKey = soldierEntityKey;
        this.trace = trace;
        this.isFake = isFake;
        tick = launchTick;
        start = from;

        // Missile.Fire caps the direction to 50 units before AnimateShot.
        Vector3 displacement = to - from;
        end = displacement.Length() > 50f
            ? from + Vector3.Normalize(displacement) * 50f : to;
        durationSeconds = Vector3.Distance(start, end) / missile.Speed;
        if (!float.IsFinite(durationSeconds) || durationSeconds <= 0 ||
            durationSeconds > 1800)
            throw new InvalidDataException("Card Rocket has invalid flight duration.");
        Velocity = Vector3.Normalize(end - start) * missile.Speed;

        // BazookaEnemy MissileSetup has stopTime = 0 and curvedTrajectory = 0.
        progress = 0;
        Position = from;
    }

    internal CardRocketMissileImpact? Advance(ulong nextTick)
    {
        if (Finished || nextTick != tick + 1 || nextTick > 10_000_000)
            throw new InvalidOperationException(
                "Advance each Rocket missile exactly once per tick.");

        tick = nextTick;
        Vector3 previousPosition = Position;
        progress += 1f / MatchManifest.TickRate / durationSeconds;
        Position = start + (end - start) * Math.Max(progress, 0);
        if (!PlayerHitbox.Finite(Position))
            throw new InvalidDataException("Card Rocket missile left scene bounds.");

        if (collisionEnabled)
        {
            Vector3 movement = Position - previousPosition;
            float distance = movement.Length();
            if (distance > 0)
            {
                float rayLength = distance + 2f / MatchManifest.TickRate;
                ShotCollision? hit = trace(previousPosition, movement, rayLength);
                if (hit != null)
                {
                    if (!float.IsFinite(hit.Distance) || hit.Distance < 0 ||
                        hit.Distance > rayLength ||
                        !PlayerHitbox.Finite(hit.Position))
                        throw new InvalidDataException(
                            "Card Rocket received an invalid collision.");
                    Position = hit.Position;
                    Finished = true;
                    return new CardRocketMissileImpact(projectileId,
                        soldierEntityKey, Position, hit, tick, isFake);
                }
            }
        }
        else if (Vector3.Distance(start, Position) > .5f)
        {
            collisionEnabled = true;
        }

        // Recovered straight Missile.Update expires after three flight lengths.
        if (progress > 3f)
        {
            Finished = true;
            return new CardRocketMissileImpact(projectileId,
                soldierEntityKey, Position, null, tick, isFake);
        }
        return null;
    }
}
