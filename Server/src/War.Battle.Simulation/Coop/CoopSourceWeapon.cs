using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopSourceWeapon(
    int LevelManagerIndex, int ComponentFileId, int GameObjectFileId,
    string SheetName, int Category, int InventoryIndex, int UnlockLevelIndex);
