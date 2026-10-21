namespace War.BattleServer;

/// <summary>
/// The recovered card makes two possible random draws. The first considers
/// every visible opposing mechanical shootable. A second draw replaces it
/// when a main AI-owned part has existed for more than five seconds.
/// </summary>
internal static class SabotageTargetPolicy
{
    internal sealed record Candidate(
        string SourceType,
        ulong EntityId,
        int PartId,
        int RegistrationOrder,
        int OwnerFraction,
        bool Visible,
        bool Alive,
        bool IsMain,
        bool HasAiOwner,
        ulong SpawnTick,
        float MaximumHealth);

    private static readonly string[] MechanicalTypes =
    [
        "AICar", "AICarBuggy", "AICarTransporter", "Tank",
        "Helicopter", "AssaultHelicopter", "Drone", "Turret", "Mech"
    ];

    // The recovered army family IDs name behaviors, while the Client's
    // GameShootableEntity registry groups entries by their concrete owner type.
    // HeavyTurret is deliberately absent: it is not the source Turret type.
    private static readonly IReadOnlyDictionary<string, string> ArmyOwnerTypes =
        new Dictionary<string, string>(StringComparer.Ordinal)
        {
            ["ID_UNIT-HUMVEE"] = "AICar",
            ["ID_UNIT-BUGGY"] = "AICarBuggy",
            ["ID_UNIT-TRANSPORTER"] = "AICarTransporter",
            ["ID_UNIT-TANK"] = "Tank",
            ["ID_UNIT-HELICOPTER"] = "Helicopter",
            ["ID_UNIT-ASSAULTHELI"] = "AssaultHelicopter",
            ["ID_UNIT-DRONE"] = "Drone",
            ["ID_UNIT-MECH"] = "Mech"
        };

    private const int MaximumCandidates = 1024;
    private const ulong MatureAgeTicks = 5 * MatchManifest.TickRate;

    internal static string? SourceTypeForArmyUnit(string unitId) =>
        ArmyOwnerTypes.TryGetValue(unitId, out string? sourceType)
            ? sourceType : null;

    internal static Candidate? Select(
        IEnumerable<Candidate> sourceCandidates,
        int activatingFraction,
        ulong currentTick,
        Func<int, int> drawIndex)
    {
        if (sourceCandidates == null || drawIndex == null ||
            activatingFraction is not (1 or 2) || currentTick > 10_000_000)
            throw new InvalidDataException("Invalid Sabotage selection input.");

        Candidate[] candidates = sourceCandidates.ToArray();
        if (candidates.Length > MaximumCandidates)
            throw new InvalidDataException("Too many Sabotage candidates.");

        var seen = new HashSet<(string SourceType, ulong EntityId, int PartId)>();
        var registrationSlots = new HashSet<(string SourceType, int Order)>();
        foreach (Candidate candidate in candidates)
        {
            if (candidate == null ||
                !MechanicalTypes.Contains(candidate.SourceType, StringComparer.Ordinal) ||
                candidate.EntityId == 0 || candidate.PartId < 0 ||
                candidate.RegistrationOrder < 0 ||
                candidate.OwnerFraction is not (1 or 2) ||
                candidate.SpawnTick > currentTick ||
                !float.IsFinite(candidate.MaximumHealth) ||
                candidate.MaximumHealth <= 0f ||
                candidate.MaximumHealth > 10_000_000f ||
                !seen.Add((candidate.SourceType, candidate.EntityId,
                    candidate.PartId)) ||
                !registrationSlots.Add((candidate.SourceType,
                    candidate.RegistrationOrder)))
                throw new InvalidDataException("Invalid Sabotage candidate authority.");
        }

        Candidate[] opponents = candidates
            .Where(candidate => candidate.OwnerFraction != activatingFraction &&
                candidate.Visible && candidate.Alive)
            .OrderBy(candidate => Array.IndexOf(MechanicalTypes, candidate.SourceType))
            .ThenBy(candidate => candidate.RegistrationOrder)
            .ToArray();

        if (opponents.Length == 0)
            return null;

        Candidate selected = Draw(opponents, drawIndex);
        Candidate[] matureMainParts = opponents
            .Where(candidate => candidate.HasAiOwner && candidate.IsMain &&
                currentTick - candidate.SpawnTick > MatureAgeTicks)
            .ToArray();
        return matureMainParts.Length == 0
            ? selected
            : Draw(matureMainParts, drawIndex);
    }

    private static Candidate Draw(Candidate[] candidates, Func<int, int> drawIndex)
    {
        int index = drawIndex(candidates.Length);
        if (index < 0 || index >= candidates.Length)
            throw new InvalidDataException("Sabotage random draw escaped its candidate set.");
        return candidates[index];
    }
}
