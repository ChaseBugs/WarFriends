using System.Globalization;
using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    // The recovered reconnect dialog pauses Unity Time.time. The simulation
    // tick also pauses while the host reconnect deadline continues advancing.
    internal float PlayerOwnedDeathGameTime =>
        tick / (float)MatchManifest.TickRate;

    // Source RecieveKill advances its shared combo before the faction filter.
    private void RecordConfirmedGrenadeArmyDeaths(
        IReadOnlyList<BattleArmyEntityState> beforeBlast,
        (int EventIndex, int KillIndex) firstEvidence,
        string attackerPlayerId, ulong projectileKey)
    {
        if (pvpBonusProgress == null)
        {
            return;
        }

        BattleArmyEntityState[] deaths = ConfirmedBlastArmyDeaths(
            beforeBlast, firstEvidence.EventIndex);
        var directKills = directArmyKills.Skip(firstEvidence.KillIndex).ToDictionary(
            kill => kill.EntityKey);
        int attackerFraction = players.Single(player =>
            player.Definition.PlayerId == attackerPlayerId).Definition.Fraction;
        if (directKills.Count != deaths.Count(army =>
                army.OwnerFraction != attackerFraction))
        {
            throw new InvalidDataException(
                "Grenade direct-kill count differs from its death events.");
        }
        PvpBonusProgressCoordinator candidate = pvpBonusProgress;

        try
        {
            foreach (var army in deaths)
            {
                bool isEnemy = army.OwnerFraction != attackerFraction;
                bool hasDirectKill = directKills.TryGetValue(
                    army.EntityKey, out var directKill);
                if (isEnemy != hasDirectKill ||
                    (hasDirectKill && (directKill.Cause != "player-grenade" ||
                        directKill.AttackerId != attackerPlayerId ||
                        directKill.UnitId != army.UnitId)))
                {
                    throw new InvalidDataException(
                        "Grenade death differs from its direct-kill evidence.");
                }

                int flags = PvpArmyKillSkillShotPolicy.ExplosionFlags(
                    armyCatalog ?? throw new InvalidDataException(
                        "Grenade death lacks a recovered army catalog."),
                    army.UnitId);
                string receiptId = PvpHitReceiptId("player-grenade-army-kill",
                    projectileKey, army.EntityKey.ToString(CultureInfo.InvariantCulture));
                candidate = candidate.PrepareConfirmedPlayerOwnedDeathCopy(
                    attackerPlayerId, receiptId, flags, PlayerOwnedDeathGameTime,
                    isEnemy, out _);
            }
        }
        catch (InvalidOperationException)
        {
            End("pvp-score-backpressure", "", false);
            return;
        }

        pvpBonusProgress = candidate;
    }

    private BattleArmyEntityState[] ConfirmedBlastArmyDeaths(
        IReadOnlyList<BattleArmyEntityState> beforeBlast, int firstEventIndex)
    {
        var beforeByIdentity = beforeBlast.ToDictionary(
            army => (army.OwnerPlayerId, army.LocalEntityId));
        var deaths = new List<BattleArmyEntityState>();

        foreach (MatchEvent deathEvent in events.Skip(firstEventIndex)
                     .Where(row => row.Kind == MatchEventKind.ArmyDied))
        {
            if (!beforeByIdentity.TryGetValue(
                    (deathEvent.TargetId, deathEvent.ArmyEntityId), out var army) ||
                deathEvent.ArmyUnitId != army.UnitId ||
                activeArmyEntities.ContainsKey(army.EntityKey))
            {
                throw new InvalidDataException(
                    "Blast death event differs from its prior army identity.");
            }

            deaths.Add(army);
        }

        int removedCount = beforeBlast.Count(army =>
            !activeArmyEntities.ContainsKey(army.EntityKey));
        if (deaths.Count != removedCount)
        {
            throw new InvalidDataException(
                "Blast removed an army entity without a death event.");
        }

        return deaths.ToArray();
    }
}
