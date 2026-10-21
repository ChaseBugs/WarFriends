using System.Text.Json;
using System.Text.Json.Serialization;

namespace War.Backend.Legacy.State;

/// <summary>Retains unmodeled metadata when a known subsystem or nested row is rewritten.</summary>
public abstract class LegacyStateObject
{
    [JsonExtensionData]
    public Dictionary<string, JsonElement> Unmodeled { get; set; } = [];
}
