using System.Text.Json;
using System.Text.Json.Nodes;

namespace War.Backend;

/// <summary>One structural template boundary shared by eager startup and reusable manifest construction.</summary>
internal static class BattleManifestTemplate
{
    private const int MaximumTemplateBytes = 65536;

    internal static JsonObject Parse(byte[] bytes, IBattleWeaponManifestCatalog weapons)
    {
        if (bytes is not { Length: > 1 and <= MaximumTemplateBytes })
        {
            throw new InvalidDataException("Invalid battle manifest template size.");
        }

        JsonObject template;
        try
        {
            template = JsonNode.Parse(bytes)?.AsObject() ??
                throw new InvalidDataException("Null battle manifest template.");
        }
        catch (Exception error) when (error is JsonException or InvalidOperationException)
        {
            throw new InvalidDataException("Invalid battle manifest template JSON.");
        }
        if (template["Players"] is not JsonArray { Count: 2 } || template.ContainsKey("Allocations"))
        {
            throw new InvalidDataException(
                "Battle manifest template must have two players and no embedded allocation authority.");
        }
        weapons.ValidateTemplate(template);
        return template;
    }
}
