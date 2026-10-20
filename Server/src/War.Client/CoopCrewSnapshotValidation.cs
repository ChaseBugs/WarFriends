using System;
using System.Collections.Generic;
using System.IO;
using War.Protocol;

namespace War.Client
{
    internal static class CoopCrewSnapshotValidation
    {
        private const int MaximumSeats = 6;
        private const float MaximumHealth = 10_000_000;

        internal static void Validate(MatchSnapshot snapshot)
        {
            var identities = new HashSet<ulong>();
            foreach (BattleCoopEnemySpawn enemy in snapshot.Coop.EnemySpawns)
            {
                if (!identities.Add(enemy.EntityId))
                {
                    throw new InvalidDataException("Ordinary enemy identities are duplicated.");
                }
            }

            foreach (BattleCoopEnemySpawn enemy in snapshot.Coop.EnemySpawns)
            {
                bool isTransport = string.Equals(enemy.Behaviour, "DeployHeli", StringComparison.OrdinalIgnoreCase);
                if (!isTransport && (enemy.CrewActors.Count != 0 || enemy.GunnerEntityId != 0))
                {
                    throw new InvalidDataException("Secondary crew identities require a transport aircraft.");
                }
                if (isTransport)
                {
                    ValidateCrew(enemy, snapshot.ServerTick, identities);
                    ValidateGunner(enemy, snapshot.ServerTick, identities);
                }
            }
        }

        private static void ValidateCrew(BattleCoopEnemySpawn parent, ulong serverTick, HashSet<ulong> identities)
        {
            if (parent.CrewCount > MaximumSeats || parent.CrewActors.Count != parent.CrewCount)
            {
                throw new InvalidDataException("Initial crew roster does not match source seat count.");
            }

            var points = new HashSet<int>();
            ulong previousId = parent.EntityId;
            for (int slot = 0; slot < parent.CrewActors.Count; slot++)
            {
                BattleCoopCrewActor actor = parent.CrewActors[slot];
                if (actor.Slot != slot || actor.EntityId != previousId + 1 || actor.EntityId == ulong.MaxValue ||
                    !identities.Add(actor.EntityId) || actor.PointComponentFileId <= 0 ||
                    !points.Add(actor.PointComponentFileId) || actor.SpawnTick != parent.SpawnTick ||
                    !IsFinite(actor.MaxHealth) || actor.MaxHealth <= 0 || actor.MaxHealth > MaximumHealth ||
                    !IsFinite(actor.Health) || actor.Health < 0 || actor.Health > actor.MaxHealth ||
                    (actor.Health == 0) != (actor.DeathTick != 0) ||
                    (actor.DeathTick != 0 && (actor.DeathTick < actor.SpawnTick || actor.DeathTick > serverTick)) ||
                    (parent.DeathTick != 0 && actor.IsAttached &&
                        (actor.Health != 0 || actor.DeathTick > parent.DeathTick)))
                {
                    throw new InvalidDataException("Crew identity, seat or source lifetime is inconsistent.");
                }

                previousId = actor.EntityId;
            }
        }

        private static void ValidateGunner(BattleCoopEnemySpawn parent, ulong serverTick, HashSet<ulong> identities)
        {
            if (parent.GunnerMaxHealth == 0)
            {
                if (parent.GunnerEntityId != 0 || parent.GunnerHealth != 0 || parent.GunnerSpawnTick != 0 ||
                    parent.GunnerRespawnTick != 0 || parent.GunnerPointComponentFileId != 0 || parent.CrewCount != 0)
                {
                    throw new InvalidDataException("Absent gunner authority must have an empty lifetime tuple.");
                }
                return;
            }

            ulong lastCrewId = parent.CrewActors.Count == 0
                ? parent.EntityId : parent.CrewActors[parent.CrewActors.Count - 1].EntityId;
            foreach (BattleCoopCrewActor actor in parent.CrewActors)
            {
                if (actor.PointComponentFileId == parent.GunnerPointComponentFileId)
                {
                    throw new InvalidDataException("Turret and rope crew cannot occupy the same source seat.");
                }
            }

            if (parent.GunnerEntityId <= lastCrewId || parent.GunnerEntityId == ulong.MaxValue ||
                (parent.GunnerSpawnTick == parent.SpawnTick && parent.GunnerEntityId != lastCrewId + 1) ||
                !identities.Add(parent.GunnerEntityId) || parent.GunnerPointComponentFileId <= 0 ||
                !IsFinite(parent.GunnerMaxHealth) || parent.GunnerMaxHealth <= 0 ||
                parent.GunnerMaxHealth > MaximumHealth || !IsFinite(parent.GunnerHealth) ||
                parent.GunnerHealth < 0 || parent.GunnerHealth > parent.GunnerMaxHealth ||
                parent.GunnerSpawnTick < parent.SpawnTick || parent.GunnerSpawnTick > serverTick ||
                (parent.GunnerHealth > 0 && parent.GunnerRespawnTick != 0) ||
                (parent.DeathTick != 0 && (parent.GunnerHealth != 0 || parent.GunnerRespawnTick != 0)) ||
                (parent.DeathTick == 0 && parent.GunnerHealth == 0 && parent.GunnerRespawnTick <= serverTick))
            {
                throw new InvalidDataException("Turret identity or source lifetime is inconsistent.");
            }
        }

        private static bool IsFinite(float value)
        {
            return !float.IsNaN(value) && !float.IsInfinity(value);
        }
    }
}
