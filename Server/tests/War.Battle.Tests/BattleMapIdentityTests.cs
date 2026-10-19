using System.Security.Cryptography;
using System.Text.Json;
using Google.Protobuf;
using War.Client;
using War.Protocol;
using War.Shared;

namespace War.Battle.Tests;

/// <summary>Checks installed scene provenance, source array lookup and the portable grant's owned metadata.</summary>
internal static class BattleMapIdentityTests
{
    private const int ExpectedMapCount = 5;
    private const int FixturePort = 39999;
    private const int SessionKeyBytes = 32;

    internal static void Run()
    {
        DirectoryInfo? server = new(AppContext.BaseDirectory);
        while (server != null && !File.Exists(Path.Combine(server.FullName, "content/recovered-battle-content.json")))
        {
            server = server.Parent;
        }
        if (server?.Parent == null)
        {
            throw new InvalidDataException("The recovered scene provenance is unavailable.");
        }

        using JsonDocument content = JsonDocument.Parse(File.ReadAllBytes(
            Path.Combine(server.FullName, "content/recovered-battle-content.json")));
        JsonElement[] maps = content.RootElement.GetProperty("maps").EnumerateArray().ToArray();
        Require(maps.Length == ExpectedMapCount, "The installed SDK map set must cover the complete source export.");
        VerifySourceMaps(maps, server.Parent.FullName);
        VerifyOwnedGrant(maps[0]);
        Console.WriteLine("PASS: source scene hashes, strict map lookup and owned protobuf map metadata");
    }

    private static void VerifySourceMaps(JsonElement[] maps, string repositoryRoot)
    {
        foreach (JsonElement map in maps)
        {
            string source = map.GetProperty("source").GetString() ?? throw new InvalidDataException("Missing scene path.");
            string revision = map.GetProperty("sha256").GetString() ?? throw new InvalidDataException("Missing scene hash.");
            string identity = Path.GetFileNameWithoutExtension(source);
            string scene = Path.Combine(repositoryRoot, "Clients/ExportedProject", source);
            string actual = Convert.ToHexStringLower(SHA256.HashData(File.ReadAllBytes(scene)));
            Require(actual == revision, "The installed map revision differs from the active recovered scene.");
            Require(InstalledBattleMaps.ResolveIndex(new[] { "unrelated", identity }, identity, revision) == 1,
                "Map selection must retain the recovered array index rather than invent a map ID.");
            Reject(() => InstalledBattleMaps.ResolveIndex(new[] { identity, identity }, identity, revision));
            Reject(() => InstalledBattleMaps.ResolveIndex(new[] { "unrelated" }, identity, revision));
            Reject(() => InstalledBattleMaps.Require(identity, new string('0', revision.Length)));
            Reject(() => BattleMapIdentity.ValidateOptional(identity, ""));
            Reject(() => BattleMapIdentity.ValidateOptional("", revision));
        }
        Reject(() => InstalledBattleMaps.Require("Unknown_Multiplayer", new string('0', 64)));
    }

    private static void VerifyOwnedGrant(JsonElement map)
    {
        string source = map.GetProperty("source").GetString() ?? throw new InvalidDataException("Missing scene path.");
        string mapId = Path.GetFileNameWithoutExtension(source);
        string revision = map.GetProperty("sha256").GetString() ?? throw new InvalidDataException("Missing map revision.");
        var grant = new MatchConnectionGrant
        {
            Host = "127.0.0.1", Port = FixturePort, Ticket = "fixture-ticket", SessionId = 1,
            SessionKey = ByteString.CopyFrom(new byte[SessionKeyBytes]), PlayerId = Guid.NewGuid().ToString("N"),
            MatchId = "m" + Guid.NewGuid().ToString("N"), ManifestHash = new string('a', 64),
            ExpiresUnixSeconds = DateTimeOffset.UtcNow.AddMinutes(1).ToUnixTimeSeconds(),
            MapId = mapId, MapRevision = revision
        };
        MatchConnectionGrant roundTrip = MatchConnectionGrant.Parser.ParseFrom(grant.ToByteArray());
        Require(roundTrip.MapId == mapId && roundTrip.MapRevision == revision, "Protobuf lost scene metadata.");
        using var connection = new MatchConnection(grant);
        grant.MapId = "Unknown_Multiplayer";
        grant.MapRevision = "";
        Require(connection.MapId == mapId && connection.MapRevision == revision,
            "A caller mutated the connection's owned map assignment.");
    }

    private static void Reject(Action action)
    {
        try
        {
            action();
        }
        catch (InvalidDataException)
        {
            return;
        }
        throw new InvalidDataException("Invalid scene authority was accepted.");
    }

    private static void Require(bool condition, string message)
    {
        if (!condition)
        {
            throw new InvalidDataException(message);
        }
    }
}
