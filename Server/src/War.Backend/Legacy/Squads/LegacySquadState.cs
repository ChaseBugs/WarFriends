using War.Persistence;
using War.Persistence.Legacy.Squads;

namespace War.Backend.Legacy.Squads;

/// <summary>Validates membership mirrors and builds copies so rejected calculations cannot mutate a snapshot.</summary>
internal static class LegacySquadState
{
    internal static void Validate(LegacySquadSnapshot snapshot, int nowUnixSeconds)
    {
        if (nowUnixSeconds < 0)
        {
            throw new InvalidDataException("Invalid squad application time.");
        }

        ValidatePlayer(snapshot.Actor, snapshot.ActorMemberships);
        if (snapshot.Target != null)
        {
            ValidatePlayer(snapshot.Target, snapshot.TargetMemberships);
        }

        if (snapshot.OtherSquad != null)
        {
            ValidateSquad(snapshot.OtherSquad, nowUnixSeconds);
            ValidateMemberMirror(snapshot.Actor, snapshot.OtherSquad);
            if (snapshot.Target != null)
            {
                ValidateMemberMirror(snapshot.Target, snapshot.OtherSquad);
            }
        }

        if (snapshot.Squad == null)
        {
            return;
        }

        ValidateSquad(snapshot.Squad, nowUnixSeconds);
        ValidateMemberMirror(snapshot.Actor, snapshot.Squad);
        if (snapshot.Target != null)
        {
            ValidateMemberMirror(snapshot.Target, snapshot.Squad);
        }
    }

    internal static LegacySquadDocument Advance(LegacySquadDocument original) => new()
    {
        Id = original.Id,
        Message = original.Message,
        Icon = original.Icon,
        IsPublic = original.IsPublic,
        SkillRequirement = original.SkillRequirement,
        Members = original.Members.Select(member => new LegacySquadMember
        {
            PlayerId = member.PlayerId,
            Rank = member.Rank
        }).ToList(),
        PendingInvites = [.. original.PendingInvites],
        PendingRequests = [.. original.PendingRequests],
        CreatedUtc = original.CreatedUtc,
        Revision = checked(original.Revision + 1)
    };

    internal static void ValidatePlan(LegacySquadMutation mutation, int nowUnixSeconds)
    {
        if (mutation.Result != (int)DatabaseResult.Success || mutation.IsDeletion)
        {
            return;
        }

        LegacySquadDocument squad = mutation.Squad ?? throw new InvalidDataException("Missing planned squad.");
        ValidateSquad(squad, nowUnixSeconds);
        if (mutation.OtherSquad != null)
        {
            ValidateSquad(mutation.OtherSquad, nowUnixSeconds);
        }

        foreach (LegacySquadPlayerChange change in mutation.Players)
        {
            LegacySquadMember? member = squad.Members.SingleOrDefault(row => row.PlayerId == change.PlayerId);
            if (change.SquadId == squad.Id ? member == null || member.Rank != change.Rank : member != null)
            {
                throw new InvalidDataException("Planned squad and account mirror disagree.");
            }

            if (mutation.OtherSquad?.Members.Any(row => row.PlayerId == change.PlayerId) == true)
            {
                throw new InvalidDataException("Transferred player remains in the previous squad.");
            }
        }
    }

    internal static LegacySquadPlayerChange Change(
        LegacyPlayerDocument player, string squadId, LegacySquadRank rank) => new()
        {
            PlayerId = player.Id,
            ExpectedRevision = player.Revision,
            SquadId = squadId,
            Rank = (int)rank
        };

    internal static LegacySquadMutation Refuse(DatabaseResult result) => new() { Result = (int)result };

    internal static bool IsMember(LegacyPlayerDocument player, LegacySquadDocument? squad) =>
        squad != null && player.SquadId == squad.Id && squad.Members.Any(member => member.PlayerId == player.Id);

    private static void ValidatePlayer(LegacyPlayerDocument player, IReadOnlyList<string> memberships)
    {
        if (player.SquadId == null || player.Revision < 0 || player.Revision == long.MaxValue ||
            player.SquadRank is < -1 or > 3 || memberships.Count > 1 ||
            player.SquadId.Length == 0 && (memberships.Count != 0 || player.SquadRank is not (-1 or 0)) ||
            player.SquadId.Length > 0 && (memberships.Count != 1 || memberships[0] != player.SquadId ||
                player.SquadRank == (int)LegacySquadRank.None))
        {
            throw new InvalidDataException("Invalid squad account/membership mirror.");
        }
    }

    private static void ValidateSquad(LegacySquadDocument squad, int nowUnixSeconds)
    {
        DateTime nowUtc = DateTimeOffset.FromUnixTimeSeconds(nowUnixSeconds).UtcDateTime;
        if (string.IsNullOrEmpty(squad.Id) || squad.Id.Length > LegacySquadPolicy.MaximumNameLength ||
            squad.Message == null || squad.Message.Length > LegacySquadPolicy.MaximumMessageLength ||
            squad.Icon == null || squad.SkillRequirement is < 0 or > LegacySquadPolicy.MaximumMedalsRequirement ||
            squad.Revision < 0 || squad.Revision == long.MaxValue ||
            squad.CreatedUtc < DateTime.UnixEpoch || squad.CreatedUtc > nowUtc ||
            squad.Members == null || squad.Members.Count == 0 ||
            squad.PendingInvites == null || squad.PendingRequests == null)
        {
            throw new InvalidDataException("Invalid squad authority.");
        }

        var members = new HashSet<string>(StringComparer.Ordinal);
        foreach (LegacySquadMember member in squad.Members)
        {
            if (member == null || string.IsNullOrEmpty(member.PlayerId) ||
                member.Rank is < 0 or > 3 || !members.Add(member.PlayerId))
            {
                throw new InvalidDataException("Invalid or duplicate squad member.");
            }
        }

        if (squad.Members.Count > 0 && squad.Members.Count(member => member.Rank == (int)LegacySquadRank.Leader) != 1)
        {
            throw new InvalidDataException("A non-empty squad must have one leader.");
        }

        if (squad.Members.Count(member => member.Rank == (int)LegacySquadRank.Coleader) >
            LegacySquadPolicy.MaximumColeaders)
        {
            throw new InvalidDataException("Squad exceeds the source Coleader limit.");
        }

        ValidatePending(squad.PendingInvites);
        ValidatePending(squad.PendingRequests);
    }

    private static void ValidatePending(List<string> identities)
    {
        var seen = new HashSet<string>(StringComparer.Ordinal);
        if (identities.Any(identity => string.IsNullOrEmpty(identity) || !seen.Add(identity)))
        {
            throw new InvalidDataException("Invalid squad pending identity list.");
        }
    }

    private static void ValidateMemberMirror(LegacyPlayerDocument player, LegacySquadDocument squad)
    {
        LegacySquadMember? member = squad.Members.SingleOrDefault(row => row.PlayerId == player.Id);
        if (player.SquadId == squad.Id ? member == null || member.Rank != player.SquadRank : member != null)
        {
            throw new InvalidDataException("Account and roster rank/identity disagree.");
        }
    }
}
