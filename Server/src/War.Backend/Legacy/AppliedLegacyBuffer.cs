using System.Text.Json.Nodes;
using War.Persistence;

namespace War.Backend.Legacy;

/// <summary>Returns results together with the authoritative account used by subsequent boot projection.</summary>
public sealed record AppliedLegacyBuffer(LegacyPlayerDocument Player, JsonArray Results);
