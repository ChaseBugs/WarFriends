namespace War.BattleServer;

public sealed partial class MissionAutomaticSpawnState
{
    private const int MaximumTransportCrewSize = 6;
    private readonly Dictionary<ulong, string> _liveBehaviourNames = new();
    private readonly HashSet<ulong> _registeredTransportCrew = new();
    private readonly Dictionary<ulong, ulong> _transportGunnerParents = new();

    internal bool ConfirmTransportGunner(ulong aircraftId, ulong actorId, ulong tick)
    {
        if (!ActiveAt(tick) || actorId == 0 || actorId == aircraftId || seenEntityIds.Contains(actorId) ||
            _transportGunnerParents.ContainsValue(aircraftId) ||
            !_liveBehaviourNames.TryGetValue(aircraftId, out string? behaviour) ||
            !string.Equals(behaviour, "DeployHeli", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }

        // GenerateMachineGunner uses the same prepared Assaulter family as rope crew.
        liveEntities.Add(actorId, FindBehaviour("Assaulter"));
        _liveBehaviourNames.Add(actorId, "Assaulter");
        seenEntityIds.Add(actorId);
        _transportGunnerParents.Add(actorId, aircraftId);
        return true;
    }

    /// <summary>Registers a host-confirmed initial crew without consuming an automatic/event generation slot.</summary>
    internal bool ConfirmInitialTransportCrew(ulong aircraftId, IReadOnlyList<ulong> actorIds, ulong tick)
    {
        ArgumentNullException.ThrowIfNull(actorIds);
        if (!ActiveAt(tick) || actorIds.Count is < 1 or > MaximumTransportCrewSize ||
            _registeredTransportCrew.Contains(aircraftId) ||
            !_liveBehaviourNames.TryGetValue(aircraftId, out string? behaviour) ||
            !string.Equals(behaviour, "DeployHeli", StringComparison.OrdinalIgnoreCase))
        {
            return false;
        }
        var identities = new ulong[actorIds.Count];
        for (int index = 0; index < identities.Length; index++)
        {
            identities[index] = actorIds[index];
        }
        if (identities.Distinct().Count() != identities.Length ||
            identities.Any(id => id == 0 || id == aircraftId || seenEntityIds.Contains(id)))
        {
            return false;
        }
        int behaviourIndex = FindBehaviour("Assaulter");
        foreach (ulong actorId in identities)
        {
            // WaveManager does not increment generatedCount here, but its death callback
            // still increments killedCount when the prepared Assaulter family is listed.
            liveEntities.Add(actorId, behaviourIndex);
            _liveBehaviourNames.Add(actorId, "Assaulter");
            seenEntityIds.Add(actorId);
        }
        _registeredTransportCrew.Add(aircraftId);
        return true;
    }
}
