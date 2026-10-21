"""Review the 1.4.0 analytics declarations and execute original acknowledgement code in memory."""

from pathlib import Path
from legacy_profile_oracle import member


def analytics_sources(client: Path) -> dict[str, str]:
    analytics = (client / "PlayerAnalytics.cs").read_text(encoding="utf-8-sig")
    builder = (client / "BeanstalkServerManager.cs").read_text(encoding="utf-8-sig")
    callback = (client / "ServerResponseHandler.cs").read_text(encoding="utf-8-sig")
    elite = (client / "ElitesFeatureShownRequest.cs").read_text(encoding="utf-8-sig")
    base = (client / "DatabaseSerializedObject.cs").read_text(encoding="utf-8-sig")
    start = analytics.index("\tpublic class PlayerAnalyticsData\n")
    end = analytics.index("\n\t\tpublic bool isMoneyPackAvailable", start)
    result = {
        "Analytics.Fields": analytics[start:end].strip(),
        "Analytics.Transaction": member(analytics, "\tpublic class Transaction\n"),
        "Analytics.Defaults": member(base, "\tprotected virtual void LoadEmpty()"),
        "Analytics.LastSeen": member(analytics, "\tpublic int lastSeenSquadChatTimeStamp\n"),
        "Analytics.ElitesBuilder": member(elite, "\tpublic static void Send()"),
        "Analytics.ElitesCallback": member(elite, "\tpublic static void OnSuccess("),
    }
    for name in ("ChatShown", "CustomizationShown", "WarpathShown", "CardpoolShown", "CraftingShown",
                 "LeagueLeaderboardsShown"):
        result[f"Analytics.Builder.{name}"] = member(builder, f"\tinternal void {name}()")
    for name in ("OnChatShownFirstTime", "OnCustomizationShown", "OnWarpathShown", "OnCardpoolShown", "OnCraftingShown"):
        result[f"Analytics.Callback.{name}"] = member(callback, f"\tprivate void {name}()")
    if "case DatabaseAction.LeagueLeaderboardShown:" in callback:
        raise ValueError("New leaderboard callback requires a response-contract review.")
    return result


def analytics_oracle(recovered: dict[str, str]) -> str:
    template = """
internal static class RecoveredAnalyticsOracle
{
    __FIELDS__
    }
    __TRANSACTION__
    private static class Singleton<T> where T : new() { internal static T instance = new T(); }
    private static class RadicalRoutine { internal static object Run(object request) => request; }
    private static class Debug { internal static void Log(string message) { } }
    private sealed class NotificationManager { internal void ClientCardpoolNotifications() { } }
    private sealed class PlayerAnalytics
    {
        internal static PlayerAnalytics instance = new PlayerAnalytics();
        internal PlayerAnalyticsData data = new PlayerAnalyticsData();
        __LAST_SEEN__
    }
    private sealed class RequestBuffer
    {
        internal int calls;
        internal string payload;
        internal void AddRequest(DatabaseAction action, string value, int gold, int wb, string parameter)
        {
            calls++;
            payload = value;
        }
    }
    private sealed class RequestBufferManager
    {
        internal static RequestBufferManager instance = new RequestBufferManager();
        internal RequestBuffer buffer = new RequestBuffer();
        internal RequestBuffer GetRequestBuffer() => buffer;
    }
    private class ConstructorBoundary
    {
        private object SerializedObject;
        private Type SerializeType => typeof(PlayerAnalyticsData);
        __DEFAULTS__
        internal PlayerAnalyticsData Create() { LoadEmpty(); return (PlayerAnalyticsData)SerializedObject; }
    }
    private sealed class BeanstalkServerManager
    {
        private object CreateServerRequest(DatabaseAction action, List<Tuple<string, string>> fields) => new object();
        private void StartCoroutine(object routine) { }
        internal void SendServerRequest(DatabaseAction action, List<Tuple<string, string>> fields) { }
        __BUILDERS__
    }
    private static class ElitesFeatureShownRequest
    {
        __ELITES_BUILDER__
        __ELITES_CALLBACK__
    }
    private sealed class Callback
    {
        __CALLBACKS__
        internal void Read(string flag)
        {
            switch (flag)
            {
                case "chatShown": OnChatShownFirstTime(); break;
                case "customizationShown": OnCustomizationShown(); break;
                case "warpathShown": OnWarpathShown(); break;
                case "cardpoolShown": OnCardpoolShown(); break;
                case "craftingShown": OnCraftingShown(); break;
                case "elitesShown": ElitesFeatureShownRequest.OnSuccess(new()); break;
            }
        }
    }
    internal static string Complete()
    {
        var value = new PlayerAnalyticsData
        {
            warbucksSpent = 0, goldSpent = 0, boughtInApp = false, installTimestamp = 0,
            realMoneySpent = 1.99f, numberOfSessions = 1, moneyPackDeadline = 0, starterPackDeadline = 0,
            elitePackDeadlines = new(), collectedRewards = new(), totalBattles = 5,
            chatShown = false, elitesShown = false, customizationShown = false, warpathShown = false,
            cardpoolShown = false, craftingShown = false, leagueLeaderboardsShown = false,
            anticheatStatus = false, goldBonuses = 0, rateAppShownCounter = 0, rateAppFirstVersion = null,
            rateAppClientVersion = null, rateAppClickYesCounter = 0, renameCount = 0, squadCreationsCount = 0,
            matchesToNextLootboxes = 4, lastSeenSquadChatTimeStampDB = 0, instantBattlesTime = 0,
            instantBattles = 5, paidInstantBattles = 1, cardTutState = 0,
            transactions = new() { new Transaction { id = 142, p = null, gold = 0, wb = 0, money = 1.99f } }
        };
        return Newtonsoft.Json.JsonConvert.SerializeObject(value);
    }
    internal static string Defaults() => Newtonsoft.Json.JsonConvert.SerializeObject(new ConstructorBoundary().Create());
    internal static Dictionary<string, Type> Fields() => typeof(PlayerAnalyticsData).GetFields()
        .ToDictionary(field => field.Name, field => field.FieldType);
    internal static bool Acknowledge(string flag)
    {
        PlayerAnalytics.instance.data = new ConstructorBoundary().Create();
        var manager = Singleton<BeanstalkServerManager>.instance;
        switch (flag)
        {
            case "chatShown": manager.ChatShown(); break;
            case "customizationShown": manager.CustomizationShown(); break;
            case "warpathShown": manager.WarpathShown(); break;
            case "cardpoolShown": manager.CardpoolShown(); break;
            case "craftingShown": manager.CraftingShown(); break;
            case "leagueLeaderboardsShown": manager.LeagueLeaderboardsShown(); break;
            case "elitesShown": ElitesFeatureShownRequest.Send(); break;
        }
        new Callback().Read(flag);
        return (bool)typeof(PlayerAnalyticsData).GetField(flag).GetValue(PlayerAnalytics.instance.data);
    }
    internal static (int Value, int Calls, string Payload) Advance(int initial, int next)
    {
        PlayerAnalytics.instance.data = new PlayerAnalyticsData { lastSeenSquadChatTimeStampDB = initial };
        RequestBufferManager.instance.buffer = new RequestBuffer();
        PlayerAnalytics.instance.lastSeenSquadChatTimeStamp = next;
        return (PlayerAnalytics.instance.data.lastSeenSquadChatTimeStampDB,
            RequestBufferManager.instance.buffer.calls, RequestBufferManager.instance.buffer.payload);
    }
}
"""
    builders = [value for key, value in recovered.items() if key.startswith("Analytics.Builder.")]
    callbacks = [value for key, value in recovered.items() if key.startswith("Analytics.Callback.")]
    template = template.replace("__BUILDERS__", "\n".join(builders)).replace("__CALLBACKS__", "\n".join(callbacks))
    for token, name in (("FIELDS", "Fields"), ("TRANSACTION", "Transaction"), ("LAST_SEEN", "LastSeen"),
                        ("DEFAULTS", "Defaults"), ("ELITES_BUILDER", "ElitesBuilder"),
                        ("ELITES_CALLBACK", "ElitesCallback")):
        template = template.replace(f"__{token}__", recovered[f"Analytics.{name}"])
    return template
