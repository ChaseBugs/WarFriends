using System.Numerics;

namespace War.BattleServer;

internal sealed record BulletFlightDefinition(float Speed, float CheckDistance, bool Fast);
internal sealed record BulletImpact(ulong ProjectileId, string OwnerId, ShotCollision Hit, ulong Tick);
internal sealed class ProjectileTargetException : Exception { }

// Port of real BulletSlow/BulletBase at normal simulation time scale. Fake
// bullets are presentation, and ignoreTimeScale uses a separate source branch
// which is intentionally not accepted here. All inputs come from host authority.
internal sealed class BulletFlight
{
    private enum Stage { Initial, Checking, Tail, Done }
    private readonly BulletFlightDefinition definition;
    private readonly Func<Vector3, Vector3, float, ShotCollision?> trace;
    private readonly ulong id;
    private readonly string owner;
    private Stage stage;
    private Vector3 direction;
    private Vector3 segmentFrom;
    private Vector3 segmentTo;
    private float duration;
    private ulong segmentStart;
    private ulong tick;
    private bool checkAtEnd;
    private ShotCollision? cachedHit;
    public Vector3 Position { get; private set; }
    public bool Finished => stage == Stage.Done;
    internal ulong Id => id;
    internal string OwnerId => owner;

    internal BulletFlight(ulong id, string owner, BulletFlightDefinition definition, Vector3 from, Vector3 to, ulong tick,
        Func<Vector3, Vector3, float, ShotCollision?> trace, Func<string, Vector3>? targetVelocity = null)
    {
        if (!PlayerHitbox.Finite(to) || (PlayerHitbox.Finite(from) && Vector3.DistanceSquared(from,to)<1e-10f))
            throw new ProjectileTargetException();
        if (id == 0 || !Guid.TryParseExact(owner, "N", out _) || owner != owner.ToLowerInvariant() || tick > 10000000 ||
            !PlayerHitbox.Finite(from) ||
            !float.IsFinite(definition.Speed) || definition.Speed is < 0.01f or > 10000 ||
            !float.IsFinite(definition.CheckDistance) || definition.CheckDistance is < 0 or > 50)
            throw new InvalidDataException("Invalid server bullet definition/launch.");
        this.id = id; this.owner = owner; this.definition = definition; this.trace = trace;
        this.tick = tick; Position = from;
        direction = to-from;
        var normalized = Vector3.Normalize(direction);
        if (direction.Length()>50) { to = from+normalized*50; direction = to-from; }
        // Source fast rays are unbounded; our finite scene-coordinate authority
        // uses a 10,000-unit query cap. This cap is reconstruction resource policy.
        var hit = Trace(from+normalized*0.1f, normalized, definition.Fast ? 10000 : Math.Abs(direction.Length()-0.2f));
        if (definition.Fast)
        {
            cachedHit = hit;
            if (hit == null) Animate(from,to+direction,false);
            else if (hit.Static) Animate(from,hit.Position,false);
            else
            {
                var predicted = hit.Position;
                if (hit.PlayerId != null && targetVelocity != null)
                {
                    var velocity = targetVelocity(hit.PlayerId);
                    if (!PlayerHitbox.Finite(velocity)) throw new InvalidDataException("Invalid server target velocity.");
                    predicted += (Vector3.Distance(from,hit.Position)/definition.Speed+0.1f)*velocity;
                }
                if (!PlayerHitbox.Finite(predicted)) throw new InvalidDataException("Invalid predicted impact position.");
                cachedHit = hit with { Position = predicted };
                Animate(from,predicted,false);
            }
        }
        else if (hit?.Static == true) { cachedHit = hit; Animate(from,hit.Position,false); }
        else Animate(from,hit?.Position ?? to,true);
    }

    private ShotCollision? Trace(Vector3 from, Vector3 ray, float range)
    {
        if (range <= 0) return null;
        var hit = trace(from,ray,range);
        if (hit != null && (!float.IsFinite(hit.Distance) || hit.Distance < 0 || hit.Distance>range ||
            !PlayerHitbox.Finite(hit.Position) || Vector3.Distance(hit.Position,from+Vector3.Normalize(ray)*hit.Distance)>0.002f))
            throw new InvalidDataException("Collision resolver returned invalid impact geometry.");
        return hit;
    }

    private void Animate(Vector3 from, Vector3 to, bool check)
    {
        checkAtEnd = check;
        direction = to-from;
        float distance = direction.Length();
        float portion = check && distance>0 ? 1-Math.Clamp(definition.CheckDistance/distance,0,1) : 1;
        BeginSegment(from,from+portion*direction,distance/definition.Speed);
    }
    private void BeginSegment(Vector3 from, Vector3 to, float seconds)
    {
        if (!PlayerHitbox.Finite(from) || !PlayerHitbox.Finite(to) || !float.IsFinite(seconds) || seconds is < 0 or > 1800)
            throw new InvalidDataException("Bullet segment exceeds simulation bounds.");
        segmentFrom = from; segmentTo = to; segmentStart = tick; duration = seconds;
    }
    private BulletImpact? Finish(ShotCollision? hit)
    {
        stage = Stage.Done;
        return hit == null ? null : new(id,owner,hit,tick);
    }
    private ShotCollision? CheckSegment(Vector3 previous)
    {
        float moved = Vector3.Distance(previous,Position);
        if (moved<=0 || direction.LengthSquared()<1e-10f) return null;
        // BulletSlow.CheckHit uses traveled distance + 2*Time.deltaTime.
        return Trace(previous,Vector3.Normalize(direction),moved+2f/MatchManifest.TickRate);
    }
    internal BulletImpact? Advance(ulong nextTick)
    {
        if (nextTick<tick || nextTick>10000000) throw new ArgumentOutOfRangeException(nameof(nextTick));
        if (Finished || nextTick==tick) return null;
        if (nextTick != tick+1) throw new InvalidOperationException("Advance every simulation tick; collision steps cannot be skipped.");
        tick = nextTick;
        var previous = Position;
        double elapsed = (tick-segmentStart)/(double)MatchManifest.TickRate;
        Position = Vector3.Lerp(segmentFrom,segmentTo,duration<=0 ? 1 : (float)Math.Min(1,elapsed/duration));
        bool end = elapsed>=duration;
        if (stage == Stage.Checking)
        {
            var hit = CheckSegment(previous);
            if (hit != null) return Finish(hit);
            if (end)
            {
                stage = Stage.Tail;
                BeginSegment(Position,Position+direction,direction.Length()/definition.Speed);
            }
            return null;
        }
        if (!end) return null;
        if (stage == Stage.Tail) return Finish(null);
        if (!checkAtEnd) return Finish(cachedHit);
        var finalHit = CheckSegment(previous);
        if (finalHit != null) return Finish(finalHit);
        stage = Stage.Checking;
        var unit = direction.LengthSquared()>1e-10f ? Vector3.Normalize(direction) : Vector3.Zero;
        BeginSegment(Position,Position+unit*definition.CheckDistance*2,definition.CheckDistance*3/definition.Speed);
        return null;
    }
}
