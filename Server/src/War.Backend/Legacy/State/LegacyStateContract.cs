using System.Collections.Concurrent;
using System.Collections.Frozen;
using System.Globalization;
using System.Text.Json;

namespace War.Backend.Legacy.State;

/// <summary>Refuses case aliases and null required model containers while preserving unrelated metadata.</summary>
internal static class LegacyStateContract
{
    private static readonly ConcurrentDictionary<Type, Fields> Contracts = new();

    internal static void Validate(JsonElement value, Type type)
    {
        if (typeof(LegacyStateObject).IsAssignableFrom(type))
        {
            ValidateModel(value, type);
            return;
        }

        if (!type.IsGenericType)
        {
            return;
        }

        Type[] arguments = type.GetGenericArguments();
        if (type.GetGenericTypeDefinition() == typeof(Dictionary<,>))
        {
            RequireKind(value, JsonValueKind.Object);
            foreach (JsonProperty property in value.EnumerateObject())
            {
                if (arguments[0] == typeof(int) && !IsCanonicalIntegerKey(property.Name))
                {
                    throw new JsonException("Legacy integer dictionary key is not canonical.");
                }

                Validate(property.Value, arguments[1]);
            }
        }
        else if (type.GetGenericTypeDefinition() == typeof(List<>))
        {
            RequireKind(value, JsonValueKind.Array);
            foreach (JsonElement item in value.EnumerateArray())
            {
                Validate(item, arguments[0]);
            }
        }
    }

    private static void ValidateModel(JsonElement value, Type type)
    {
        RequireKind(value, JsonValueKind.Object);
        Fields fields = Contracts.GetOrAdd(type, CreateFields);
        foreach (JsonProperty property in value.EnumerateObject())
        {
            if (fields.Types.TryGetValue(property.Name, out Type? fieldType))
            {
                // The recovered BuddyCardData declaration has no initializer for this optional appearance map.
                if (type == typeof(SavedBuddyCardData) && property.Name == "equippedVisuals" &&
                    property.Value.ValueKind == JsonValueKind.Null)
                {
                    continue;
                }

                Validate(property.Value, fieldType);
            }
            else if (fields.IgnoreCase.Contains(property.Name))
            {
                // Newtonsoft ignores property case. Accepting this as metadata would disagree with Client.
                throw new JsonException("Legacy model property uses a noncanonical case alias.");
            }
        }
    }

    private static Fields CreateFields(Type type)
    {
        var types = PlayerState.Options.GetTypeInfo(type).Properties.Where(property => !property.IsExtensionData)
            .ToFrozenDictionary(property => property.Name, property => property.PropertyType, StringComparer.Ordinal);
        return new Fields(types, types.Keys.ToFrozenSet(StringComparer.OrdinalIgnoreCase));
    }

    private static bool IsCanonicalIntegerKey(string name) =>
        int.TryParse(name, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out int key) &&
        key.ToString(CultureInfo.InvariantCulture) == name;

    private static void RequireKind(JsonElement value, JsonValueKind kind)
    {
        if (value.ValueKind != kind)
        {
            throw new JsonException("A required legacy model/container has an incompatible JSON type.");
        }
    }

    private sealed record Fields(FrozenDictionary<string, Type> Types, FrozenSet<string> IgnoreCase);
}
