using System.Text.Json;

namespace War.Backend.Legacy.Catalog;

/// <summary>A read-only catalog cell; numeric readers never accept strings or truncate fractions.</summary>
public readonly struct LegacyCatalogValue
{
    private readonly JsonElement _value;

    internal LegacyCatalogValue(JsonElement value)
    {
        _value = value;
    }

    public JsonValueKind GetValueKind() => _value.ValueKind;

    public string ToJsonString() => _value.GetRawText();

    public T GetValue<T>()
    {
        object result = typeof(T) switch
        {
            var type when type == typeof(string) && _value.ValueKind == JsonValueKind.String => _value.GetString()!,
            var type when type == typeof(bool) && _value.ValueKind is JsonValueKind.True or JsonValueKind.False =>
                _value.GetBoolean(),
            var type when type == typeof(long) => ReadInteger(),
            var type when type == typeof(int) => ReadInt32(),
            var type when type == typeof(double) => ReadNumber(),
            _ => throw new InvalidDataException("Catalog cell does not have the requested scalar type.")
        };
        return (T)result;
    }

    private long ReadInteger()
    {
        RequireNumber();
        if (_value.TryGetInt64(out long integer))
        {
            return integer;
        }

        return LegacyCatalogInteger.Read(_value.GetRawText());
    }

    private int ReadInt32()
    {
        long value = ReadInteger();
        if (value is < int.MinValue or > int.MaxValue)
        {
            throw new InvalidDataException("Catalog integer exceeds Int32.");
        }

        return (int)value;
    }

    private double ReadNumber()
    {
        RequireNumber();
        double value = _value.GetDouble();
        if (!double.IsFinite(value))
        {
            throw new InvalidDataException("Catalog number is not finite.");
        }

        if (value == 0)
        {
            string significand = _value.GetRawText().Split(['e', 'E'])[0];
            if (significand.Any(character => character is >= '1' and <= '9'))
            {
                throw new InvalidDataException("Catalog number underflowed the supported numeric representation.");
            }
        }

        return value;
    }

    private void RequireNumber()
    {
        if (_value.ValueKind != JsonValueKind.Number)
        {
            throw new InvalidDataException("Catalog numeric authority is not a JSON number.");
        }
    }
}
