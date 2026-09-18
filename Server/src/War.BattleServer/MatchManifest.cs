using System.Security.Cryptography;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace War.BattleServer;

// Operator/allocator input, NEVER a client command. Only the supported prototype
// mode is accepted until maps/catalogs/hit simulation have authoritative support.
public sealed record WeaponManifest(string SourceId, int ClipSize, int ReserveAmmo, double CadenceSeconds, double ReloadSeconds);
public sealed record ParticipantManifest(string PlayerId, WeaponManifest Weapon, int Fraction = 0, int StartCover = -1, float MovementSpeed = 0);
public sealed record MatchManifest(string MatchId, string ServerId, string MapId, string MapRevision,
    string CatalogRevision, string Mode, int AdmissionSeconds, int DurationSeconds,
    int IdleSeconds, ParticipantManifest[] Players)
{
    public const int TickRate = 30;
    public const string PrototypeMode = "unscored-weapon-prototype";
    private static readonly JsonSerializerOptions Json = new() { UnmappedMemberHandling = JsonUnmappedMemberHandling.Disallow };

    public static MatchManifest Read(string path)
    {
        using var stream = File.OpenRead(path);
        if (stream.Length is < 2 or > 65536) throw new InvalidDataException("Match manifest must be 2..65536 bytes.");
        return Validate(JsonSerializer.Deserialize<MatchManifest>(stream, Json) ?? throw new InvalidDataException("Null manifest."));
    }

    public static MatchManifest Validate(MatchManifest m)
    {
        static bool Id(string? x) => x != null && Regex.IsMatch(x, @"\A[a-zA-Z0-9_-]{1,64}\z");
        static bool Hash(string? x) => x != null && Regex.IsMatch(x, @"\A[0-9a-f]{64}\z");
        if (!Id(m.MatchId) || !Id(m.ServerId) || !Id(m.MapId) || !Hash(m.MapRevision) || !Hash(m.CatalogRevision) ||
            m.Mode != PrototypeMode || m.AdmissionSeconds is < 5 or > 120 || m.DurationSeconds is < 5 or > 1800 ||
            m.IdleSeconds is < 2 or > 120 || m.Players == null || m.Players.Length != 2)
            throw new InvalidDataException("Invalid/unsupported match manifest.");
        var ids = new HashSet<string>(StringComparer.Ordinal);
        foreach (var p in m.Players)
        {
            if (p == null || !Guid.TryParseExact(p.PlayerId, "N", out _) || p.PlayerId != p.PlayerId.ToLowerInvariant() || !ids.Add(p.PlayerId))
                throw new InvalidDataException("Exactly two distinct canonical player IDs are required.");
            var w = p.Weapon;
            if (p.Fraction is < 0 or > 2 || p.StartCover is < -1 or > 7 || !float.IsFinite(p.MovementSpeed) || p.MovementSpeed is < 0 or > 20)
                throw new InvalidDataException("Invalid movement manifest.");
            if (w == null || !Id(w.SourceId) || w.ClipSize is < 1 or > 1000 || w.ReserveAmmo is < 0 or > 100000 ||
                !double.IsFinite(w.CadenceSeconds) || w.CadenceSeconds is < 0.01 or > 60 ||
                !double.IsFinite(w.ReloadSeconds) || w.ReloadSeconds is < 0.01 or > 120)
                throw new InvalidDataException("Invalid basic reloadable weapon definition.");
        }
        // Detach mutable caller array. Nested records are immutable scalar values.
        return m with { Players = m.Players.ToArray() };
    }

    public string Digest() => Convert.ToHexStringLower(SHA256.HashData(JsonSerializer.SerializeToUtf8Bytes(this, Json)));
}
