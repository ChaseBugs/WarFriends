namespace War.BattleServer;

internal sealed partial class GrenadeMatchSimulation
{
    internal bool IsActive(string playerId)
    {
        RequireParticipant(playerId);
        return _actors.TryGetValue(playerId, out Actor? actor) && actor.IsActive;
    }

    internal bool Busy(string playerId)
    {
        RequireParticipant(playerId);
        return _actors.TryGetValue(playerId, out Actor? actor) && actor.Pending != null;
    }

    internal void ConfigureMixedPlayerPoses(Func<string, PlayerAimPose> provider)
    {
        if (!_isMixedMode || _activePlayerPoseProvider != null)
        {
            throw new InvalidOperationException("Mixed player collision poses can only be configured once.");
        }
        _activePlayerPoseProvider = provider ?? throw new ArgumentNullException(nameof(provider));
    }

    internal void SelectWeapon(string playerId, WeaponManifest weapon, int upgrade, ulong tick)
    {
        Actor actor = ActorOf(playerId);
        SelectWeapon(playerId, new GrenadeWeaponSelection(weapon, upgrade, tick,
            new RifleActorLocation(actor.Position, actor.CoverIndex, actor.Moving)));
    }

    internal void SelectWeapon(string playerId, GrenadeWeaponSelection selection)
    {
        ParticipantManifest participant = RequireParticipant(playerId);
        RequireSelectionClock(selection.Tick);
        RequireOwnedSlot(participant, selection);
        _actors.TryGetValue(playerId, out Actor? existing);
        if (existing?.Pending != null || selection.Location.Moving)
        {
            throw new InvalidDataException("A moving or throwing grenade actor cannot change weapons.");
        }
        CoverNode cover = RequireSelectionCover(participant, selection.Location);
        GrenadeBinding binding = catalog.Binding(selection.Weapon.SourceId);
        if (catalog.CreateManifest(selection.Weapon.SourceId, selection.Upgrade) != selection.Weapon)
        {
            throw new InvalidDataException("Grenade weapon selection differs from the recovered source stage.");
        }

        string clip = binding.Swipe ? "grenade_idle" : "grenadelauncher_idle";
        GrenadePoseFrame pose = Place(catalog.Poses.Sample(clip, 0, true), selection.Location.Position, cover.Rotation);
        Actor actor = existing ?? new Actor(participant with
        {
            Weapon = selection.Weapon, WeaponUpgrade = selection.Upgrade
        }, cover, binding, catalog.Poses);
        PublishSelection(actor, selection, binding, pose);
        _actors[playerId] = actor;
    }

    internal void DeselectWeapon(string playerId, ulong tick)
    {
        RequireParticipant(playerId);
        RequireSelectionClock(tick);
        if (!_isMixedMode)
        {
            throw new InvalidDataException("A grenade-only participant cannot leave its combat class.");
        }
        if (!_actors.TryGetValue(playerId, out Actor? actor))
        {
            return;
        }
        if (actor.Pending != null || actor.Moving)
        {
            throw new InvalidDataException("A moving or throwing grenade actor cannot leave its combat class.");
        }
        actor.IsActive = false;
    }

    private void PublishSelection(Actor actor, GrenadeWeaponSelection selection, GrenadeBinding binding,
        GrenadePoseFrame pose)
    {
        // Dormant actors re-enter at the host's current cover; the original spawn cover is not current authority.
        actor.Binding = binding;
        actor.WeaponUpgrade = selection.Upgrade;
        actor.Position = selection.Location.Position;
        actor.CoverIndex = selection.Location.CoverIndex;
        actor.Rotation = map.Covers[selection.Location.CoverIndex].Rotation;
        actor.Clip = binding.Swipe ? "grenade_idle" : "grenadelauncher_idle";
        actor.ClipStarted = selection.Tick;
        actor.Pose = pose;
        actor.PoseClip = actor.Clip;
        actor.PoseSeconds = 0;
        actor.Moving = false;
        actor.IsActive = true;
    }

    private ParticipantManifest RequireParticipant(string playerId)
    {
        return _participants.SingleOrDefault(player => player.PlayerId == playerId)
            ?? throw new InvalidDataException("The grenade simulation participant is unknown.");
    }

    private void RequireSelectionClock(ulong tick)
    {
        if ((lastTick.HasValue && tick != lastTick.Value) || (!lastTick.HasValue && tick != 0))
        {
            throw new InvalidDataException("Grenade weapon selection must use the current host tick.");
        }
    }

    private static void RequireOwnedSlot(ParticipantManifest participant, GrenadeWeaponSelection selection)
    {
        bool isInitial = participant.Weapon == selection.Weapon && participant.WeaponUpgrade == selection.Upgrade;
        bool isEquipped = participant.WeaponSlots?.Any(slot =>
            slot.Weapon == selection.Weapon && slot.WeaponUpgrade == selection.Upgrade) == true;
        if (!isInitial && !isEquipped)
        {
            throw new InvalidDataException("The selected grenade is absent from the trusted participant slots.");
        }
    }

    private CoverNode RequireSelectionCover(ParticipantManifest participant, RifleActorLocation location)
    {
        if (!PlayerHitbox.Finite(location.Position) || location.CoverIndex < 0 ||
            location.CoverIndex >= map.Covers.Count || map.Covers[location.CoverIndex].Fraction != participant.Fraction)
        {
            throw new InvalidDataException("Grenade selection has an invalid host location.");
        }
        return map.Covers[location.CoverIndex];
    }

    private IEnumerable<CollisionPlayer> CurrentCollisionPlayers()
    {
        if (_isMixedMode && _activePlayerPoseProvider == null)
        {
            throw new InvalidDataException("Mixed grenade collision requires every participant's active-class pose.");
        }
        return _participants.Select(participant => new CollisionPlayer(participant.PlayerId,
            CurrentPlayerCollision(participant.PlayerId),
            participant.Fraction == 1 ? 23 : 22));
    }

    private PlayerCollisionModel CurrentPlayerCollision(string playerId)
    {
        if (_activePlayerPoseProvider == null)
        {
            return ActorOf(playerId).Pose.Collision;
        }

        PlayerAimPose pose = _activePlayerPoseProvider(playerId)
            ?? throw new InvalidDataException("The active-class player pose is missing.");
        return pose.Collision;
    }
}
