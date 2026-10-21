using War.Persistence.Legacy.Squads;

namespace War.Backend.Legacy.Squads;

/// <summary>Dispatches pure squad transitions after validating the shared transactional snapshot.</summary>
public sealed class LegacySquadRules(LegacySquadPolicy policy)
{
    public LegacySquadMutation Calculate(LegacySquadSnapshot snapshot, LegacySquadCommand command)
    {
        LegacySquadParser.Validate(command);
        LegacySquadState.Validate(snapshot, command.NowUnixSeconds);
        if (command.TargetId != null && snapshot.Target != null && snapshot.Target.Id != command.TargetId ||
            command.SquadId != null && snapshot.Squad != null && snapshot.Squad.Id != command.SquadId)
        {
            throw new InvalidDataException("Squad command and snapshot identities disagree.");
        }

        LegacySquadMutation mutation = command.Action switch
        {
            DatabaseAction.CreateSquad => LegacySquadAdmission.Create(snapshot, command, policy),
            DatabaseAction.JoinSquad => LegacySquadAdmission.Join(snapshot),
            DatabaseAction.AcceptSquadJoinRequest => LegacySquadAdmission.Accept(snapshot),
            DatabaseAction.LeaveSquad => LegacySquadAdmission.Leave(snapshot),
            DatabaseAction.PromotePlayer or DatabaseAction.DemotePlayer or
                DatabaseAction.PromotePlayerToFounder or DatabaseAction.KickPlayer =>
                LegacySquadRoles.Apply(snapshot, command),
            DatabaseAction.InvitePlayerToSquad or DatabaseAction.JoinSquadRequest or
                DatabaseAction.DeclineSquadJoinRequest or DatabaseAction.UpdateSquad or
                DatabaseAction.UpdateSquadEmblem => LegacySquadSettings.Apply(snapshot, command),
            _ => throw new InvalidDataException("Unsupported squad transition.")
        };
        LegacySquadState.ValidatePlan(mutation, command.NowUnixSeconds);
        return mutation;
    }
}
