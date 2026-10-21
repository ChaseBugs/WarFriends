using System.Text.Json.Nodes;
using War.Persistence;

namespace War.Backend.Legacy.Accounts;

/// <summary>Reuses source-compatible account and subsystem projections.</summary>
public sealed record LegacyAccountProjection(
    Func<LegacyPlayerDocument, JsonObject> Player,
    Func<LegacyPlayerDocument, JsonObject> PlayerData);
