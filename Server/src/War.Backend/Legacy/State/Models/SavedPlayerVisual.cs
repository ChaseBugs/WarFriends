using System.Text.Json.Serialization;
using War.Backend.Legacy.State;

namespace War.Backend.Legacy;

/// <summary>Mirrors <c>CamosManager.SavedPlayerVisual</c>.</summary>
public sealed class SavedPlayerVisual : LegacyStateObject
{
    [JsonPropertyName("bought")]
    public bool Bought { get; set; }

    [JsonPropertyName("showed")]
    public bool Showed { get; set; }

    [JsonPropertyName("expiresOn")]
    public int ExpiresOn { get; set; }

    [JsonPropertyName("borrowed")]
    public bool Borrowed { get; set; }

    [JsonPropertyName("parts")]
    public int Parts { get; set; }

    [JsonPropertyName("notificate")]
    public bool Notificate { get; set; }
}
