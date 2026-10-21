using System.Text.RegularExpressions;
using Google.Protobuf;
using War.Protocol;

namespace War.BattleServer;

/// <summary>Validates canonical terminal evidence without filesystem, network or database access.</summary>
public static class BattleTerminalEvidenceValidator
{
    private const uint MaximumCrateCollections = 2048;
    private const uint MaximumSpawnedScorestreaks = 4096;

    public static MatchSnapshot ValidatePayload(byte[] payload,string matchId,string digest)
    {
        if(payload is not {Length:>0 and <=65536} ||
           !Regex.IsMatch(matchId??"",@"\A[a-zA-Z0-9_-]{1,64}\z") ||
           !Regex.IsMatch(digest??"",@"\A[0-9a-f]{64}\z"))
            throw new InvalidDataException("Invalid terminal result envelope.");
        if(War.Shared.TerminalResultDigest.Compute(payload)!=digest)
            throw new InvalidDataException("Terminal result digest mismatch.");
        MatchSnapshot snapshot;
        try {snapshot=MatchSnapshot.Parser.ParseFrom(payload);}
        catch(InvalidProtocolBufferException e){throw new InvalidDataException("Invalid terminal result protobuf.",e);}
        if(!snapshot.ToByteArray().AsSpan().SequenceEqual(payload) || snapshot.MatchId!=matchId)
            throw new InvalidDataException("Terminal result identity or canonical bytes differ.");
        ValidateSnapshot(snapshot);
        return snapshot;
    }
    public static void ValidateSnapshot(MatchSnapshot snapshot)
    {
        foreach(var player in snapshot.Players)
            BattleStatisticsValidator.Validate(new BattleStatistics(
                player.ConfirmedPlayerHits,player.ConfirmedPlayerKills,
                player.ConfirmedArmySpawns,player.ConfirmedArmyLosses));
        bool completedReason=BattleTerminalPolicy.IsScoredReason(snapshot.TerminalReason);
        bool abortedReason=BattleTerminalPolicy.IsAbortedReason(snapshot.TerminalReason);
        if(!Regex.IsMatch(snapshot.MatchId,@"\A[a-zA-Z0-9_-]{1,64}\z") ||
           !Regex.IsMatch(snapshot.ManifestHash,@"\A[0-9a-f]{64}\z") ||
           snapshot.Phase is not (BattlePhase.Ended or BattlePhase.Aborted) ||
           (snapshot.RewardEligible
               ? snapshot.Phase!=BattlePhase.Ended ||
                 !Regex.IsMatch(snapshot.SettlementPolicyRevision,@"\A[0-9a-f]{64}\z")
               : snapshot.SettlementPolicyRevision.Length!=0) || snapshot.TerminalReason.Length is <1 or >64 ||
           snapshot.ServerTick>10000000 || snapshot.EndTick!=snapshot.ServerTick ||
           snapshot.StartTick>10000000 ||
           (snapshot.StartTick!=0 && snapshot.EndTick>=snapshot.StartTick
               ? snapshot.PerformanceStartTick<snapshot.StartTick ||
                 snapshot.PerformanceStartTick>snapshot.EndTick ||
                 snapshot.PerformanceDurationTicks!=snapshot.EndTick-snapshot.PerformanceStartTick
               : snapshot.PerformanceStartTick!=0 || snapshot.PerformanceDurationTicks!=0) ||
           (snapshot.Phase==BattlePhase.Ended && (!completedReason || snapshot.WinnerPlayerId.Length==0)) ||
           (snapshot.Phase==BattlePhase.Aborted && (!abortedReason || snapshot.WinnerPlayerId.Length!=0)) ||
           snapshot.Players.Count!=2 || snapshot.Players[0].PlayerId==snapshot.Players[1].PlayerId ||
           snapshot.Players.Any(p=>p.ConfirmedArmyLosses>p.ConfirmedArmySpawns ||
               p.ConfirmedPlayerHits>p.ConfirmedEnemyHits ||
               p.ConfirmedPlayerBulletHits>p.ConfirmedEnemyHits ||
               p.ConfirmedCratesCollected > MaximumCrateCollections ||
               p.ConfirmedCratesStolen > p.ConfirmedCratesCollected ||
               p.ConfirmedScorestreaksGained > MaximumSpawnedScorestreaks ||
               !BattleSkillShotEvidencePolicy.Valid(p.ConfirmedSkillShotCounts) ||
               p.ConfirmedCardsPlayed>4096 ||
               p.ConfirmedEnemyHits>1_000_000) ||
           snapshot.Players.Any(p=>!War.Shared.CanonicalGuid.IsCanonical(p.PlayerId)) ||
           snapshot.PauseHostTick!=0 || snapshot.Players.Any(p=>!ValidTerminalPlayer(p,snapshot.ServerTick)) ||
           !ValidTerminalShields(snapshot.Shields) ||
           (snapshot.Phase==BattlePhase.Aborted && snapshot.WinnerPlayerId.Length!=0) ||
           (snapshot.TerminalReason=="simultaneous-barrel-death" &&
               snapshot.Players.Any(player=>!player.Dead)) ||
           (snapshot.WinnerPlayerId.Length!=0 && snapshot.Players.All(p=>p.PlayerId!=snapshot.WinnerPlayerId)) ||
           (snapshot.Phase==BattlePhase.Ended && snapshot.TerminalReason=="player-killed" &&
               (snapshot.Players.Single(p=>p.PlayerId==snapshot.WinnerPlayerId).Dead ||
                !snapshot.Players.Single(p=>p.PlayerId!=snapshot.WinnerPlayerId).Dead)) ||
           (snapshot.Phase==BattlePhase.Ended && snapshot.TerminalReason is ("forfeit" or "opponent-disconnected") &&
               snapshot.Players.Any(p=>p.Dead)))
            throw new InvalidDataException("Invalid unscored terminal evidence.");
        ulong hits=0,kills=0,spawns=0,losses=0;
        foreach(var player in snapshot.Players)
        {
            hits+=player.ConfirmedPlayerHits;kills+=player.ConfirmedPlayerKills;
            spawns+=player.ConfirmedArmySpawns;losses+=player.ConfirmedArmyLosses;
        }
        if(snapshot.Players.Aggregate(0UL,(sum,player)=>sum+player.ConfirmedCardsPlayed)!=snapshot.CardActivations)
            throw new InvalidDataException("Terminal card ownership does not conserve activations.");
        if(snapshot.CardUsage.Count>WarCardEffectCatalog.All.Count*2)
            throw new InvalidDataException("Terminal card usage exceeds its source catalog.");
        var usageByOwner=snapshot.Players.ToDictionary(p=>p.PlayerId,_=>0UL,StringComparer.Ordinal);
        string previousOwner="",previousCard="",previousSource="";
        ulong usageTotal=0;
        foreach(var usage in snapshot.CardUsage)
        {
            bool validSource;
            try {validSource=WarCardSourceIdentityCatalog.Resolve(usage.CardId,usage.SourceCardId)==usage.SourceCardId;}
            catch(InvalidDataException){validSource=false;}
            if(!usageByOwner.ContainsKey(usage.OwnerPlayerId) || !validSource ||
               !WarCardEffectCatalog.TryGet(usage.CardId,out _) || usage.Count is <1 or >4096 ||
               (previousOwner.Length!=0 && (string.CompareOrdinal(usage.OwnerPlayerId,previousOwner)<0 ||
                   (usage.OwnerPlayerId==previousOwner &&
                    (string.CompareOrdinal(usage.CardId,previousCard)<0 ||
                     (usage.CardId==previousCard &&
                      string.CompareOrdinal(usage.SourceCardId,previousSource)<=0))))))
                throw new InvalidDataException("Invalid terminal card usage row.");
            usageByOwner[usage.OwnerPlayerId]+=usage.Count;
            usageTotal+=usage.Count;
            previousOwner=usage.OwnerPlayerId;previousCard=usage.CardId;previousSource=usage.SourceCardId;
        }
        if(usageTotal!=snapshot.CardActivations ||
           snapshot.Players.Any(p=>usageByOwner[p.PlayerId]!=p.ConfirmedCardsPlayed))
            throw new InvalidDataException("Terminal card usage does not conserve player credits.");
        ValidateDirectArmyKills(snapshot);
        ValidatePvpCurrencyQuotes(snapshot);
        if(hits>uint.MaxValue || kills>uint.MaxValue || spawns>uint.MaxValue || losses>uint.MaxValue ||
           snapshot.CardActivations>int.MaxValue || snapshot.ObjectiveCredits>int.MaxValue)
            throw new InvalidDataException("Terminal performance counters exceed their durable contract.");
        CompleteBattleEvidenceValidator.Validate(new CompleteBattleEvidence(snapshot.MatchId,snapshot.ManifestHash,
            new BattleStatistics((uint)hits,(uint)kills,(uint)spawns,(uint)losses),
            snapshot.PerformanceDurationTicks,snapshot.RibbonIds.ToArray(),
            (int)snapshot.CardActivations,(int)snapshot.ObjectiveCredits));
    }

    private static void ValidatePvpCurrencyQuotes(MatchSnapshot snapshot)
    {
        if (snapshot.PvpCurrencyQuotes.Count > 256)
            throw new InvalidDataException("Terminal PvP currency quote capacity exceeded.");

        var playerIds = snapshot.Players.Select(player => player.PlayerId)
            .ToHashSet(StringComparer.Ordinal);
        string? previousBoxId = null;
        foreach (var quote in snapshot.PvpCurrencyQuotes)
        {
            if (!War.Shared.CanonicalGuid.IsCanonical(quote.BoxId) ||
                (previousBoxId != null &&
                 string.CompareOrdinal(previousBoxId, quote.BoxId) >= 0) ||
                !playerIds.Contains(quote.RecipientPlayerId) ||
                quote.RecipientLevelIndex is < 0 or > 42)
                throw new InvalidDataException("Invalid terminal PvP currency quote identity.");

            if (quote.Currency == "gold")
            {
                var range = PvpBonusCatalog.GoldRewardRangeForDisplayLevel(
                    quote.RecipientLevelIndex + 1);
                if (quote.BaseDraw < range.Minimum ||
                    quote.BaseDraw >= range.MaximumExclusive ||
                    quote.Amount != quote.BaseDraw)
                    throw new InvalidDataException("Invalid terminal Gold box amount.");
            }
            else if (quote.Currency == "warbucks")
            {
                if (quote.BaseDraw is < 500 or >= 1500 ||
                    quote.Amount != PvpBonusCatalog.WarbucksAmountForRecipient(
                        quote.RecipientLevelIndex, checked((int)quote.BaseDraw)))
                    throw new InvalidDataException("Invalid terminal Warbucks box amount.");
            }
            else throw new InvalidDataException("Unknown terminal PvP currency.");
            previousBoxId = quote.BoxId;
        }
    }

    private static void ValidateDirectArmyKills(MatchSnapshot snapshot)
    {
        if(snapshot.DirectArmyKills.Count>256)
            throw new InvalidDataException("Terminal direct army kill evidence exceeds host capacity.");
        var knownUnits=ArmyOptionIdentityCatalog.All.Select(x=>x.UnitId)
            .ToHashSet(StringComparer.Ordinal);
        var players=snapshot.Players.ToDictionary(x=>x.PlayerId,StringComparer.Ordinal);
        var byAttacker=players.Keys.ToDictionary(x=>x,_=>0UL,StringComparer.Ordinal);
        var byVictim=players.Keys.ToDictionary(x=>x,_=>0UL,StringComparer.Ordinal);
        var byVictimUnit=new Dictionary<(string PlayerId,string UnitId),ulong>();
        var identities=new HashSet<ulong>();
        var cardSpawnRequests = new HashSet<string>(StringComparer.Ordinal);
        ulong previousTick=0,previousEntity=0;
        foreach(var row in snapshot.DirectArmyKills)
        {
            if(row.EntityKey==0||row.EntityKey>>32 is not (1 or 2)||
               (uint)row.EntityKey==0||!identities.Add(row.EntityKey)||
               !knownUnits.Contains(row.UnitId)||
               row.Cause is not ("player-bullet" or "player-grenade" or "player-mine" or "player-bazooka" or "card-sabotage")||
               (row.Cause=="card-sabotage" &&
                   !BattleSabotageKillStatsProjection.SupportsVictim(row.UnitId))||
               (row.Cause=="player-grenade"&&
                   !BattleDirectKillStatsProjection.SupportsGrenadeVictim(row.UnitId))||
               (row.Cause=="player-mine"&&
                   !BattleDirectKillStatsProjection.SupportsMineVictim(row.UnitId))||
               (row.Cause=="player-bazooka"&&
                   !BattleDirectKillStatsProjection.SupportsBazookaVictim(row.UnitId))||
               snapshot.StartTick==0||row.Tick<snapshot.StartTick||row.Tick>snapshot.EndTick||
               (previousTick!=0&&(row.Tick<previousTick||
                   (row.Tick==previousTick&&row.EntityKey<=previousEntity)))||
               !players.TryGetValue(row.AttackerPlayerId,out var attacker)||
               !players.TryGetValue(row.VictimOwnerPlayerId,out var victim)||
               attacker.PlayerId==victim.PlayerId)
                throw new InvalidDataException("Invalid direct player army kill evidence.");
            if (row.VictimSourceCardId.Length > 0)
            {
                if (row.Cause != "card-sabotage" ||
                    row.VictimSourceCardId != "HEAVYDRONE" ||
                    row.UnitId != "ID_UNIT-DRONE" ||
                    (uint)row.EntityKey < BattleEntityIdentity.FirstCardEntityId ||
                    (uint)row.EntityKey >= BattleEntityIdentity.FirstCardEntityId + 4096 ||
                    !War.Shared.CanonicalGuid.IsCanonical(row.VictimSpawnRequestId) ||
                    !cardSpawnRequests.Add(row.VictimSpawnRequestId) ||
                    row.VictimSpawnTick < snapshot.StartTick ||
                    row.VictimSpawnTick > row.Tick)
                    throw new InvalidDataException("Invalid card-spawned Sabotage victim proof.");
            }
            else
            {
                if (row.VictimSpawnRequestId.Length != 0 || row.VictimSpawnTick != 0 ||
                    (uint)row.EntityKey >= BattleEntityIdentity.FirstCardEntityId ||
                    !victim.ArmyUsage.Any(x => x.UnitId == row.UnitId && x.ConfirmedSpawns > 0))
                    throw new InvalidDataException("Invalid equipped-army victim proof.");
                byVictim[row.VictimOwnerPlayerId]++;
                var victimUnit=(row.VictimOwnerPlayerId,row.UnitId);
                byVictimUnit.TryGetValue(victimUnit,out ulong directKills);
                byVictimUnit[victimUnit]=directKills+1;
            }
            if(row.Cause=="player-bullet")byAttacker[row.AttackerPlayerId]++;
            previousTick=row.Tick;previousEntity=row.EntityKey;
        }
        if(players.Values.Any(p=>byAttacker[p.PlayerId]>p.ConfirmedPlayerBulletHits||
            byVictim[p.PlayerId]>p.ConfirmedArmyLosses)||
           byVictimUnit.Any(pair=>pair.Value>(ulong)players[pair.Key.PlayerId].ArmyUsage
               .Where(x=>x.UnitId==pair.Key.UnitId).Sum(x=>x.ConfirmedSpawns)))
            throw new InvalidDataException("Direct army kill evidence exceeds confirmed host contacts or losses.");
        foreach(var player in snapshot.Players)
        {
            int cardKills=snapshot.DirectArmyKills.Count(row=>
                row.AttackerPlayerId==player.PlayerId && row.Cause=="card-sabotage");
            ulong cardUses=(ulong)snapshot.CardUsage.Where(row=>
                row.OwnerPlayerId==player.PlayerId &&
                row.CardId=="CardSabotage" && row.SourceCardId=="SABOTAGE")
                .Sum(row=>(long)row.Count);
            if((ulong)cardKills>cardUses)
                throw new InvalidDataException("Sabotage kills exceed trusted card uses.");
            int cardDroneDeaths = snapshot.DirectArmyKills.Count(row =>
                row.VictimOwnerPlayerId == player.PlayerId &&
                row.VictimSourceCardId == "HEAVYDRONE");
            long droneCardUses = snapshot.CardUsage.Where(row =>
                row.OwnerPlayerId == player.PlayerId &&
                row.CardId == "CardSpawnUnit" && row.SourceCardId == "HEAVYDRONE")
                .Sum(row => (long)row.Count);
            if (cardDroneDeaths > droneCardUses)
                throw new InvalidDataException("Card Drone deaths exceed trusted spawn-card uses.");
        }
    }
    private static bool ValidTerminalPlayer(BattlePlayerState p,ulong serverTick)
    {
        if(p.Ready && !p.Admitted || p.Reconnecting || p.ReconnectDeadlineHostTick!=0 ||
            p.ShotsFired>int.MaxValue || p.ClipAmmo<0 || p.ReserveAmmo<0 || p.CoverIndex is <-1 or >1000 ||
           !float.IsFinite(p.PositionX) || !float.IsFinite(p.PositionY) || !float.IsFinite(p.PositionZ) ||
           p.LastCommandId>100000 || p.ConfirmedPlayerKills>p.ConfirmedPlayerHits ||
           !ValidArmyUsage(p) ||
           p.RiflePose!=null && !RiflePoseProjection.ValidWire(p.RiflePose,serverTick) ||
           p.LastGeometryHit.Length!=0 && !Regex.IsMatch(p.LastGeometryHit,@"\A[0-9a-f]{64}\z"))
             return false;
        if(!p.CombatEnabled)
            return p.Health==0 && p.MaxHealth==0 && !p.Dead && p.DamageRevision==0;
        return float.IsFinite(p.Health) && float.IsFinite(p.MaxHealth) &&
            p.MaxHealth is >0 and <=100000000 && p.Health<=p.MaxHealth &&
            p.Dead==(p.Health<=0);
    }
    private static bool ValidArmyUsage(BattlePlayerState player)
    {
        if(player.ArmyUsage.Count>45)return false;
        int previous=-1;
        ulong confirmed=0;
        foreach(var row in player.ArmyUsage)
        {
            ArmyOptionIdentity option;
            try {option=ArmyOptionIdentityCatalog.Get(row.OptionIndex);}
            catch(InvalidDataException){return false;}
            if(row.OptionIndex<=previous || row.UnitId!=option.UnitId ||
               row.Deployments is <1 or >100_000 ||
               (ulong)row.Deployments*(uint)option.SpawnCount!=row.PlannedSpawns ||
               row.PlannedSpawns>100_000 || row.ConfirmedSpawns>row.PlannedSpawns)
                return false;
            confirmed+=row.ConfirmedSpawns;
            previous=row.OptionIndex;
        }
        return confirmed==player.ConfirmedArmySpawns;
    }

    private static bool ValidTerminalShields(Google.Protobuf.Collections.RepeatedField<BattleShieldState> shields)
    {
        if(shields.Count==0)return true;
        if(shields.Count!=8 || shields.Select(s=>s.CoverIndex).Distinct().Count()!=8 ||
           shields.Count(s=>s.OwnerFraction==1)!=4 || shields.Count(s=>s.OwnerFraction==2)!=4)
            return false;
        return shields.All(s=>s.CoverIndex is >=0 and <=1000 &&
            float.IsFinite(s.Health) && float.IsFinite(s.MaxHealth) &&
            s.MaxHealth is >0 and <=10000000 && s.Health>=0 && s.Health<=s.MaxHealth &&
            s.Destroyed==(s.Health==0));
    }
}
