namespace War.BattleServer;

internal sealed partial class RifleMatchSimulation
{
    private ExternalPlayerCombatView? _externalCombatView;

    internal void ConfigureExternalCombatView(ExternalPlayerCombatView view)
    {
        if (mode != MatchManifest.MixedCombatMode || _externalCombatView != null)
        {
            throw new InvalidOperationException("Only a mixed simulation can bind an external active-class view once.");
        }
        _externalCombatView = view ?? throw new ArgumentNullException(nameof(view));
    }

    internal void SuspendWeapon(string playerId)
    {
        Actor actor = actors.Single(candidate => candidate.Definition.PlayerId == playerId);
        actor.First.SelectionChanged();
        actor.Burst.Cancel();
        actor.Minigun.Release();
        actor.Sniper.Cancel();
        actor.Bazooka.Cancel();
        actor.Timeline.ResetToIdle();
        actor.WalkingShotStart = null;
    }

    private bool IsExternalActive(string playerId)
    {
        return _externalCombatView?.IsActive(playerId) == true;
    }

    private bool HasActiveClass(string playerId, LiveWeaponClass weaponClass)
    {
        return !IsExternalActive(playerId) &&
            actors.Single(actor => actor.Definition.PlayerId == playerId).WeaponClass == weaponClass;
    }

    private void RefreshSelectedPose(Actor actor)
    {
        IReadOnlyList<RifleClipLayer> layers = actor.Timeline.Layers;
        actor.Pose = content.Poses.SampleLayers(layers, actor.Aim.BodyRotation, actor.Aim.UpperOverride)
            .Place(actor.Position, actor.Rotation);
        actor.WirePose = RiflePoseProjection.Create(lastTick ?? 0, layers, actor.Rotation,
            actor.Aim.BodyRotation, actor.Aim.UpperOverride);
    }
}
