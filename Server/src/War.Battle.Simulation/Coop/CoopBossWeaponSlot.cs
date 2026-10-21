using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopBossWeaponSlot(
    string SourceCategory, int LevelManagerIndex,
    int InventoryIndex, string SheetName);
