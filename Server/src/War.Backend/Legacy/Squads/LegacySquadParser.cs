using System.Globalization;

namespace War.Backend.Legacy.Squads;

/// <summary>Preserves canonical Client field names and validates assertions without clamping them.</summary>
public static class LegacySquadParser
{
    private const int MaximumIdentityLength = 128;

    public static LegacySquadCommand Parse(LegacyRequest request, int nowUnixSeconds)
    {
        var command = new LegacySquadCommand { Action = request.Action, NowUnixSeconds = nowUnixSeconds };
        command = request.Action switch
        {
            DatabaseAction.CreateSquad => command with
            {
                SquadId = Required(request, "SquadId"),
                Message = request.Field("Message"),
                Icon = request.Field("Icon") ?? "",
                IsPublic = ReadPublic(request),
                SkillRequirement = ReadCreationSkill(request)
            },
            DatabaseAction.JoinSquad => command with { SquadId = Required(request, "NewSquadId") },
            DatabaseAction.JoinSquadRequest => command with { SquadId = Required(request, "SquadId") },
            DatabaseAction.AcceptSquadJoinRequest => command with
            {
                SquadId = Required(request, "SquadId"),
                TargetId = Required(request, "PlayerToJoin")
            },
            DatabaseAction.InvitePlayerToSquad => command with { TargetId = Required(request, "PlayerToInviteId") },
            DatabaseAction.DeclineSquadJoinRequest => command with { TargetId = Required(request, "Id") },
            DatabaseAction.PromotePlayer or DatabaseAction.DemotePlayer => command with
            {
                TargetId = Required(request, request.Action == DatabaseAction.PromotePlayer
                    ? "PlayerToPromoteId" : "PlayerToDemoteId"),
                ExpectedOldRank = ReadCanonicalInt(request, "OldSquadRank")
            },
            DatabaseAction.PromotePlayerToFounder => command with { TargetId = Required(request, "PlayerToPromoteId") },
            DatabaseAction.KickPlayer => command with { TargetId = Required(request, "PlayerToKickId") },
            DatabaseAction.UpdateSquad => command with
            {
                IsPublic = ReadPublic(request),
                SkillRequirement = ReadCanonicalInt(request, "RequiredMedals"),
                Message = request.Field("Message")
            },
            DatabaseAction.UpdateSquadEmblem => command with { Icon = request.Field("Icon") ?? "" },
            DatabaseAction.LeaveSquad => command,
            _ => throw new InvalidDataException("Unsupported squad command.")
        };
        Validate(command);
        return command;
    }

    public static void Validate(LegacySquadCommand command)
    {
        if (command.NowUnixSeconds < 0 || command.Message?.Length > LegacySquadPolicy.MaximumMessageLength ||
            command.Icon?.Length > MaximumIdentityLength || command.SkillRequirement is < 0 or >
                LegacySquadPolicy.MaximumMedalsRequirement || command.ExpectedOldRank is < 0 or > 3)
        {
            throw new InvalidDataException("Invalid squad command values.");
        }

        if (command.SquadId != null)
        {
            ValidateIdentity(command.SquadId);
        }

        if (command.TargetId != null)
        {
            ValidateIdentity(command.TargetId);
        }

        bool isAdmission = command.Action is DatabaseAction.CreateSquad or DatabaseAction.JoinSquad or
            DatabaseAction.JoinSquadRequest or DatabaseAction.AcceptSquadJoinRequest;
        bool hasTarget = command.Action is DatabaseAction.AcceptSquadJoinRequest or
            DatabaseAction.InvitePlayerToSquad or
            DatabaseAction.DeclineSquadJoinRequest or DatabaseAction.PromotePlayer or DatabaseAction.DemotePlayer or
            DatabaseAction.PromotePlayerToFounder or DatabaseAction.KickPlayer;
        bool hasSettings = command.Action is DatabaseAction.CreateSquad or DatabaseAction.UpdateSquad;
        if (isAdmission && command.SquadId == null || hasTarget && command.TargetId == null ||
            hasSettings && (command.IsPublic == null || command.SkillRequirement == null) ||
            command.Action == DatabaseAction.CreateSquad && (command.SquadId!.Length >
                LegacySquadPolicy.MaximumNameLength || command.Icon == null) ||
            command.Action == DatabaseAction.UpdateSquadEmblem && command.Icon == null ||
            command.Action is DatabaseAction.PromotePlayer or DatabaseAction.DemotePlayer &&
                command.ExpectedOldRank == null)
        {
            throw new InvalidDataException("Incomplete squad command.");
        }
    }

    private static string Required(LegacyRequest request, string field) =>
        request.Field(field) ?? throw new InvalidDataException("Missing squad field: " + field);

    private static void ValidateIdentity(string identity)
    {
        if (identity.Length is < 1 or > MaximumIdentityLength || identity.Any(char.IsControl))
        {
            throw new InvalidDataException("Invalid squad identity.");
        }
    }

    private static bool ReadPublic(LegacyRequest request) => Required(request, "IsPublic") switch
    {
        "0" => false,
        "1" => true,
        _ => throw new InvalidDataException("Expected source IsPublic 0/1.")
    };

    private static int ReadCreationSkill(LegacyRequest request)
    {
        // CreateSquad forwards UIInput text after int.TryParse; it does not normalize that text.
        if (!int.TryParse(Required(request, "SkillRequirement"), NumberStyles.Integer,
                CultureInfo.InvariantCulture, out int value))
        {
            throw new InvalidDataException("Invalid creation skill requirement.");
        }

        return value;
    }

    private static int ReadCanonicalInt(LegacyRequest request, string field)
    {
        string text = Required(request, field);
        if (!int.TryParse(text, NumberStyles.None, CultureInfo.InvariantCulture, out int value) ||
            value.ToString(CultureInfo.InvariantCulture) != text)
        {
            throw new InvalidDataException("Invalid source integer: " + field);
        }

        return value;
    }
}
