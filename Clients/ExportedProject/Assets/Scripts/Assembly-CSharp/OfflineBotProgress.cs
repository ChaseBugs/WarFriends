using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using UnityEngine;

/// <summary>Durable bot outcomes and a last-known account for disconnected play.</summary>
public static class OfflineBotProgress
{
    private static JObject state;
    private static string scope;
    private static bool disconnected;
    private static string activeBattle;
    private static string configurations;
    public static bool IsDisconnected { get { return disconnected; } }
    public static int PendingBattleCount { get { return ((JArray)State["Battles"]).Count; } }

    private static string PathName { get { return Path.Combine(Application.persistentDataPath, "offline-bots-" + scope + ".json"); } }
    private static int Now { get { return checked((int)(DateTime.UtcNow - new DateTime(1970, 1, 1)).TotalSeconds); } }

    private static JObject State
    {
        get
        {
            string id = GameLoginManager.instance.playerId;
            if (string.IsNullOrEmpty(id) && GameLoginManager.currentPlayer != null) id = GameLoginManager.currentPlayer.id;
            if (string.IsNullOrEmpty(id)) id = "unregistered";
            string key = MiscTools.Md5(SelfHostedBackendEndpoint.Resolve().AbsoluteUri + "|" + id);
            if (state == null || scope != key)
            {
                scope = key;
                state = File.Exists(PathName) ? JObject.Parse(File.ReadAllText(PathName)) : new JObject
                {
                    ["Stream"] = Guid.NewGuid().ToString("N"), ["Next"] = 1,
                    ["Battles"] = new JArray(), ["Cache"] = new JObject()
                };
                if (state["Battles"] == null || state["Cache"] == null)
                    throw new InvalidOperationException("Offline progress is incomplete; preserve the save for recovery.");
            }
            return state;
        }
    }

    private static void Save()
    {
        Directory.CreateDirectory(Application.persistentDataPath);
        string temporary = PathName + ".new";
        File.WriteAllText(temporary, state.ToString(Formatting.None));
        if (File.Exists(PathName)) File.Replace(temporary, PathName, PathName + ".bak");
        else File.Move(temporary, PathName);
    }

    public static bool TryUseSavedAccount()
    {
        JObject cache = (JObject)State["Cache"];
        if (cache["Player"] == null || cache["PlayerData"] == null || cache["Configurations"] == null) return false;
        disconnected = true;
        return true;
    }

    public static void Connected() { disconnected = false; }

    public static bool TryBootFallback(DatabaseAction action, List<Tuple<string, string>> fields, out string response)
    {
        response = null;
        if (action != DatabaseAction.GetConfigurations && action != DatabaseAction.LoginToCustomAccount &&
            action != DatabaseAction.GetPlayerData) return false;
        return TryUseSavedAccount() && TryReply(action, fields, out response);
    }

    public static void AddPendingJournal(List<Tuple<string, string>> fields)
    {
        if (disconnected || ((JArray)State["Battles"]).Count == 0) return;
        fields.Add(new Tuple<string, string>("OfflineBotJournal", new JObject
        {
            ["Stream"] = State["Stream"].DeepClone(), ["Battles"] = State["Battles"].DeepClone()
        }.ToString(Formatting.None)));
    }

    public static void ObserveResponse(DatabaseAction action, string response)
    {
        JObject cache = (JObject)State["Cache"];
        if (action == DatabaseAction.GetConfigurations)
        {
            configurations = response;
            cache["Configurations"] = response;
            Save();
            return;
        }
        if (action != DatabaseAction.CreateAccount && action != DatabaseAction.LoginToCustomAccount &&
            action != DatabaseAction.GetPlayerData) return;
        JObject body = JObject.Parse(response);
        if ((int?)body["Result"] != (int)DatabaseResult.Success) return;
        if (configurations != null) cache["Configurations"] = configurations;
        if (body["Player"] != null) cache["Player"] = body["Player"].DeepClone();
        if (body["PlayerData"] != null) cache["PlayerData"] = body["PlayerData"].DeepClone();
        if (body["OfflineBotPolicy"] != null) cache["Policy"] = body["OfflineBotPolicy"].DeepClone();
        JObject ack = body["OfflineBotAck"] as JObject;
        if (ack != null && (string)ack["Stream"] == (string)State["Stream"])
        {
            long sequence = (long)ack["Sequence"];
            JArray pending = (JArray)State["Battles"];
            for (int i = pending.Count - 1; i >= 0; i--)
                if ((long)pending[i]["Sequence"] <= sequence) pending.RemoveAt(i);
        }
        Save();
    }

    public static bool TryReply(DatabaseAction action, List<Tuple<string, string>> fields, out string response)
    {
        response = null;
        GameController game = Singleton<GameController>.instance;
        if (game != null && game.isDeathMatchOffline && action == DatabaseAction.GameStartedMaster)
        {
            if (((JArray)State["Battles"]).Count >= 100)
                throw new InvalidOperationException("Synchronize pending bot battles before starting another.");
            activeBattle = "offline-" + Guid.NewGuid().ToString("N");
            response = new JObject { ["Result"] = 1, ["Time"] = Now, ["BattleId"] = activeBattle }.ToString();
            return true;
        }
        if (game != null && game.isDeathMatchOffline && action == DatabaseAction.GameEnded)
        {
            response = CompleteBattle(fields);
            return true;
        }
        if (!disconnected) return false;
        JObject cache = (JObject)State["Cache"];
        JObject reply = new JObject { ["Result"] = 1, ["Time"] = Now };
        switch (action)
        {
            case DatabaseAction.GetConfigurations:
                response = (string)cache["Configurations"];
                return response != null;
            case DatabaseAction.LoginToCustomAccount:
                if (cache["Player"] == null) return false;
                reply["Player"] = cache["Player"].DeepClone();
                reply["AccountType"] = 0;
                reply["Token"] = GameLoginManager.instance.accessToken ?? "";
                reply["Password"] = Field(fields, "Password");
                break;
            case DatabaseAction.GetPlayerData:
                reply["PlayerData"] = cache["PlayerData"].DeepClone();
                AddCompetition(reply);
                break;
            case DatabaseAction.GetAllMessages: reply["Items"] = new JArray(); break;
            case DatabaseAction.GetNewAssignments:
                reply["AssignmentData"] = JsonConvert.SerializeObject(AssignmentsManager.instance.data); break;
            case DatabaseAction.CheckDailyReward:
            case DatabaseAction.SetPlayerStatus:
            case DatabaseAction.UpdateArmyPower:
                break;
            case DatabaseAction.PayOneDogTag:
                DogTagManager tags = Singleton<DogTagManager>.instance;
                int timestamp = Singleton<BeanstalkServerManager>.instance.currentTimestamp;
                int refill = tags.timeToGetDogtag;
                int seconds = Math.Max(0, Math.Min(tags.max, checked(tags.seconds + Math.Max(0, timestamp - tags.lastUpdate))) - refill);
                reply["Seconds"] = seconds;
                reply["LastUpdate"] = timestamp;
                JObject account = (JObject)cache["PlayerData"];
                Number(account, "DogTagSeconds", seconds);
                Number(account, "DogTagLastUpdate", timestamp);
                Save();
                break;
            case DatabaseAction.UpdateAnalytics:
            case DatabaseAction.UpdateSettings:
                JObject snapshot = DatabaseSerializedObject.CaptureOfflineSnapshot();
                JObject saved = cache["PlayerData"] as JObject;
                if (saved != null) foreach (var field in snapshot) saved[field.Key] = field.Value.DeepClone();
                Save();
                break;
            default:
                // No fabricated successful purchase or online feature while disconnected.
                reply["Result"] = (int)DatabaseResult.ServerMaintenance;
                break;
        }
        response = reply.ToString(Formatting.None);
        return true;
    }

    private static string CompleteBattle(List<Tuple<string, string>> fields)
    {
        string battleId = Field(fields, "BattleId");
        if (battleId == (string)State["LastBattle"]) return (string)State["LastResponse"];
        if (battleId != activeBattle) throw new InvalidOperationException("No active local bot battle.");
        int reason = int.Parse(Field(fields, "EndReason"), CultureInfo.InvariantCulture);
        int xp = int.Parse(Field(fields, "Experience"), CultureInfo.InvariantCulture);
        int extraGold = int.Parse(Field(fields, "GoldBoxes"), CultureInfo.InvariantCulture);
        int extraCash = checked(int.Parse(Field(fields, "WarBucksBoxes"), CultureInfo.InvariantCulture) +
            int.Parse(Field(fields, "WarBucksRibbons"), CultureInfo.InvariantCulture));
        if ((reason != 1 && reason != 2 && reason != 3 && reason != 5) || xp < 0 || xp > 100000)
            throw new InvalidOperationException("Local bot result exceeds the supported sync policy.");
        if (extraGold < 0 || extraGold > 1000 || extraCash < 0 || extraCash > 100000)
            throw new InvalidOperationException("Local crate/ribbon rewards exceed the supported sync policy.");
        JObject policy = State["Cache"]["Policy"] as JObject;
        // Explicit reconstruction fallback, matching Backend BattleRewardPolicy; not recovered production prices.
        int warBucks = reason == 2 || reason == 3 ? ((int?)policy?["WinWarBucks"] ?? 800) : ((int?)policy?["LoseWarBucks"] ?? 400);
        warBucks = checked(warBucks + extraCash);
        int gold = extraGold;
        LevelManager levels = LevelManager.instance;
        int rank = levels.levelNumber;
        int remaining = checked(levels.levelExperience + xp);
        while (rank < levels.levels.Count - 1 && remaining >= levels.levels[rank].score)
        {
            remaining -= levels.levels[rank].score;
            gold = checked(gold + levels.levels[rank].golds);
            warBucks = checked(warBucks + levels.levels[rank].warbucks);
            rank++;
        }
        JObject reply = new JObject
        {
            ["Result"] = 1, ["Time"] = Now, ["LevelExperience"] = remaining,
            ["GameReward"] = new JObject
            {
                ["Warbucks"] = new JObject { ["BattleRewards"] = warBucks, ["ExtraRewards"] = 0, ["Winstreak"] = 0, ["League"] = 0 },
                ["Xp"] = new JObject { ["BattleRewards"] = xp, ["ExtraRewards"] = 0, ["Winstreak"] = 0, ["Time"] = 0 },
                ["GameGold"] = new JObject { ["BattleRewards"] = gold, ["League"] = 0 }
            }
        };
        AddCompetition(reply);
        if (rank != levels.levelNumber) reply["Level"] = rank;
        long nextGold = checked(Singleton<Wallet>.instance.gold + gold);
        long nextCash = checked(Singleton<Wallet>.instance.warBucks + warBucks);
        JObject snapshot = DatabaseSerializedObject.CaptureOfflineSnapshot();
        Number(snapshot, "Gold", nextGold); Number(snapshot, "WarBucks", nextCash);
        Number(snapshot, "Level", rank); Number(snapshot, "LevelExperience", remaining);
        Number(snapshot, "Experience", checked(levels.experience + xp));
        Number(snapshot, "ArmyPower", levels.armyPower);
        JObject old = State["Cache"]["PlayerData"] as JObject;
        if (old != null) foreach (var field in old) if (snapshot[field.Key] == null) snapshot[field.Key] = field.Value.DeepClone();
        ((JArray)State["Battles"]).Add(new JObject
        {
            ["Sequence"] = (long)State["Next"], ["EndReason"] = reason, ["Experience"] = xp,
            ["ExtraGold"] = extraGold, ["ExtraWarBucks"] = extraCash
        });
        State["Next"] = checked((long)State["Next"] + 1);
        State["Cache"]["PlayerData"] = snapshot;
        State["LastBattle"] = battleId;
        State["LastResponse"] = reply.ToString(Formatting.None);
        Save(); // Commit the receipt before publishing wallet changes or the completion callback.
        Singleton<Wallet>.instance.Init(nextGold, nextCash);
        return (string)State["LastResponse"];
    }

    private static void AddCompetition(JObject reply)
    {
        DatabasePlayer player = GameLoginManager.currentPlayer;
        reply["Skill"] = player.skill;
        reply["MedalsBalance"] = player.medalsBalance;
        reply["PlacementMatchesRequired"] = player.remainingMatches;
        reply["BeginnersLeague"] = player.beginnersLeague;
    }
    private static void Number(JObject data, string name, long value) { data[name] = new JObject { ["N"] = value.ToString(CultureInfo.InvariantCulture) }; }
    private static string Field(List<Tuple<string, string>> fields, string name)
    {
        foreach (var field in fields) if (field.Value1 == name) return field.Value2;
        return null;
    }
}
