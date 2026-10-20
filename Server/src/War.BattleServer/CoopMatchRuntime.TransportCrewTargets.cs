using System.Numerics;

namespace War.BattleServer;

internal sealed partial class CoopMatchRuntime
{
    private const int CrewShieldTargetMask = 2;
    private const int CrewWholeBodyTargetMask = 9;
    private const int CrewMovingTargetMask = 16;
    private const float WalkingShieldProbabilityScale = 0.5f;

    private readonly Dictionary<ulong, AssaulterWeaponAimState> _transportCrewAimWeapons = new();

    /// <summary>Acquires a source player target in restricted co-op, without granting hit authority.</summary>
    internal TransportCrewTargetAcquisition AcquireTransportCrewTarget(TransportCrewNavigationCommand command,
        TransportCrewObstacleObservation pending, Vector3? observedWeaponMuzzle)
    {
        ArgumentNullException.ThrowIfNull(pending);
        ArgumentNullException.ThrowIfNull(pending.Clock);
        if (observedWeaponMuzzle.HasValue && !PlayerHitbox.Finite(observedWeaponMuzzle.Value))
        {
            throw new InvalidDataException("Crew acquisition muzzle must be a finite host observation.");
        }
        TransportCrewNavigationOwner owner = RequireCrewShotOwner(command, pending.Clock.Frame);
        if (!ReferenceEquals(owner.PendingObstacleObservation, pending))
        {
            throw new InvalidOperationException("Crew acquisition requires the exact pending source callback.");
        }
        owner.ObstacleClock!.RequireShotPreparation(pending.Clock);
        if (!CoopCommandCapabilities.CanConfirmPlayerOnlyOpposition || playerShotTargets == null ||
            !_transportCrewAimWeapons.TryGetValue(command.ActorEntityId, out AssaulterWeaponAimState? weapon))
        {
            return CrewTargetUnavailable("target-world-unavailable");
        }
        if (!owner.CrewTargetChoiceAttempted)
        {
            owner.CrewTargetChoice = ChooseCrewPlayer(pending.Position);
            owner.CrewTargetChoiceAttempted = true;
        }
        CrewPlayerTargetChoice? choice = owner.CrewTargetChoice;
        if (choice == null)
        {
            // GetRandomEnemy's current-player fallback is not proof of a live target in an unavailable roster.
            return CrewTargetUnavailable("active-player-unavailable");
        }
        if (choice.Revision != stateRevision)
        {
            return CrewTargetUnavailable("target-world-changed");
        }
        if (owner.AcquiredCrewTarget != null)
        {
            return new TransportCrewTargetAcquisition(owner.AcquiredCrewTarget, string.Empty);
        }
        return ResolveCrewPlayerPose(owner, choice, new CrewPlayerPoseInputs(pending, observedWeaponMuzzle, weapon));
    }

    private CrewPlayerTargetChoice? ChooseCrewPlayer(Vector3 position)
    {
        float probability = combat.ShieldHitProbability(SourceCrewBehaviour);
        if (probability < 0)
        {
            return null;
        }
        Participant[] active = manifest.Players
            .OrderBy(player => CoopSceneRoles.GetMainPositionIndex(manifest, player.PlayerId))
            .Select(player => participants[player.PlayerId])
            .Where(player => player.Admitted && player.Ready && !player.Dead && !player.Departed).ToArray();
        if (active.Length == 0)
        {
            return null;
        }
        Participant selected = active[ChooseCrewTargetIndex(active.Length)];
        bool walking = selected.Route != null;
        Vector3 towardCrew = position - selected.Position;
        float distanceSquared = towardCrew.LengthSquared();
        if (!float.IsFinite(distanceSquared) || distanceSquared == 0)
        {
            return null;
        }
        int mask = MatchEngine.SoldierStationaryTargetMask(PlayerAimForward(selected.PlayerId), towardCrew,
            walking ? probability * WalkingShieldProbabilityScale : probability, chooseInfantryShieldRoll);
        int? shieldId = null;
        if (mask == CrewShieldTargetMask)
        {
            PlayerShotTarget[] shields = playerShotTargets!.Gameplay.Where(target =>
                (target.Type & CrewShieldTargetMask) == target.Type).ToArray();
            if (shields.Length > 0)
            {
                shieldId = shields[ChooseCrewTargetIndex(shields.Length)].TransformFileId;
            }
            else
            {
                mask = CrewWholeBodyTargetMask;
            }
        }
        if (mask != CrewShieldTargetMask && walking)
        {
            mask = CrewMovingTargetMask;
        }
        return new CrewPlayerTargetChoice(selected.PlayerId, walking, mask, shieldId) { Revision = stateRevision };
    }

    private TransportCrewTargetAcquisition ResolveCrewPlayerPose(TransportCrewNavigationOwner owner,
        CrewPlayerTargetChoice choice, CrewPlayerPoseInputs inputs)
    {
        TransportCrewObstacleObservation pending = inputs.Pending;
        Participant player = participants[choice.PlayerId];
        PlayerAimPose? pose = choice.Walking
            ? SampleMovingWeaponPose(player)?.Pose : PlaceSettledWeaponPose(player)?.Pose;
        if (pose == null)
        {
            return CrewTargetUnavailable("player-pose-unavailable");
        }
        PlayerShotTarget source = choice.ShieldTransformId.HasValue
            ? playerShotTargets!.Gameplay.Single(target => target.TransformFileId == choice.ShieldTransformId.Value)
            : playerShotTargets!.Nearest(choice.Mask, pending.Position,
                target => pose.BodyTargetPosition(target.TransformFileId));
        Vector3 rawPosition = pose.BodyTargetPosition(source.TransformFileId);
        Vector3 velocity = choice.Walking ? player.MovementVelocity : Vector3.Zero;
        Vector3 aimPosition = rawPosition;
        if (choice.Mask == CrewMovingTargetMask)
        {
            if (inputs.Muzzle == null)
            {
                return CrewTargetUnavailable("weapon-muzzle-unavailable");
            }
            aimPosition = inputs.Weapon.SelectMovingPlayer(inputs.Muzzle.Value, rawPosition, velocity).TargetPosition;
        }
        var plan = new TransportCrewTargetPlan
        {
            ActorId = owner.Command.ActorEntityId,
            PlayerId = player.PlayerId,
            Frame = pending.Clock.Frame,
            Tick = tick,
            Revision = stateRevision,
            TransformFileId = source.TransformFileId,
            TargetType = source.Type,
            TargetMask = choice.Mask,
            TransformPosition = rawPosition,
            PreparedAimPosition = aimPosition,
            TargetVelocity = velocity,
            TargetWasWalking = choice.Walking,
        };
        owner.AcquiredCrewTarget = plan;
        return new TransportCrewTargetAcquisition(plan, string.Empty);
    }

    private int ChooseCrewTargetIndex(int count)
    {
        int index = chooseInfantryPlayer(count);
        if (index < 0 || index >= count)
        {
            throw new InvalidDataException("Crew source target index is outside its candidate list.");
        }
        return index;
    }

    private static TransportCrewTargetAcquisition CrewTargetUnavailable(string reason)
    {
        return new TransportCrewTargetAcquisition(null, reason);
    }

    internal sealed record CrewPlayerTargetChoice(string PlayerId, bool Walking, int Mask, int? ShieldTransformId)
    {
        internal required ulong Revision { get; init; }
    }

    internal sealed record TransportCrewTargetAcquisition(TransportCrewTargetPlan? Target, string UnavailableReason);

    private sealed record CrewPlayerPoseInputs(TransportCrewObstacleObservation Pending, Vector3? Muzzle,
        AssaulterWeaponAimState Weapon);

    /// <summary>Match-owned targeting inputs, not a projectile origin or a collision proof.</summary>
    internal sealed record TransportCrewTargetPlan
    {
        internal required ulong ActorId { get; init; }
        internal required string PlayerId { get; init; }
        internal required ulong Frame { get; init; }
        internal required ulong Tick { get; init; }
        internal required ulong Revision { get; init; }
        internal required int TransformFileId { get; init; }
        internal required int TargetType { get; init; }
        internal required int TargetMask { get; init; }
        internal required Vector3 TransformPosition { get; init; }
        internal required Vector3 PreparedAimPosition { get; init; }
        internal required Vector3 TargetVelocity { get; init; }
        internal required bool TargetWasWalking { get; init; }
    }
}
