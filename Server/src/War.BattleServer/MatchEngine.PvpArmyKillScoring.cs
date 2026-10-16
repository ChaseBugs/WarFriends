using System.Globalization;

namespace War.BattleServer;

public sealed partial class MatchEngine
{
    // Grenade damage can kill several entities. Stage all score rows before
    // publishing them so one exhausted receipt ledger cannot score half a blast.
    private void ScoreConfirmedGrenadeArmyKills(
        int firstKillIndex, string attackerPlayerId, ulong projectileKey)
    {
        if (pvpBonusProgress == null)
        {
            return;
        }

        PvpBonusProgressCoordinator candidate = pvpBonusProgress;
        try
        {
            for (int index = firstKillIndex; index < directArmyKills.Count; index++)
            {
                var kill = directArmyKills[index];
                if (kill.Cause != "player-grenade" || kill.AttackerId != attackerPlayerId)
                {
                    throw new InvalidDataException("Grenade kill score lacks matching host evidence.");
                }

                int flags = PvpArmyKillSkillShotPolicy.ExplosionFlags(
                    armyCatalog ?? throw new InvalidDataException(
                        "Grenade kill lacks a recovered army catalog."),
                    kill.UnitId);
                string receiptId = PvpHitReceiptId("player-grenade-army-kill",
                    projectileKey, kill.EntityKey.ToString(CultureInfo.InvariantCulture));
                candidate = candidate.PrepareConfirmedSkillShotCopy(
                    attackerPlayerId, receiptId, flags, out _);
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
