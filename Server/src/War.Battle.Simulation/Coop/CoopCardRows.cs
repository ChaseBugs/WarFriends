using System.Security.Cryptography;
using System.Text.Json;

namespace War.BattleServer;

public sealed record CoopCardRows(
    string UnitId, string SheetRow, int MinimumIndex,
    int MaximumIndex, bool HasCardRows);
