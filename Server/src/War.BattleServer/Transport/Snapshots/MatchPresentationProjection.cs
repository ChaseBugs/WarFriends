using War.Protocol;

namespace War.BattleServer;

/// <summary>Projects connection-local rendering support without changing retained gameplay replies.</summary>
internal static class MatchPresentationProjection
{
    internal static MatchReply ForConnection(MatchReply source, string poseRevision)
    {
        if (poseRevision.Length != 0 && poseRevision != CoopObservedObstaclePoseCatalog.ContentRevision)
        {
            throw new InvalidDataException("The connection has an unsupported observed pose revision.");
        }

        MatchReply result = source.Clone();
        result.ObservedPoseCatalogRevision = poseRevision;
        if (result.Snapshot?.Coop == null)
        {
            return result;
        }

        foreach (BattleCoopEnemySpawn enemy in result.Snapshot.Coop.EnemySpawns)
        {
            BattleInfantryAnimationFrame? frame = enemy.InfantryAnimation;
            BattleInfantryObservedPoseReference? reference = frame?.ObservedPose;
            if (frame == null || reference == null)
            {
                continue;
            }

            if (reference.CatalogRevision != CoopObservedObstaclePoseCatalog.ContentRevision ||
                reference.SampleId is < 1 or > CoopObservedObstaclePoseCatalog.SampleCount ||
                result.Snapshot.Phase != BattlePhase.Running || enemy.Health <= 0f || enemy.DeathTick != 0 ||
                frame.SampleTick != result.Snapshot.ServerTick)
            {
                throw new InvalidDataException("The retained snapshot has an invalid observed pose identity or clock.");
            }

            if (poseRevision.Length == 0)
            {
                // Dropping only the reference would display the clip-only pose known to differ from the source.
                enemy.InfantryAnimation = null;
                enemy.InfantryVisualClip = string.Empty;
                enemy.InfantryVisualStartTick = 0;
                enemy.InfantryVisualSampleTick = 0;
            }
        }

        return result;
    }
}
