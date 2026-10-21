using War.Shared;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private const int FirstObserverFraction = 1;
    private const int LastObserverFraction = 2;
    private readonly Dictionary<(int Slot, int ObserverFraction), MortarIndicatorClock> _mortarSlotClocks = [];
    private readonly Dictionary<int, ulong> _mortarSlotActors = [];

    internal int MortarSlotObserverHistoryCount => _mortarSlotClocks.Count;

    private void BindMortarIndicatorSlot(int slot, ulong actorKey)
    {
        if (_mortarWeaponPool == null || slot < 0 || slot >= _mortarWeaponPool.Capacity ||
            _mortarWeaponPool.SlotFor(actorKey) != slot)
        {
            throw new InvalidDataException("Warning history requires current physical weapon ownership.");
        }
        if (_mortarSlotActors.TryGetValue(slot, out ulong previousActor))
        {
            // OnInstancied hides the old root warning. Its retired actor must not
            // advance the same cached clock again after a successor takes this slot.
            _mortarIndicators.Remove(previousActor);
        }
        for (int fraction = FirstObserverFraction; fraction <= LastObserverFraction; fraction++)
        {
            var key = (slot, fraction);
            if (!_mortarSlotClocks.TryGetValue(key, out MortarIndicatorClock? clock))
            {
                clock = new MortarIndicatorClock();
                _mortarSlotClocks.Add(key, clock);
            }
            clock.HideForReuse();
        }
        _mortarSlotActors[slot] = actorKey;
    }

    private MortarIndicatorClock OpposingMortarSlotClock(ulong actorKey, int ownerFraction)
    {
        int? slot = _mortarWeaponPool?.SlotFor(actorKey);
        if (!slot.HasValue || ownerFraction is < FirstObserverFraction or > LastObserverFraction ||
            !_mortarSlotActors.TryGetValue(slot.Value, out ulong owner) || owner != actorKey ||
            !_mortarSlotClocks.TryGetValue((slot.Value, FirstObserverFraction + LastObserverFraction - ownerFraction),
                out MortarIndicatorClock? clock))
        {
            throw new InvalidDataException("Mortar launch lost its physical slot and opposing observer history.");
        }
        // Allied Shoot/Copy returns before starting the indicator. Only the opposing
        // observer advances this shot; the other observer retains its own hidden startup history.
        return clock;
    }
}
