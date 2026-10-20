using Google.Protobuf;
using War.Client;
using War.Protocol;

/// <summary>Checks source actor lifetimes through protobuf and the immutable Unity-facing view.</summary>
internal static class CoopCrewWireTests
{
    internal static void Verify(MatchSnapshot snapshot, string playerId, ulong aircraftId)
    {
        MatchSnapshot decoded = MatchSnapshot.Parser.ParseFrom(snapshot.ToByteArray());
        BattleCoopEnemySpawn aircraft = decoded.Coop.EnemySpawns.Single(row => row.EntityId == aircraftId);
        CoopEnemyViewState view = CoopEnemyViewProjection.FromSnapshot(decoded, playerId)
            .Single(row => row.EntityId == aircraftId);
        if (view.CrewActors.Count != aircraft.CrewCount || view.GunnerEntityId != aircraft.GunnerEntityId ||
            !view.CrewActors.Select(actor => actor.EntityId)
                .SequenceEqual(aircraft.CrewActors.Select(actor => actor.EntityId)))
        {
            throw new Exception("Protobuf or portable view changed secondary actor identity.");
        }

        float capturedHealth = view.CrewActors[0].Health;
        aircraft.CrewActors[0].Health = float.NaN;
        if (view.CrewActors[0].Health != capturedHealth)
        {
            throw new Exception("Mutable protobuf changed an already published crew view.");
        }
        RequireRejected(decoded, playerId);
        VerifyMalformed(snapshot, playerId, aircraftId);
    }

    private static void VerifyMalformed(MatchSnapshot snapshot, string playerId, ulong aircraftId)
    {
        MatchSnapshot alias = snapshot.Clone();
        BattleCoopEnemySpawn parent = alias.Coop.EnemySpawns.Single(row => row.EntityId == aircraftId);
        parent.CrewActors[0].EntityId = aircraftId;
        RequireRejected(alias, playerId);
        MatchSnapshot duplicate = snapshot.Clone();
        parent = duplicate.Coop.EnemySpawns.Single(row => row.EntityId == aircraftId);
        parent.GunnerEntityId = parent.CrewActors[0].EntityId;
        RequireRejected(duplicate, playerId);
        MatchSnapshot missing = snapshot.Clone();
        parent = missing.Coop.EnemySpawns.Single(row => row.EntityId == aircraftId);
        parent.CrewActors.RemoveAt(0);
        RequireRejected(missing, playerId);
    }

    private static void RequireRejected(MatchSnapshot snapshot, string playerId)
    {
        try
        {
            CoopEnemyViewProjection.FromSnapshot(snapshot, playerId);
        }
        catch (System.IO.InvalidDataException)
        {
            return;
        }

        throw new Exception("Malformed secondary actor tuple escaped SDK validation.");
    }
}
