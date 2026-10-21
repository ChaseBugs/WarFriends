using System;
using System.Collections.Generic;
using War.Protocol;

namespace War.Shared
{
    /// <summary>Source-bound attribution for a host-confirmed mechanical card kill.</summary>
    public static class SabotageKillPresentationPolicy
    {
        private static readonly HashSet<string> mechanicalUnits = new HashSet<string>(StringComparer.Ordinal)
        {
            "ID_UNIT-HUMVEE", "ID_UNIT-BUGGY", "ID_UNIT-TRANSPORTER", "ID_UNIT-TANK",
            "ID_UNIT-HELICOPTER", "ID_UNIT-ASSAULTHELI", "ID_UNIT-DRONE", "ID_UNIT-MECH"
        };

        public static uint BaseFlags(string unitId)
        {
            if (!mechanicalUnits.Contains(unitId))
                throw new ArgumentException("Unsupported Sabotage victim.", nameof(unitId));
            // Recovered SkillShotType values: Kill | OneHitKill | VehicleDestroyed.
            uint flags = 0x1000 | 0x10 | 0x200;
            if (unitId == "ID_UNIT-TANK") flags |= 0x4000;
            return flags;
        }

        public static bool Valid(MatchEvent item)
        {
            if (item == null || item.Kind != MatchEventKind.SabotageKillCredited ||
                item.SabotageKill == null || item.Reason != "sabotage" ||
                !CanonicalId(item.ActorId) || !CanonicalId(item.TargetId) ||
                item.ActorId == item.TargetId)
                return false;
            var kill = item.SabotageKill;
            return mechanicalUnits.Contains(kill.UnitId) &&
                kill.VictimEntityKey >> 32 >= 1 && kill.VictimEntityKey >> 32 <= 2 &&
                (uint)kill.VictimEntityKey > 0 && CanonicalId(kill.RequestId) &&
                kill.BaseSkillShotFlags == BaseFlags(kill.UnitId);
        }

        private static bool CanonicalId(string value)
        {
            return War.Shared.CanonicalGuid.IsCanonical(value);
        }
    }
}
