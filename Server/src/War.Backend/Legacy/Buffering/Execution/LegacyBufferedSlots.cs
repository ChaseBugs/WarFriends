using System.Text.Json.Nodes;

namespace War.Backend.Legacy.Buffering;

internal static class LegacyBufferedSlots
{
    internal static TSlot Slot<TSlot>(Dictionary<string, TSlot> map, string key) where TSlot : new()
    {
        if (!map.TryGetValue(key, out var slot))
        {
            slot = new TSlot();
            map[key] = slot;
        }
        return slot;
    }

}
