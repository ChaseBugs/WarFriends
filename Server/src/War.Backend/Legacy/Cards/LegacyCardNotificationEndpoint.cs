using War.Persistence;

namespace War.Backend.Legacy.Cards;

public sealed class LegacyCardNotificationEndpoint
{
    private readonly LegacyPlayerStore _players;

    public LegacyCardNotificationEndpoint(LegacyPlayerStore players)
    {
        _players = players;
    }

    /// <summary>
    /// Answers <see cref="DatabaseAction.NotifyPlayerToDeposit"/> (178) — <c>CardpoolRecord.NotifyClick</c>
    /// nudges a squadmate to deposit into the card pool. <c>ServerResponseHandler</c> shares its
    /// success case with <c>UpdateArmyPower</c>, logging only ("Action Success") and reading nothing
    /// back; a real push notification (Fuse/FCM) is out of scope, same as every other retired
    /// third-party SDK. Only real validation possible: the target must actually be a squadmate of
    /// the caller — never trusted blindly, matching <see cref="DatabaseAction.WithdrawCard"/>'s same target check.
    /// </summary>
    public async Task<IResult> NotifyAsync(
        LegacyRequest request, LegacyPlayerDocument player, CancellationToken cancellationToken)
    {
        string? targetId = request.Field("SquadMemberId");
        if (string.IsNullOrEmpty(targetId) || targetId == player.Id)
        {
            return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        }
        if (player.SquadId.Length == 0)
        {
            return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        }

        var target = await _players.ById(targetId, cancellationToken);
        if (target == null || target.SquadId != player.SquadId)
        {
            return LegacyResponse.Failure(DatabaseResult.WrongPlayerData);
        }

        return LegacyResponse.Json(DatabaseResult.Success);
    }
}
