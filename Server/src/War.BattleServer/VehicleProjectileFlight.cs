using System.Numerics;

namespace War.BattleServer;

internal sealed record VehicleProjectileImpact(ulong ProjectileId, ulong VehicleId,
    ShotCollision Collision, ulong Tick);

/// <summary>Authoritative fixed-tick flight for a vehicle projectile.</summary>
internal sealed class VehicleProjectileFlight
{
    private readonly ulong id, vehicleId;
    private readonly float speed;
    private readonly Vector3 target;
    private readonly Func<Vector3, Vector3, float, ShotCollision?> trace;
    private ulong tick;
    private Vector3 position;
    internal bool Finished { get; private set; }
    internal ulong VehicleId => vehicleId;
    internal Vector3 Position => position;

    internal VehicleProjectileFlight(ulong id, ulong vehicleId, Vector3 origin, Vector3 target,
        float speed, ulong tick, Func<Vector3, Vector3, float, ShotCollision?> trace)
    {
        if (id == 0 || vehicleId == 0 || !PlayerHitbox.Finite(origin) || !PlayerHitbox.Finite(target) ||
            Vector3.DistanceSquared(origin, target) < 1e-8f || !float.IsFinite(speed) || speed is < .01f or > 10000 ||
            tick > 10_000_000 || trace == null) throw new InvalidDataException("Invalid vehicle projectile launch.");
        this.id = id; this.vehicleId = vehicleId; position = origin; this.target = target;
        this.speed = speed; this.tick = tick; this.trace = trace;
    }

    internal VehicleProjectileImpact? Advance(ulong nextTick)
    {
        if (Finished || nextTick == tick) return null;
        if (nextTick != tick + 1 || nextTick > 10_000_000) throw new InvalidDataException("Vehicle projectile ticks must be contiguous.");
        tick = nextTick;
        var delta = target - position; var distance = delta.Length();
        if (!float.IsFinite(distance)) { Finished = true; throw new InvalidDataException("Invalid vehicle projectile distance."); }
        var step = Math.Min(distance, speed / MatchManifest.TickRate);
        var direction = Vector3.Normalize(delta);
        var hit = trace(position, direction, step + .002f);
        if (hit != null)
        {
            if (!float.IsFinite(hit.Distance) || hit.Distance < 0 || hit.Distance > step + .002f || !PlayerHitbox.Finite(hit.Position))
                throw new InvalidDataException("Vehicle projectile trace returned invalid impact.");
            position = hit.Position; Finished = true; return new(id, vehicleId, hit, tick);
        }
        position += direction * step;
        if (distance <= step + .0001f) { position = target; Finished = true; }
        return null;
    }
}
