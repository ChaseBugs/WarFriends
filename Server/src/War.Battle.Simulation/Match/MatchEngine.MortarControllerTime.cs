namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private readonly Dictionary<ulong, MortarTimeBinding> _mortarControllerTimes = [];
    private readonly Dictionary<ulong, float> _mortarRelocationTimes = [];

    private void InitializeMortarControllerTime(ulong entityKey)
    {
        // BeforeInstancied resets mTime from Time.time. The self-hosted epoch is authoritative match time;
        // the first update follows spawn, like the existing navigation's first eligible tick.
        var clock = new MortarControllerClock(tick / (float)MatchManifest.TickRate);
        _mortarControllerTimes.Add(entityKey, new MortarTimeBinding(tick, clock));
    }

    private void AdvanceMortarControllerTimes()
    {
        foreach (MortarTimeBinding binding in _mortarControllerTimes.Values)
        {
            if (tick > binding.SpawnTick)
            {
                binding.Clock.Advance();
            }
        }
    }

    private sealed record MortarTimeBinding(ulong SpawnTick, MortarControllerClock Clock);
}
