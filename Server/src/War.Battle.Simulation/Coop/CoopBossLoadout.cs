using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed class CoopBossLoadout
{
    public int MissionIndex { get; }
    public int Level { get; }
    public IReadOnlyList<CoopBossWeaponSlot> Slots { get; }

    internal CoopBossLoadout(int missionIndex, int level, CoopBossWeaponSlot[] slots)
    {
        MissionIndex = missionIndex;
        Level = level;
        Slots = new ReadOnlyCollection<CoopBossWeaponSlot>(slots);
    }
}
