using War.Persistence;
using War.Persistence.Legacy.Squads;

namespace War.Backend.Legacy.Squads;

/// <summary>Calculates creation and membership changes without guessing a general squad capacity.</summary>
internal static class LegacySquadAdmission
{
    internal static LegacySquadMutation Create(
        LegacySquadSnapshot snapshot, LegacySquadCommand command, LegacySquadPolicy policy)
    {
        if (snapshot.Actor.SquadId.Length > 0)
        {
            return LegacySquadState.Refuse(DatabaseResult.PlayerAlreadyInSquad);
        }

        if (policy.CreationPrice == null)
        {
            return LegacySquadState.Refuse(DatabaseResult.ServerMaintenance);
        }

        if (snapshot.Squad != null)
        {
            return LegacySquadState.Refuse(DatabaseResult.SquadnameTaken);
        }

        if (policy.CreationPrice < 0 || snapshot.Actor.WarBucks < 0 || snapshot.Actor.SquadCreationsCount < 0)
        {
            throw new InvalidDataException("Invalid squad creation economy.");
        }

        long nextCount = (long)snapshot.Actor.SquadCreationsCount + 1;
        long price = checked(nextCount * policy.CreationPrice.Value);
        if (nextCount > int.MaxValue || price > int.MaxValue)
        {
            return LegacySquadState.Refuse(DatabaseResult.WrongPlayerData);
        }

        if (snapshot.Actor.WarBucks < price)
        {
            return LegacySquadState.Refuse(DatabaseResult.NotEnoughWarBucksForCreateSquad);
        }

        LegacySquadDocument squad = CreateSquad(snapshot.Actor, command);
        LegacySquadPlayerChange actor = LegacySquadState.Change(snapshot.Actor, squad.Id, LegacySquadRank.Leader)
            with
        { WarBucks = snapshot.Actor.WarBucks - price, CreationsCount = (int)nextCount };
        return new LegacySquadMutation
        {
            Result = (int)DatabaseResult.Success,
            Squad = squad,
            IsCreation = true,
            Players = [actor]
        };
    }

    internal static LegacySquadMutation Join(LegacySquadSnapshot snapshot)
    {
        LegacySquadDocument? squad = snapshot.Squad;
        if (snapshot.Actor.SquadId.Length > 0 && snapshot.Actor.SquadId == squad?.Id)
        {
            return LegacySquadState.Refuse(DatabaseResult.JoiningSameSquad);
        }

        if (snapshot.Actor.SquadId.Length > 0 && snapshot.Actor.SquadRank == (int)LegacySquadRank.Leader)
        {
            return LegacySquadState.Refuse(DatabaseResult.PlayerAlreadyInSquadCantJoin);
        }

        if (squad == null)
        {
            return LegacySquadState.Refuse(DatabaseResult.SquadNoLongerExists);
        }

        if (!squad.IsPublic && !squad.PendingInvites.Contains(snapshot.Actor.Id))
        {
            return LegacySquadState.Refuse(DatabaseResult.SquadIsNotPublic);
        }

        return AddMember(snapshot.Actor, squad, snapshot.OtherSquad);
    }

    internal static LegacySquadMutation Accept(LegacySquadSnapshot snapshot)
    {
        if (!LegacySquadRoles.CanModerate(snapshot.Actor, snapshot.Squad))
        {
            return LegacySquadState.Refuse(DatabaseResult.NotLeaderOfSquad);
        }

        if (snapshot.Target == null || snapshot.Target.Id == snapshot.Actor.Id)
        {
            return LegacySquadState.Refuse(DatabaseResult.WrongPlayerData);
        }

        if (!snapshot.Squad!.PendingRequests.Contains(snapshot.Target.Id))
        {
            return LegacySquadState.Refuse(DatabaseResult.SquadJoinRequestNotExists);
        }

        if (snapshot.Target.SquadId == snapshot.Squad.Id ||
            snapshot.Target.SquadId.Length > 0 && snapshot.Target.SquadRank == (int)LegacySquadRank.Leader)
        {
            return LegacySquadState.Refuse(DatabaseResult.PlayerAlreadyInSquad);
        }

        return AddMember(snapshot.Target, snapshot.Squad, snapshot.OtherSquad);
    }

    internal static LegacySquadMutation Leave(LegacySquadSnapshot snapshot)
    {
        if (!LegacySquadState.IsMember(snapshot.Actor, snapshot.Squad))
        {
            return LegacySquadState.Refuse(DatabaseResult.SquadLeaveError);
        }

        LegacySquadDocument squad = LegacySquadState.Advance(snapshot.Squad!);
        if (snapshot.Actor.SquadRank == (int)LegacySquadRank.Leader && squad.Members.Count > 1)
        {
            // SquadScreen explicitly transfers leadership before sending LeaveSquad.
            return LegacySquadState.Refuse(DatabaseResult.SquadNotEmpty);
        }

        squad.Members.RemoveAll(member => member.PlayerId == snapshot.Actor.Id);
        squad.PendingInvites.Remove(snapshot.Actor.Id);
        squad.PendingRequests.Remove(snapshot.Actor.Id);
        return new LegacySquadMutation
        {
            Result = (int)DatabaseResult.Success,
            Squad = squad,
            IsDeletion = squad.Members.Count == 0,
            Players = [LegacySquadState.Change(snapshot.Actor, "", LegacySquadRank.None)]
        };
    }

    private static LegacySquadMutation AddMember(
        LegacyPlayerDocument player, LegacySquadDocument original, LegacySquadDocument? previous)
    {
        if (player.Skill < 0)
        {
            throw new InvalidDataException("Invalid squad admission skill.");
        }

        if (player.Skill < original.SkillRequirement)
        {
            return LegacySquadState.Refuse(DatabaseResult.NotEnoughSkill);
        }

        LegacySquadDocument? previousUpdate = null;
        if (player.SquadId.Length > 0)
        {
            if (previous == null || previous.Id != player.SquadId)
            {
                throw new InvalidDataException("Missing previous squad for member transfer.");
            }

            // SquadRecord.JoinClick sends JoinSquad directly for non-Leaders already in another squad.
            previousUpdate = LegacySquadState.Advance(previous);
            previousUpdate.Members.RemoveAll(member => member.PlayerId == player.Id);
            previousUpdate.PendingRequests.Remove(player.Id);
            previousUpdate.PendingInvites.Remove(player.Id);
        }

        LegacySquadDocument squad = LegacySquadState.Advance(original);
        squad.Members.Add(new LegacySquadMember { PlayerId = player.Id, Rank = (int)LegacySquadRank.Member });
        squad.PendingRequests.Remove(player.Id);
        squad.PendingInvites.Remove(player.Id);
        return new LegacySquadMutation
        {
            Result = (int)DatabaseResult.Success,
            Squad = squad,
            OtherSquad = previousUpdate,
            Players = [LegacySquadState.Change(player, squad.Id, LegacySquadRank.Member)]
        };
    }

    private static LegacySquadDocument CreateSquad(LegacyPlayerDocument actor, LegacySquadCommand command) => new()
    {
        Id = command.SquadId!,
        Message = command.Message ?? "",
        Icon = command.Icon!,
        IsPublic = command.IsPublic!.Value,
        SkillRequirement = command.SkillRequirement!.Value,
        Members = [new LegacySquadMember { PlayerId = actor.Id, Rank = (int)LegacySquadRank.Leader }],
        CreatedUtc = DateTimeOffset.FromUnixTimeSeconds(command.NowUnixSeconds).UtcDateTime,
        Revision = 1
    };
}
