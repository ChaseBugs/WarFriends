using System.Text.Json.Serialization;
using War.Backend.Legacy.State;

namespace War.Backend.Legacy;

/// <summary>
/// Mirrors <c>CardCraftingManager.CraftData</c>. <c>cards</c> holds exactly the 3 card ids fed into
/// <c>CraftCard</c> while a craft is in progress; <c>isCrafting</c> in the client is
/// <c>cards.Count &gt; 0 &amp;&amp; start &lt; end</c>, reproduced the same way server-side.
/// </summary>
public sealed class CraftData : LegacyStateObject
{
    [JsonPropertyName("cards")]
    public List<string> Cards { get; set; } = [];
    [JsonPropertyName("start")]
    public int Start { get; set; }

    [JsonPropertyName("end")]
    public int End { get; set; }
}
