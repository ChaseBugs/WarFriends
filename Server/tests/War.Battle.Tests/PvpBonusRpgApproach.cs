using War.BattleServer;
using War.Client;
using War.Protocol;

/// <summary>Approaches a settled crate with normal cover commands and never repeats a failed firing cover.</summary>
internal sealed class PvpBonusRpgApproach
{
    private const int GroundedPhase = 1;
    private const int PollIntervalMilliseconds = 100;
    private readonly MatchConnection _shooter;
    private readonly RecoveredBattleMap _map;
    private readonly RpgCoverSearch _coverSearch;

    internal PvpBonusRpgApproach(MatchConnection shooter, RecoveredBattleMap map)
    {
        _shooter = shooter;
        _map = map;
        _coverSearch = new RpgCoverSearch(map);
    }

    internal async Task<MatchReply> PrepareShotAsync(string boxId, CancellationToken token)
    {
        MatchReply frame = await WaitForGroundedBoxAsync(boxId, token);
        BattlePvpBonusBoxState? box = FindBox(frame, boxId);
        if (box == null)
        {
            return frame;
        }
        CoverNode current = _map.Covers.Single(row => row.SourceIndex == GetPlayer(frame).CoverIndex);
        CoverNode desired = _coverSearch.SelectNext(boxId, current.Fraction, box.Z);
        frame = await MoveToCoverAsync(frame, desired, token);
        return frame;
    }

    private async Task<MatchReply> MoveToCoverAsync(MatchReply frame, CoverNode desired, CancellationToken token)
    {
        for (int step = 0; step < _map.Covers.Count; step++)
        {
            int current = GetPlayer(frame).CoverIndex;
            if (current == desired.SourceIndex)
            {
                return frame;
            }
            // SourceIndex adjacency is the same rule checked by the host MoveCover handler.
            MatchReply movement = await _shooter.MoveCoverAsync(Math.Sign(desired.SourceIndex - current), token);
            if (movement.Code != "moving")
            {
                throw new InvalidOperationException("RPG cover approach rejected: " + movement.Code);
            }
            do
            {
                await Task.Delay(PollIntervalMilliseconds, token);
                frame = await _shooter.PollAsync(token);
            } while (GetPlayer(frame).Moving && frame.Snapshot.Phase == BattlePhase.Running);
            if (frame.Snapshot.Phase != BattlePhase.Running)
            {
                throw new InvalidOperationException("The RPG crate approach ended during normal cover movement.");
            }
        }
        throw new InvalidOperationException("The RPG crate approach did not reach the requested cover.");
    }

    private async Task<MatchReply> WaitForGroundedBoxAsync(string boxId, CancellationToken token)
    {
        while (true)
        {
            MatchReply frame = await _shooter.PollAsync(token);
            BattlePvpBonusBoxState? box = FindBox(frame, boxId);
            if (box == null || box.Phase == GroundedPhase)
            {
                return frame;
            }
            if (frame.Snapshot.Phase != BattlePhase.Running)
            {
                throw new InvalidOperationException("The RPG crate approach ended before the falling box settled.");
            }
            await Task.Delay(PollIntervalMilliseconds, token);
        }
    }

    private BattlePlayerState GetPlayer(MatchReply frame)
    {
        return frame.Snapshot.Players.Single(row => row.PlayerId == _shooter.LocalPlayerId);
    }

    private static BattlePvpBonusBoxState? FindBox(MatchReply frame, string boxId)
    {
        return frame.Snapshot.PvpBonusBoxes.SingleOrDefault(row => row.BoxId == boxId);
    }
}
