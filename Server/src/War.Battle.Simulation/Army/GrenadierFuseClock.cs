namespace War.BattleServer;

/// <summary>Matches the recovered single-precision Update countdown and contact-entry reset at thirty Hz.</summary>
internal sealed class GrenadierFuseClock
{
    private readonly float _fuseSeconds;
    private float _remaining;
    private bool _hasContact;

    internal GrenadierFuseClock(float fuseSeconds)
    {
        if (!float.IsFinite(fuseSeconds) || fuseSeconds < 0f || fuseSeconds > 3f)
        {
            throw new InvalidDataException("Grenadier fuse must be a finite source interval from zero through three.");
        }

        _fuseSeconds = fuseSeconds;
    }

    internal void ContactEntered()
    {
        // OnCollisionEnter rearms every new static/destroyable collision, not just the first one.
        _remaining = _fuseSeconds;
        _hasContact = true;
    }

    internal bool AdvanceTick()
    {
        if (!_hasContact)
        {
            return false;
        }

        // Keep a float field and the strict negative comparison. Ceiling seconds loses source frame rounding.
        _remaining -= 1f / MatchManifest.TickRate;
        return _remaining < 0f;
    }
}
