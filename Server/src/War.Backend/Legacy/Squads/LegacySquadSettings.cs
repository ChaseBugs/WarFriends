using War.Persistence;
using War.Persistence.Legacy.Squads;

namespace War.Backend.Legacy.Squads;

/// <summary>Fences invitations, requests and settings against the same roster that authorizes them.</summary>
internal static class LegacySquadSettings
{
    internal static LegacySquadMutation Apply(LegacySquadSnapshot snapshot, LegacySquadCommand command)
    {
        if (command.Action == DatabaseAction.JoinSquadRequest)
        {
            return RequestJoin(snapshot);
        }

        if (!LegacySquadState.IsMember(snapshot.Actor, snapshot.Squad))
        {
            return LegacySquadState.Refuse(DatabaseResult.NotLeaderOfSquad);
        }

        return command.Action switch
        {
            DatabaseAction.InvitePlayerToSquad => Invite(snapshot),
            DatabaseAction.DeclineSquadJoinRequest => Decline(snapshot, command),
            DatabaseAction.UpdateSquad or DatabaseAction.UpdateSquadEmblem => Update(snapshot, command),
            _ => throw new InvalidDataException("Unsupported squad settings transition.")
        };
    }

    private static LegacySquadMutation Invite(LegacySquadSnapshot snapshot)
    {
        if (!snapshot.Squad!.IsPublic && !LegacySquadRoles.CanModerate(snapshot.Actor, snapshot.Squad))
        {
            return LegacySquadState.Refuse(DatabaseResult.OnlyLeaderCanSendInvites);
        }

        if (snapshot.Target == null || snapshot.Target.Id == snapshot.Actor.Id ||
            snapshot.Target.SquadId == snapshot.Squad.Id)
        {
            return LegacySquadState.Refuse(DatabaseResult.WrongPlayerData);
        }

        LegacySquadDocument squad = LegacySquadState.Advance(snapshot.Squad);
        if (!squad.PendingInvites.Contains(snapshot.Target.Id))
        {
            squad.PendingInvites.Add(snapshot.Target.Id);
        }

        return Success(squad);
    }

    private static LegacySquadMutation RequestJoin(LegacySquadSnapshot snapshot)
    {
        if (snapshot.Actor.SquadId == snapshot.Squad?.Id ||
            snapshot.Actor.SquadId.Length > 0 && snapshot.Actor.SquadRank == (int)LegacySquadRank.Leader)
        {
            return LegacySquadState.Refuse(DatabaseResult.PlayerAlreadyInSquadCantJoin);
        }

        if (snapshot.Squad == null)
        {
            return LegacySquadState.Refuse(DatabaseResult.SquadNoLongerExists);
        }

        if (snapshot.Actor.Skill < 0)
        {
            throw new InvalidDataException("Invalid squad request skill.");
        }

        if (snapshot.Actor.Skill < snapshot.Squad.SkillRequirement)
        {
            return LegacySquadState.Refuse(DatabaseResult.NotEnoughSkill);
        }

        LegacySquadDocument squad = LegacySquadState.Advance(snapshot.Squad);
        if (!squad.PendingRequests.Contains(snapshot.Actor.Id))
        {
            squad.PendingRequests.Add(snapshot.Actor.Id);
        }

        return Success(squad);
    }

    private static LegacySquadMutation Decline(LegacySquadSnapshot snapshot, LegacySquadCommand command)
    {
        if (!LegacySquadRoles.CanModerate(snapshot.Actor, snapshot.Squad))
        {
            return LegacySquadState.Refuse(DatabaseResult.NotLeaderOfSquad);
        }

        LegacySquadDocument squad = LegacySquadState.Advance(snapshot.Squad!);
        squad.PendingRequests.Remove(command.TargetId!);
        return Success(squad);
    }

    private static LegacySquadMutation Update(LegacySquadSnapshot snapshot, LegacySquadCommand command)
    {
        // SquadInformationContent and SquadEmblemRecord enable these controls only for the Leader.
        if (snapshot.Actor.SquadRank != (int)LegacySquadRank.Leader)
        {
            return LegacySquadState.Refuse(DatabaseResult.NotLeaderOfSquad);
        }

        LegacySquadDocument squad = LegacySquadState.Advance(snapshot.Squad!);
        if (command.Action == DatabaseAction.UpdateSquadEmblem)
        {
            squad.Icon = command.Icon!;
        }
        else
        {
            squad.IsPublic = command.IsPublic!.Value;
            squad.SkillRequirement = command.SkillRequirement!.Value;
            squad.Message = command.Message ?? squad.Message;
        }

        return Success(squad);
    }

    private static LegacySquadMutation Success(LegacySquadDocument squad) => new()
    {
        Result = (int)DatabaseResult.Success,
        Squad = squad
    };
}
