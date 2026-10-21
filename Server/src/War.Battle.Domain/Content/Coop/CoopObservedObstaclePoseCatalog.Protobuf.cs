using System.Numerics;
using War.Protocol;

namespace War.BattleServer;

internal sealed partial class CoopObservedObstaclePoseCatalog
{
    /// <summary>Copies verified content into portable protobuf data without publishing a match pose.</summary>
    internal ObservedInfantryPoseCatalog ProtobufSnapshot()
    {
        var result = new ObservedInfantryPoseCatalog { Revision = Revision, PrefabSha256 = _enemyRevision };
        foreach (TransformIdentity transform in Skeleton)
        {
            result.Skeleton.Add(new ObservedInfantryPoseTransform
            {
                Index = (uint)transform.Index, Path = transform.Path, Name = transform.Name
            });
        }
        foreach (Sample sample in _samples)
        {
            result.Samples.Add(CopySample(sample));
        }
        return result;
    }

    private static ObservedInfantryPoseSample CopySample(Sample sample)
    {
        var result = new ObservedInfantryPoseSample
        {
            Id = (uint)sample.Identity.Id,
            PriorReturnTicks = (uint)sample.Identity.PriorReturnTicks,
            ObservationTick = (uint)sample.Identity.ObservationTick
        };
        result.Clips.AddRange(sample.Animation(0).Clips);
        foreach (PoseOverride pose in sample.Overrides)
        {
            result.Overrides.Add(new ObservedInfantryPoseOverride
            {
                TransformIndex = (uint)pose.TransformIndex,
                Position = CopyVector(pose.LocalPosition), Scale = CopyVector(pose.LocalScale)
            });
        }
        return result;
    }

    private static ObservedInfantryPoseVector CopyVector(Vector3 value)
    {
        return new ObservedInfantryPoseVector { X = value.X, Y = value.Y, Z = value.Z };
    }
}
