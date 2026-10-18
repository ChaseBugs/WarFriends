using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Text.Json;

namespace War.Backend.Legacy;

/// <summary>Creates independent source-exact initial blobs before the account's single Mongo insert.</summary>
public static class LegacyInitialLoadout
{
    private const string ResourceName = "War.Backend.RecoveredInitialClientState";
    private const string ReviewedSha256 = "30aa7996ab11f46eac9975d918999cc9b9f62c27e1bd9d4bf4f7cc133a5d2bf3";
    private const string ObservationSha256 = "7e4d56b6dbbfdc832fe65c1a3320c15d4b9c7b80750d7e6ba36f4d45ccb923c5";
    private const string MainSceneSha256 = "5b159bba5105203cd2a771385a110e63820a840d232e6a027b52b577604495ff";
    private static readonly IReadOnlyDictionary<string, string> InitialState = LoadReviewedState();

    /// <summary>Fails startup if the reviewed initial subsystem state is unavailable or invalid.</summary>
    public static void Validate()
    {
        if (InitialState.Count != InitialLoadoutValidation.SubsystemCount)
        {
            throw new InvalidDataException("The initial Client subsystem state is incomplete.");
        }
    }

    /// <summary>Returns a fresh container without sharing writable state between accounts.</summary>
    public static Dictionary<string, string> CreateSerializedState()
    {
        return new Dictionary<string, string>(InitialState, StringComparer.Ordinal);
    }

    private static IReadOnlyDictionary<string, string> LoadReviewedState()
    {
        using Stream input = typeof(LegacyInitialLoadout).Assembly.GetManifestResourceStream(ResourceName)
            ?? throw new InvalidDataException("The initial Client state resource is missing.");
        using var buffer = new MemoryStream();
        input.CopyTo(buffer);
        byte[] bytes = buffer.ToArray();
        if (Convert.ToHexStringLower(SHA256.HashData(bytes)) != ReviewedSha256)
        {
            throw new InvalidDataException("The initial Client state differs from the reviewed source.");
        }
        using JsonDocument document = JsonDocument.Parse(bytes);
        JsonElement root = document.RootElement;
        InitialLoadoutValidation.Exact(root, "schemaVersion", "clientVersion", "observationSha256",
            "mainSceneSha256", "serialized");
        if (root.GetProperty("schemaVersion").GetInt32() != 1 ||
            root.GetProperty("clientVersion").GetString() != "1.4.0" ||
            root.GetProperty("observationSha256").GetString() != ObservationSha256 ||
            root.GetProperty("mainSceneSha256").GetString() != MainSceneSha256)
        {
            throw new InvalidDataException("The initial Client state has unsupported provenance.");
        }
        JsonElement serialized = root.GetProperty("serialized");
        InitialLoadoutValidation.Validate(serialized);
        var result = serialized.EnumerateObject().ToDictionary(
            field => field.Name, field => field.Value.GetRawText(), StringComparer.Ordinal);
        return new ReadOnlyDictionary<string, string>(result);
    }
}
