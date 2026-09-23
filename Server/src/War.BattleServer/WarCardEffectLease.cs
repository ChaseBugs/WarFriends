namespace War.BattleServer;

public sealed class WarCardEffectLease
{
    private readonly ulong expires;
    public ulong ExpiresTick => expires;
    public WarCardEffectLease(ulong startedTick,float durationSeconds)
    {
        if(startedTick>10_000_000||!float.IsFinite(durationSeconds)||durationSeconds<0||durationSeconds>600)
            throw new InvalidDataException("Invalid card effect lifetime.");
        expires=checked(startedTick+(ulong)Math.Ceiling(durationSeconds*MatchManifest.TickRate));
    }
    public bool ActiveAt(ulong tick)=>tick<expires;
}
