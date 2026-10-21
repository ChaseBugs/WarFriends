namespace War.BattleServer;

/// <summary>
/// Host fixed-tick approximation of PlayerBot's two-second first delay,
/// shooting length, and rest interval. A window permits target selection;
/// it does not itself fire a weapon or cause damage.
/// </summary>
internal sealed class CoopBossAttackCadence
{
    private readonly CoopBossAttackTiming timing;
    private readonly Func<float> randomFraction;

    public bool WindowOpen { get; private set; }
    public ulong NextWindowTick { get; private set; }
    public ulong WindowEndTick { get; private set; }
    public int WindowCount { get; private set; }
    public ulong CurrentTick { get; private set; }

    public CoopBossAttackCadence(CoopBossAttackTiming timing, ulong startTick,
        Func<float>? randomFraction = null)
    {
        this.timing = timing ?? throw new ArgumentNullException(nameof(timing));
        this.randomFraction = randomFraction ?? Random.Shared.NextSingle;
        // PlayerBot.OnAfterGameStarted sets mShotTime to real time + 2 s,
        // and Update starts only once real time is strictly greater.
        NextWindowTick = checked(startTick + 2 * MatchManifest.TickRate + 1);
        CurrentTick = startTick;
    }

    public bool Advance(ulong nextTick)
    {
        if (nextTick < CurrentTick)
            throw new InvalidOperationException("Boss attack clock moved backward.");
        bool changed = false;
        while (WindowOpen ? WindowEndTick <= nextTick : NextWindowTick <= nextTick)
        {
            if (WindowOpen)
            {
                WindowOpen = false;
                NextWindowTick = checked(WindowEndTick +
                    StrictTickDelay(Draw(timing.ShootFrequencyMinSeconds,
                        timing.ShootFrequencyMaxSeconds)));
            }
            else
            {
                WindowOpen = true;
                WindowEndTick = checked(NextWindowTick +
                    StrictTickDelay(Draw(timing.ShootingLengthMinSeconds,
                        timing.ShootingLengthMaxSeconds)));
                WindowCount = checked(WindowCount + 1);
            }
            changed = true;
        }
        CurrentTick = nextTick;
        return changed;
    }

    private float Draw(float minimum, float maximum)
    {
        float fraction = randomFraction();
        if (!float.IsFinite(fraction) || fraction < 0 || fraction >= 1)
            throw new InvalidDataException("Boss attack random draw is outside [0, 1).");
        return minimum + (maximum - minimum) * fraction;
    }

    private static ulong StrictTickDelay(float seconds)
    {
        if (!float.IsFinite(seconds) || seconds < 0 || seconds > 60)
            throw new InvalidDataException("Boss attack interval is outside source bounds.");
        return checked((ulong)Math.Floor(seconds * MatchManifest.TickRate) + 1);
    }
}
