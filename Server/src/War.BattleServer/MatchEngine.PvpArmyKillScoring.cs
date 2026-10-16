using System.Globalization;
using War.Protocol;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    private float PlayerOwnedDeathGameTime =>
        hostTick / (float)MatchManifest.TickRate;

    // Source RecieveKill advances its shared combo before the faction filter.
    private void RecordConfirmedGrenadeArmyDeaths(
        IReadOnlyList<BattleArmyEntityState> beforeBlast, int firstKillIndex,
        string attackerPlayerId, ulong projectileKey)
    {
        if (pvpBonusProgress == null)
        {
            return;
        }

        var deaths = beforeBlast
            .Where(army => !activeArmyEntities.ContainsKey(army.EntityKey))
            .OrderBy(army => army.EntityKey)
            .ToArray();
        var directKills = directArmyKills.Skip(firstKillIndex).ToDictionary(
            kill => kill.EntityKey);
        int attackerFraction = players.Single(player =>
            player.Definition.PlayerId == attackerPlayerId).Definition.Fraction;
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
}
