using System;
using System.Collections.Generic;
using System.IO;
using War.Protocol;

namespace War.Client
{
    /// <summary>Validates a complete common enemy view before the Client creates or updates any visuals.</summary>
    public static class CoopEnemyViewProjection
    {
        private const ulong FirstEnemyId = 1;
        private const float CardMaximumLevel = 25f;
        private const double RotationTolerance = 0.001;
        // Mission.behavioursDictionary resolves source names without changing their preserved spelling.
        private static readonly HashSet<string> Behaviours = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
        {
            "Assaulter", "Sniper", "Grenadier", "Shotgunner", "Parachuter", "Minigunner",
            "RocketLauncher", "Swat", "Engineer", "Drone", "Helicopter", "DeployHeli", "Humvee",
            "Buggy", "Tank", "MachineGunner", "SciFi", "Transporter", "Commando", "Flamethrower",
            "Gunslinger", "Warper", "Mortar", "Mech"
        };

        /// <summary>Returns an isolated read-only view; rejected rows publish no partial roster.</summary>
        public static IReadOnlyList<CoopEnemyViewState> FromSnapshot(MatchSnapshot snapshot, string localPlayerId)
        {
            CoopOutcomeProjection.ForPlayer(snapshot, localPlayerId);
            if (string.IsNullOrEmpty(snapshot.MatchId) || string.IsNullOrEmpty(snapshot.ManifestHash) ||
                (!snapshot.Coop.Started && snapshot.Coop.EnemySpawns.Count != 0))
            {
                throw new InvalidDataException("Enemy presentation requires an identified, started source mission.");
            }

            var views = new List<CoopEnemyViewState>(snapshot.Coop.EnemySpawns.Count);
            ulong expectedId = FirstEnemyId;
            foreach (BattleCoopEnemySpawn enemy in snapshot.Coop.EnemySpawns)
            {
                ValidateIdentity(enemy, expectedId, snapshot);
                ValidateVitality(enemy, snapshot.ServerTick);
                ValidatePose(enemy, snapshot.ServerTick);
                views.Add(new CoopEnemyViewState(enemy));
                expectedId++;
            }

            return views.AsReadOnly();
        }

        private static void ValidateIdentity(BattleCoopEnemySpawn enemy, ulong expectedId, MatchSnapshot snapshot)
        {
            if (enemy.EntityId != expectedId || !Behaviours.Contains(enemy.Behaviour) || enemy.Level < 0 ||
                enemy.SpawnComponentFileId <= 0 || enemy.SpawnTick < snapshot.StartTick ||
                enemy.SpawnTick > snapshot.ServerTick || enemy.SpawnTick >= snapshot.Coop.DeadlineTick)
            {
                throw new InvalidDataException("Enemy identity or source spawn time is inconsistent.");
            }

            float expectedProgress = enemy.CardUnit ? Math.Min(1f, enemy.Level / CardMaximumLevel) : 0f;
            if (!IsFinite(enemy.CardProgress) || enemy.CardProgress != expectedProgress ||
                (enemy.CardUnit && !enemy.TimedEvent))
            {
                throw new InvalidDataException("Enemy card interpolation does not match its source spawn lane.");
            }
        }

        private static void ValidateVitality(BattleCoopEnemySpawn enemy, ulong serverTick)
        {
            if (!IsFinite(enemy.MaxHealth) || !IsFinite(enemy.Health) || enemy.MaxHealth <= 0f ||
                enemy.Health < 0f || enemy.Health > enemy.MaxHealth ||
                ((enemy.Health == 0f) != (enemy.DeathTick != 0)) ||
                (enemy.DeathTick != 0 && (enemy.DeathTick < enemy.SpawnTick || enemy.DeathTick > serverTick)))
            {
                throw new InvalidDataException("Enemy body vitality does not match its confirmed death boundary.");
            }
        }

        private static void ValidatePose(BattleCoopEnemySpawn enemy, ulong serverTick)
        {
            if (!IsFinite(enemy.X) || !IsFinite(enemy.Y) || !IsFinite(enemy.Z) ||
                !IsFinite(enemy.CurrentX) || !IsFinite(enemy.CurrentY) || !IsFinite(enemy.CurrentZ) ||
                enemy.PoseTick < enemy.SpawnTick || enemy.PoseTick > serverTick ||
                (enemy.DeathTick != 0 && enemy.PoseTick > enemy.DeathTick))
            {
                throw new InvalidDataException("Enemy presentation pose is non-finite or outside its live clock.");
            }

            ValidateRotation(enemy.SourceRotation);
            ValidateRotation(enemy.CurrentRotation);
        }

        private static void ValidateRotation(BattleJointRotation rotation)
        {
            if (rotation == null)
            {
                return;
            }

            double lengthSquared = (double)rotation.X * rotation.X + (double)rotation.Y * rotation.Y +
                (double)rotation.Z * rotation.Z + (double)rotation.W * rotation.W;
            if (!IsFinite(rotation.X) || !IsFinite(rotation.Y) || !IsFinite(rotation.Z) ||
                !IsFinite(rotation.W) || Math.Abs(lengthSquared - 1d) > RotationTolerance)
            {
                throw new InvalidDataException("Enemy presentation rotation must be a finite source quaternion.");
            }
        }

        private static bool IsFinite(float value)
        {
            return !float.IsNaN(value) && !float.IsInfinity(value);
        }
    }
}
