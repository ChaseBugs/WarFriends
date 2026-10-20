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
        public static IReadOnlyList<CoopEnemyViewState> FromSnapshot(
            MatchSnapshot snapshot, string localPlayerId)
        {
            return FromSnapshot(snapshot, localPlayerId, string.Empty);
        }

        /// <summary>Accepts observed references only for the caller's explicitly negotiated renderer revision.</summary>
        public static IReadOnlyList<CoopEnemyViewState> FromSnapshot(
            MatchSnapshot snapshot, string localPlayerId, string observedPoseCatalogRevision)
        {
            if (observedPoseCatalogRevision == null || (observedPoseCatalogRevision.Length != 0 &&
                observedPoseCatalogRevision != ObservedInfantryPoseCatalogData.BuiltIn.Revision))
            {
                throw new InvalidDataException("Enemy presentation has no matching installed pose catalog.");
            }
            CoopOutcomeProjection.ForPlayer(snapshot, localPlayerId);
            if (string.IsNullOrEmpty(snapshot.MatchId) || string.IsNullOrEmpty(snapshot.ManifestHash) ||
                (!snapshot.Coop.Started && snapshot.Coop.EnemySpawns.Count != 0))
            {
                throw new InvalidDataException("Enemy presentation requires an identified, started source mission.");
            }

            var views = new List<CoopEnemyViewState>(snapshot.Coop.EnemySpawns.Count);
            CoopCrewSnapshotValidation.Validate(snapshot);
            ulong minimumId = FirstEnemyId;
            foreach (BattleCoopEnemySpawn enemy in snapshot.Coop.EnemySpawns)
            {
                if (views.Count == 0 && enemy.EntityId != FirstEnemyId)
                {
                    throw new InvalidDataException("Complete enemy roster must retain its first host allocation.");
                }
                ValidateIdentity(enemy, minimumId, snapshot);
                ValidateVitality(enemy, snapshot.ServerTick);
                ValidatePose(enemy, snapshot.ServerTick);
                ValidateAnimation(enemy, snapshot.ServerTick, snapshot.Phase);
                InfantryAnimationFrameView animation = InfantryAnimationFrameView.FromEnemy(
                    enemy, snapshot, observedPoseCatalogRevision);
                views.Add(new CoopEnemyViewState(enemy, animation));
                // The shared allocator also issues secondary crew and respawn IDs.
                // Ordinary enemy rows preserve allocation order, with legitimate gaps.
                minimumId = enemy.EntityId + 1;
            }

            return views.AsReadOnly();
        }

        private static void ValidateIdentity(BattleCoopEnemySpawn enemy, ulong minimumId, MatchSnapshot snapshot)
        {
            if (enemy.EntityId < minimumId || enemy.EntityId == ulong.MaxValue ||
                !Behaviours.Contains(enemy.Behaviour) || enemy.Level < 0 ||
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

        private static void ValidateAnimation(BattleCoopEnemySpawn enemy, ulong serverTick, BattlePhase phase)
        {
            if (enemy.InfantryVisualClip.Length == 0)
            {
                if (enemy.InfantryVisualStartTick != 0 || enemy.InfantryVisualSampleTick != 0)
                {
                    throw new InvalidDataException("An absent enemy animation cannot carry a visual clock.");
                }

                return;
            }

            if (phase != BattlePhase.Running || enemy.Behaviour != "Assaulter" ||
                enemy.InfantryVisualClip != "run_0" || enemy.Health <= 0 ||
                enemy.CurrentRotation == null || enemy.InfantryVisualStartTick < enemy.SpawnTick ||
                enemy.InfantryVisualStartTick > enemy.InfantryVisualSampleTick ||
                enemy.InfantryVisualSampleTick != enemy.PoseTick || enemy.InfantryVisualSampleTick != serverTick)
            {
                throw new InvalidDataException("Enemy walking presentation has an unsupported clip or clock.");
            }
        }

        private static bool IsFinite(float value)
        {
            return !float.IsNaN(value) && !float.IsInfinity(value);
        }
    }
}
