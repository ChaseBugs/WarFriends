using System.Text.Json.Nodes;
using War.Persistence;

namespace War.Backend.Legacy.Squads;

/// <summary>Reuses the existing Dynamo-shaped projections without coupling rules to HTTP serialization.</summary>
public sealed record LegacySquadProjection(
    Func<LegacyPlayerDocument, JsonObject> Player,
    Func<LegacySquadDocument, JsonObject> Squad);
