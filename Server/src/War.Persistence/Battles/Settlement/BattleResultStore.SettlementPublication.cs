using MongoDB.Driver;
using War.Persistence.Battles.Settlement;

namespace War.Persistence;

public sealed partial class BattleResultStore
{
    private async Task PublishSettlementAsync(
        IClientSessionHandle session, SettlementPublication publication, CancellationToken cancellationToken)
    {
        foreach (BattleSettlementPlayerChange next in publication.Plan.Players)
        {
            LegacyPlayerDocument current = publication.Context.Players.Single(player => player.Id == next.PlayerId);
            await PublishSettlementPlayerAsync(session, current, next, cancellationToken);
        }

        var receipt = new BattleSettlementReceipt
        {
            Id = publication.Result.MatchId,
            ResultDigest = publication.Result.Digest,
            ManifestHash = publication.Context.Terminal.ManifestHash,
            PolicyRevision = publication.Plan.PolicyRevision,
            SettledUtc = publication.Request.NowUtc,
            Responses = publication.Plan.Players.ToDictionary(player => player.PlayerId, player => player.ResponseJson)
        };
        await _database.GetCollection<BattleSettlementReceipt>("battle_settlements")
            .InsertOneAsync(session, receipt, cancellationToken: cancellationToken);

        var update = Builders<BattleResultDocument>.Update.Set(row => row.Scored, true)
            .Set(row => row.ScoredUtc, publication.Result.ScoredUtc ?? publication.Request.NowUtc)
            .Set(row => row.Settled, true).Set(row => row.SettledUtc, publication.Request.NowUtc);
        UpdateResult written = await results.UpdateOneAsync(session, Exact(publication.Result), update,
            cancellationToken: cancellationToken);
        if (written.ModifiedCount != 1)
        {
            throw new InvalidDataException("Settlement lost its exact accepted-result authority.");
        }
    }

    private async Task PublishSettlementPlayerAsync(
        IClientSessionHandle session, LegacyPlayerDocument current,
        BattleSettlementPlayerChange next, CancellationToken cancellationToken)
    {
        var update = Builders<LegacyPlayerDocument>.Update
            .Set(player => player.Gold, next.Gold).Set(player => player.WarBucks, next.WarBucks)
            .Set(player => player.Level, next.Level).Set(player => player.LevelExperience, next.LevelExperience)
            .Set(player => player.Experience, next.Experience).Set(player => player.ArmyPower, next.ArmyPower)
            .Set(player => player.Skill, next.Skill).Set(player => player.MedalsBalance, next.MedalsBalance)
            .Set(player => player.PlacementMatchesRequired, next.PlacementMatchesRequired)
            .Set(player => player.BattlesLostInRow, next.BattlesLostInRow)
            .Set("Serialized.WinStreak", next.WinStreakJson).Inc(player => player.Revision, 1);
        UpdateResult written = await _database.GetCollection<LegacyPlayerDocument>("legacyPlayers")
            .UpdateOneAsync(session, player => player.Id == current.Id && player.Revision == current.Revision,
                update, cancellationToken: cancellationToken);
        if (written.ModifiedCount != 1)
        {
            throw new InvalidDataException("Battle account changed before settlement publication.");
        }
    }
}
