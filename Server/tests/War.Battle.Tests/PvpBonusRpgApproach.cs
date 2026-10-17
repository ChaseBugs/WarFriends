using War.BattleServer;
using War.Client;
using War.Protocol;

/// <summary>Uses normal cover commands to approach a settled crate before spending finite RPG ammunition.</summary>
internal static class PvpBonusRpgApproach
{
    private const int GroundedPhase = 1;
    private const int PollIntervalMilliseconds = 100;

    internal static async Task<MatchReply> PrepareShotAsync(
        MatchConnection shooter, RecoveredBattleMap map, string boxId, CancellationToken token)
    {
        MatchReply frame = await WaitForGroundedBoxAsync(shooter, boxId, token);
        BattlePvpBonusBoxState? box = FindBox(frame, boxId);
        if (box == null)
        {
            return frame;
        }

        BattlePlayerState player = frame.Snapshot.Players.Single(row => row.PlayerId == shooter.LocalPlayerId);
        CoverNode currentCover = map.Covers.Single(row => row.SourceIndex == player.CoverIndex);
        CoverNode desiredCover = map.Covers.Where(row => row.Fraction == currentCover.Fraction)
            .OrderBy(row => MathF.Abs(row.Position.Z - box.Z)).ThenBy(row => row.SourceIndex).First();
        if (currentCover.SourceIndex == desiredCover.SourceIndex)
        {
            return frame;
        }

        // The live failure repeatedly hit a barrier from the starting cover.
        // Spend a normal movement command rather than asking a missile to ignore source geometry.
        int direction = Math.Sign(desiredCover.SourceIndex - currentCover.SourceIndex);
        MatchReply movement = await shooter.MoveCoverAsync(direction, token);
        if (movement.Code != "moving")
        {
            throw new Exception("RPG cover approach rejected: " + movement.Code);
        }

        do
        {
            await Task.Delay(PollIntervalMilliseconds, token);
            frame = await shooter.PollAsync(token);
            player = frame.Snapshot.Players.Single(row => row.PlayerId == shooter.LocalPlayerId);
        } while (player.Moving && frame.Snapshot.Phase == BattlePhase.Running);

        return frame;
    }

    private static async Task<MatchReply> WaitForGroundedBoxAsync(
        MatchConnection shooter, string boxId, CancellationToken token)
    {
        while (true)
        {
            MatchReply frame = await shooter.PollAsync(token);
            BattlePvpBonusBoxState? box = FindBox(frame, boxId);
            if (box == null || box.Phase == GroundedPhase)
            {
                return frame;
            }

            if (frame.Snapshot.Phase != BattlePhase.Running)
            {
                throw new Exception("The RPG crate approach ended before the falling box settled.");
            }

            await Task.Delay(PollIntervalMilliseconds, token);
        }
    }

    private static BattlePvpBonusBoxState? FindBox(MatchReply frame, string boxId)
    {
        return frame.Snapshot.PvpBonusBoxes.SingleOrDefault(row => row.BoxId == boxId);
    }
}
