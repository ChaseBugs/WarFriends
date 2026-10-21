using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;

namespace War.Backend.Legacy.Cards;

/// <summary>Retains the reviewed card-pool rule that unknown inventory authority requires a migration first.</summary>
internal static class LegacyCardStateOptions
{
    internal static JsonSerializerOptions Create()
    {
        var resolver = new DefaultJsonTypeInfoResolver();
        resolver.Modifiers.Add(contract =>
        {
            for (int index = contract.Properties.Count - 1; index >= 0; index--)
            {
                if (contract.Properties[index].IsExtensionData)
                {
                    contract.Properties.RemoveAt(index);
                }
            }
        });
        var options = new JsonSerializerOptions
        {
            TypeInfoResolver = resolver,
            UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow
        };
        options.MakeReadOnly();
        return options;
    }
}
