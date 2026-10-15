using System;
using System.Collections.Generic;
using War.Protocol;
using War.Shared;

namespace War.Client
{
    /// <summary>Checks projectile rows before the SDK publishes them to Unity.</summary>
    internal static class BattleProjectileRowPolicy
    {
        private const int MaximumRows = 128;

        internal static void ValidateSnapshot(MatchSnapshot snapshot)
        {
            if (snapshot == null) throw new ArgumentNullException(nameof(snapshot));
            if (snapshot.Projectiles.Count > MaximumRows)
                throw new InvalidOperationException("Battle host returned too many projectiles.");

            var seenIds = new HashSet<ulong>();
            foreach (var row in snapshot.Projectiles)
            {
                ValidateRow(row);
                if (!seenIds.Add(row.ProjectileId))
                    throw new InvalidOperationException("Battle host repeated a projectile identity.");
            }
        }

        internal static void ValidateScanRows(MatchProjectileBatch batch, ulong afterProjectileId)
        {
            if (batch == null) throw new ArgumentNullException(nameof(batch));
            if (batch.Projectiles.Count > MaximumRows)
                throw new InvalidOperationException("Battle host returned too many projectile scan rows.");

            ulong previousId = afterProjectileId;
            foreach (var row in batch.Projectiles)
            {
                ValidateRow(row);
                if (row.ProjectileId <= previousId)
                    throw new InvalidOperationException("Battle host returned unordered projectile scan rows.");
                previousId = row.ProjectileId;
            }
        }

        private static void ValidateRow(BattleProjectileState row)
        {
            if (row == null || row.ProjectileId == 0 ||
                !Guid.TryParseExact(row.OwnerPlayerId, "N", out _) ||
                row.OwnerPlayerId != row.OwnerPlayerId.ToLowerInvariant() ||
                !SupportedKind(row.Kind) ||
                (IsShotgun(row.Kind) ? !ValidShotgunSource(row.WeaponSourceId) :
                    !string.IsNullOrEmpty(row.WeaponSourceId)) ||
                !ValidArmyIdentity(row) ||
                !FiniteCoordinate(row.X) || !FiniteCoordinate(row.Y) || !FiniteCoordinate(row.Z) ||
                !FiniteCoordinate(row.VelocityX) || !FiniteCoordinate(row.VelocityY) ||
                !FiniteCoordinate(row.VelocityZ))
                throw new InvalidOperationException("Battle host returned invalid projectile row.");
        }

        private static bool SupportedKind(string kind)
        {
            return kind == "grenade" || kind == "grenade-molotov" ||
                kind == "pvp-bonus-grenade" ||
                kind == "card-rocket" || kind == "card-rocket-fake" ||
                kind == "card-grenadier" ||
                kind == "army-bullet" || kind == "army-fake-bullet" ||
                kind == "heavy-turret-bullet" ||
                kind == "helicopter-bullet" || kind == "helicopter-fake-bullet" ||
                kind == "assault-helicopter-bullet" ||
                kind == "assault-helicopter-fake-bullet" ||
                kind == "drone-bullet" || kind == "drone-fake-bullet" ||
                kind == "shotgun-bullet" || kind == "shotgun-fake-bullet";
        }

        private static bool IsShotgun(string kind)
        {
            return kind == "shotgun-bullet" || kind == "shotgun-fake-bullet";
        }

        private static bool ValidArmyIdentity(BattleProjectileState row)
        {
            if (row.Kind != "army-bullet" && row.Kind != "army-fake-bullet")
                return row.ArmyUnitId.Length == 0 && row.ArmySourceCardId.Length == 0 &&
                    !row.ArmyPoison;

            string unitId = row.ArmyUnitId;
            if (!unitId.StartsWith("ID_UNIT-", StringComparison.Ordinal) ||
                unitId.Length == "ID_UNIT-".Length ||
                unitId.Length > 48)
                return false;
            for (int index = "ID_UNIT-".Length; index < unitId.Length; index++)
            {
                char character = unitId[index];
                if (character < 'A' || character > 'Z') return false;
            }
            if (row.ArmyPoison && unitId != "ID_UNIT-COMMANDO") return false;
            if (row.Kind == "army-fake-bullet" &&
                unitId != "ID_UNIT-SHOTGUNNER" && unitId != "ID_UNIT-WARPER")
                return false;
            return row.ArmySourceCardId.Length == 0 ||
                CardUnitSourceIdentity.Matches(row.ArmySourceCardId, unitId);
        }

        private static bool ValidShotgunSource(string value)
        {
            return value == "Google2u.Shotgun_SPAS" || value == "Google2u.Shotgun_Benelli" ||
                value == "Google2u.Shotgun_Saiga" || value == "Google2u.Shotgun_Striker" ||
                value == "Google2u.Shotgun_Blackhand" || value == "Google2u.Shotgun_SawnOff" ||
                value == "Google2u.Shotgun_StrikerElite" || value == "Google2u.Shotgun_AA12" ||
                value == "Google2u.Shotgun_SaigaElite";
        }

        private static bool FiniteCoordinate(float value)
        {
            return !float.IsNaN(value) && !float.IsInfinity(value) && Math.Abs(value) <= 10000f;
        }
    }
}
