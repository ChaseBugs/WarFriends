using War.Persistence;
using War.Persistence.Legacy.Squads;

namespace War.Backend.Legacy.Squads;

/// <summary>Applies MemberRecord/MiscTools authority order rather than incrementing wire enum values.</summary>
internal static class LegacySquadRoles
{
    internal static bool CanModerate(LegacyPlayerDocument actor, LegacySquadDocument? squad) =>
        LegacySquadState.IsMember(actor, squad) && Order(actor.SquadRank) >= Order((int)LegacySquadRank.Veteran);

    internal static LegacySquadMutation Apply(LegacySquadSnapshot snapshot, LegacySquadCommand command)
    {
        if (!CanModerate(snapshot.Actor, snapshot.Squad))
        {
            return LegacySquadState.Refuse(DatabaseResult.NotLeaderOfSquad);
        }

        if (snapshot.Target == null || snapshot.Target.Id == snapshot.Actor.Id ||
            !LegacySquadState.IsMember(snapshot.Target, snapshot.Squad))
        {
            return LegacySquadState.Refuse(DatabaseResult.WrongPlayerData);
        }

        return command.Action switch
        {
            DatabaseAction.PromotePlayer => Promote(snapshot, command),
            DatabaseAction.DemotePlayer => Demote(snapshot, command),
            DatabaseAction.PromotePlayerToFounder => TransferLeadership(snapshot),
            DatabaseAction.KickPlayer => Kick(snapshot),
            _ => throw new InvalidDataException("Unsupported squad role transition.")
        };
    }

    private static LegacySquadMutation Promote(LegacySquadSnapshot snapshot, LegacySquadCommand command)
    {
        int rank = snapshot.Target!.SquadRank;
        if (command.ExpectedOldRank != rank || Order(rank) >= Order(snapshot.Actor.SquadRank) ||
            rank is not ((int)LegacySquadRank.Member or (int)LegacySquadRank.Veteran))
        {
            return LegacySquadState.Refuse(DatabaseResult.PromotePlayerError);
        }

        LegacySquadRank next = rank == (int)LegacySquadRank.Member ? LegacySquadRank.Veteran : LegacySquadRank.Coleader;
        if (next == LegacySquadRank.Coleader && snapshot.Squad!.Members.Count(member =>
                member.Rank == (int)LegacySquadRank.Coleader) >= LegacySquadPolicy.MaximumColeaders)
        {
            return LegacySquadState.Refuse(DatabaseResult.PromotePlayerError);
        }

        return SetTargetRank(snapshot, next);
    }

    private static LegacySquadMutation Demote(LegacySquadSnapshot snapshot, LegacySquadCommand command)
    {
        int rank = snapshot.Target!.SquadRank;
        if (command.ExpectedOldRank != rank || !CanDemoteOrKick(snapshot) ||
            rank is not ((int)LegacySquadRank.Veteran or (int)LegacySquadRank.Coleader))
        {
            return LegacySquadState.Refuse(DatabaseResult.DemotePlayerError);
        }

        LegacySquadRank next = rank == (int)LegacySquadRank.Coleader ? LegacySquadRank.Veteran : LegacySquadRank.Member;
        return SetTargetRank(snapshot, next);
    }

    private static LegacySquadMutation TransferLeadership(LegacySquadSnapshot snapshot)
    {
        if (snapshot.Actor.SquadRank != (int)LegacySquadRank.Leader)
        {
            return LegacySquadState.Refuse(DatabaseResult.PromoteToFounderError);
        }

        LegacySquadDocument squad = LegacySquadState.Advance(snapshot.Squad!);
        squad.Members.Single(member => member.PlayerId == snapshot.Target!.Id).Rank = (int)LegacySquadRank.Leader;
        squad.Members.Single(member => member.PlayerId == snapshot.Actor.Id).Rank = (int)LegacySquadRank.Veteran;
        return new LegacySquadMutation
        {
            Result = (int)DatabaseResult.Success,
            Squad = squad,
            Players = [LegacySquadState.Change(snapshot.Target!, squad.Id, LegacySquadRank.Leader),
                LegacySquadState.Change(snapshot.Actor, squad.Id, LegacySquadRank.Veteran)]
        };
    }

    private static LegacySquadMutation Kick(LegacySquadSnapshot snapshot)
    {
        if (!CanDemoteOrKick(snapshot))
        {
            return LegacySquadState.Refuse(DatabaseResult.KickPlayerError);
        }

        LegacySquadDocument squad = LegacySquadState.Advance(snapshot.Squad!);
        squad.Members.RemoveAll(member => member.PlayerId == snapshot.Target!.Id);
        squad.PendingInvites.Remove(snapshot.Target!.Id);
        squad.PendingRequests.Remove(snapshot.Target.Id);
        return new LegacySquadMutation
        {
            Result = (int)DatabaseResult.Success,
            Squad = squad,
            Players = [LegacySquadState.Change(snapshot.Target, "", LegacySquadRank.None)]
        };
    }

    private static bool CanDemoteOrKick(LegacySquadSnapshot snapshot)
    {
        int comparison = Math.Sign(Order(snapshot.Target!.SquadRank) - Order(snapshot.Actor.SquadRank));
        int threshold = snapshot.Actor.SquadRank == (int)LegacySquadRank.Coleader ? 1 : 0;
        // MemberRecord permits Coleaders to demote/kick peers, but never the Leader.
        return comparison < threshold;
    }

    private static LegacySquadMutation SetTargetRank(LegacySquadSnapshot snapshot, LegacySquadRank rank)
    {
        LegacySquadDocument squad = LegacySquadState.Advance(snapshot.Squad!);
        squad.Members.Single(member => member.PlayerId == snapshot.Target!.Id).Rank = (int)rank;
        return new LegacySquadMutation
        {
            Result = (int)DatabaseResult.Success,
            Squad = squad,
            Players = [LegacySquadState.Change(snapshot.Target!, squad.Id, rank)]
        };
    }

    private static int Order(int rank) => (LegacySquadRank)rank switch
    {
        LegacySquadRank.None => -1,
        LegacySquadRank.Member => 0,
        LegacySquadRank.Veteran => 1,
        LegacySquadRank.Coleader => 2,
        LegacySquadRank.Leader => 3,
        _ => throw new InvalidDataException("Invalid squad rank.")
    };
}
