using System.Text.Json.Nodes;
using War.Backend.Legacy.DogTags;
using War.Backend.Legacy.Time;
using War.Persistence.Legacy.Accounts;
using War.Persistence.Legacy.Analytics;
using War.Persistence.Legacy.Preferences;
using War.Persistence.Legacy.State;
using War.Persistence.Legacy.Tutorial;
using War.Persistence;

namespace War.Backend.Legacy.Player;

public static class LegacyPlayerProjection
{
    /// <summary>
    /// Projects the <c>Player</c> object consumed by <c>DatabasePlayer.CreateFromDatabase</c>.
    /// </summary>
    /// <remarks>
    /// <c>Regions</c> is deliberately never emitted: it deserializes to a
    /// <c>Dictionary&lt;CloudRegionCode, int&gt;</c> of Photon Cloud region pings, and this
    /// deployment runs offline with no Photon. The client's null guard leaves
    /// <c>bestRegions</c> null, which is the correct representation of "no Photon regions".
    /// <paramref name="includeDeviceToken"/> is false for <see cref="LegacyPlayerQueryEndpoint.ReadAsync"/>: the push
    /// token has no use to a third party, and the client's own reader never requires it.
    /// </remarks>
    public static JsonObject Player(LegacyPlayerDocument player, bool includeDeviceToken = true)
    {
        LegacyPlayerIdentityAuthority.Validate(player);
        LegacyPlayerEconomyAuthority.Validate(player);
        LegacyTutorialAuthority.ValidateForRead(player);
        var item = new JsonObject
        {
            ["Id"] = Dynamo.S(player.Id),
            ["Name"] = Dynamo.S(player.Name),
            ["Level"] = Dynamo.N(player.Level),
            ["Experience"] = Dynamo.N(player.Experience),
            ["Reputation"] = Dynamo.N(player.Reputation),
            ["Skill"] = Dynamo.N(player.Skill),
            ["Status"] = Dynamo.N(player.Status),
            ["AccountType"] = Dynamo.N(player.AccountType),
            ["ArmyPower"] = Dynamo.N(player.ArmyPower),
            ["BeginnersLeague"] = Dynamo.N(player.BeginnersLeague),
            ["LastAction"] = Dynamo.N(player.LastAction),
            ["MedalsBalance"] = Dynamo.N(player.MedalsBalance),
            ["PlacementMatchesRequired"] = Dynamo.N(player.PlacementMatchesRequired),
            ["SendLogs"] = Dynamo.N(player.SendLogs),
            ["SquadPoints"] = Dynamo.N(player.SquadPoints),
            ["SquadRank"] = Dynamo.N(player.SquadRank),
            ["Vip"] = Dynamo.N(player.Vip),
            ["VisualTimestamp"] = Dynamo.N(player.VisualTimestamp)
        };
        if (player.Country.Length > 0)
        {
            item["Country"] = Dynamo.S(player.Country);
        }
        if (includeDeviceToken && player.DeviceToken.Length > 0)
        {
            item["DeviceToken"] = Dynamo.S(player.DeviceToken);
        }
        if (player.LeagueId.Length > 0)
        {
            item["LeagueId"] = Dynamo.S(player.LeagueId);
        }
        if (player.SquadId.Length > 0)
        {
            item["SquadId"] = Dynamo.S(player.SquadId);
        }
        if (player.VisualType.Length > 0)
        {
            item["VisualType"] = Dynamo.S(player.VisualType);
        }
        // DatabasePlayer.CreateFromDatabase reads a regular deposited card as
        // DepositedCards["M"][cardId]["M"]["Amount"]["N"] — a nested map, not the flat
        // {"amount":N} shape CardManagerData.CardData itself uses elsewhere.
        if (player.DepositedCards.Any(kv => kv.Value > 0))
        {
            var deposited = new JsonObject();
            foreach (var (cardId, amount) in player.DepositedCards)
            {
                if (amount > 0)
                {
                    deposited[cardId] = Dynamo.Map(new JsonObject { ["Amount"] = Dynamo.N(amount) });
                }
            }
            item["DepositedCards"] = Dynamo.Map(deposited);
        }

        // InventoryData, LevelManagerData and StatisticsData appear on the Player object as well
        // as inside PlayerData; the client parses them from both. Emit the same stored blob.
        CopyBlob(item, player, "InventoryData");
        CopyBlob(item, player, "LevelManagerData");
        CopyBlob(item, player, "StatisticsData");
        return item;
    }

    /// <summary>
    /// Projects the <c>PlayerData</c> object consumed by <c>ServerResponseHandler.LoadPlayerData</c>
    /// and, through <c>DatabaseSerializedObject.LoadObjects</c>, by every registered subsystem.
    /// </summary>
    public static JsonObject PlayerData(LegacyPlayerDocument player, int now, LegacyDogTagPolicy? policy)
    {
        LegacyPlayerIdentityAuthority.Validate(player);
        LegacyPlayerEconomyAuthority.Validate(player);
        LegacyTutorialAuthority.ValidateForRead(player);
        LegacySettingsSnapshot.ValidateContainer(player.Serialized);
        LegacyAnalyticsState.ValidateContainer(player.Serialized);
        LegacyDogTagSnapshot dogTags = LegacyDogTagRules.Project(player, now, policy);
        var data = new JsonObject
        {
            ["Gold"] = Dynamo.N(player.Gold),
            ["WarBucks"] = Dynamo.N(player.WarBucks),
            ["Level"] = Dynamo.N(player.Level),
            ["LevelExperience"] = Dynamo.N(player.LevelExperience),
            ["Experience"] = Dynamo.N(player.Experience),
            ["ArmyPower"] = Dynamo.N(player.ArmyPower),
            ["Vip"] = Dynamo.N(player.Vip),
            ["VipStart"] = Dynamo.N(player.VipStart),
            ["Tickets"] = Dynamo.N(player.Tickets),
            ["Scraps"] = Dynamo.N(player.Scraps),
            ["Midnight"] = Dynamo.N(LegacyClientTime.NextMidnight(now)),
            ["DogTagSeconds"] = Dynamo.N(dogTags.Seconds),
            ["DogTagLastUpdate"] = Dynamo.N(dogTags.LastUpdate),
            ["DogTagMax"] = Dynamo.N(dogTags.MaximumSeconds),
            ["Position"] = Dynamo.N(player.Position),
            ["SendLogs"] = Dynamo.N(player.SendLogs),
            ["battlesLostInRow"] = Dynamo.N(player.BattlesLostInRow)
        };

        // Presence alone marks the tutorial finished; the client never reads the value.
        if (player.TutorialCompleted)
        {
            data["TutorialData"] = Dynamo.S("1");
        }

        // Each subsystem looks itself up by its own simple type name. A key that is absent takes
        // the client's LoadEmpty() path and yields its default instance, which is exactly what a
        // new account should get — so nothing is synthesised here.
        foreach (var (key, json) in player.Serialized)
        {
            if (LegacyPlayerStore.SerializedKeys.Contains(key))
            {
                data[key] = Dynamo.Json(json);
            }
        }

        return data;
    }

    private static void CopyBlob(JsonObject target, LegacyPlayerDocument player, string key)
    {
        if (player.Serialized.TryGetValue(key, out string? json))
        {
            target[key] = Dynamo.Json(json);
        }
    }
}
