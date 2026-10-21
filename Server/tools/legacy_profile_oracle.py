"""Review profile builders/callbacks and execute original rename and status callback rules."""

from pathlib import Path


def member(source: str, signature: str) -> str:
    if source.count(signature) != 1:
        raise ValueError("Profile source member must be unique: " + signature)
    start = source.index(signature)
    end = source.index("\n\t}", start) + len("\n\t}")
    return source[start:end].strip()


def profile_sources(client: Path) -> dict[str, str]:
    builder = (client / "BeanstalkServerManager.cs").read_text(encoding="utf-8-sig")
    callback = (client / "ServerResponseHandler.cs").read_text(encoding="utf-8-sig")
    analytics = (client / "PlayerAnalytics.cs").read_text(encoding="utf-8-sig")
    result = {}
    for name, signature in (
        ("Status", "\tinternal void SetPlayerStatus("),
        ("Device", "\tinternal void UpdateDeviceToken("),
        ("Language", "\tinternal void ChangeLanguage("),
        ("Country", "\tinternal void ChangePlayerCountry("),
        ("Rename", "\tpublic void ChangePlayerName("),
    ):
        result[f"Profile.{name}Builder"] = member(builder, signature)
    for name, method in (("Status", "OnSetPlayerStatus"), ("Device", "OnUpdateDeviceToken"),
                         ("Language", "OnChangeLanguage"), ("Rename", "OnChangePlayerName")):
        result[f"Profile.{name}Callback"] = member(callback, f"\tprivate void {method}()")
    if "case DatabaseAction.ChangePlayerCountry:" in callback:
        raise ValueError("New country callback requires an explicit response-contract review.")
    result["Profile.RenamePrice"] = member(analytics, "\tpublic int renameGoldPrice\n")
    status = (client / "PlayerStatus.cs").read_text(encoding="utf-8-sig")
    result["Profile.StatusEnum"] = status[status.index("public enum PlayerStatus"):].rstrip()
    errors = (client / "ServerErrorHandler.cs").read_text(encoding="utf-8-sig")
    start = errors.index("\t\tcase DatabaseResult.NotEnoughGoldForChangeName:")
    end = errors.index("\n\t\tcase DatabaseResult.NotEnoughWarBucksForCreateSquad:", start)
    result["Profile.RenameFailure"] = errors[start:end].strip()
    return result


def profile_oracle(recovered: dict[str, str]) -> str:
    template = """
internal static class RecoveredProfileOracle
{
    __STATUS_ENUM__
    private static class Singleton<T> where T : new() { internal static T instance = new T(); }
    private static class Mathf { internal static int Clamp(int value, int min, int max) => Math.Clamp(value, min, max); }
    private static class Debug { internal static void Log(string message) { } internal static void LogError(string s) { } }
    private static class GuiElementSingle<T> where T : new() { internal static T instance = new T(); }
    private static class Localization { internal static string Localize(string key) => key; }
    private sealed class NotEnoughDialog { internal void ShowGold(int price, string reason) { } }
    private static class LoadingDialog { internal static void Hide() { } }
    private static class WaitingDialog { internal static void Hide() { } }
    private static class DebugSettings { internal static bool debugEnabled => false; }
    private static class Application { internal static void Quit() { } }
    private static class Constants { internal enum rowIds { SecondRenameGoldCost } }
    private sealed class Row { internal float FLOATVALUE; }
    private sealed class Sheet { internal Row row = new Row(); internal Row GetRow(Constants.rowIds id) => row; }
    private sealed class GameVariables { internal Sheet constants = new Sheet(); }
    private sealed class Data { internal int renameCount; }
    private sealed class PlayerAnalytics
    {
        internal static PlayerAnalytics instance = new PlayerAnalytics();
        internal Data data = new Data();
        __PRICE__
    }
    private sealed class Wallet
    {
        internal int spent;
        internal long gold;
        internal void GoldSpent(int value) { spent += value; }
        internal void InitGold(long value) { gold = value; }
    }
    private sealed class GameLoginManager
    {
        internal static GameLoginManager instance = new GameLoginManager();
        internal string name;
        internal void SavePlayerName(string value) { name = value; }
    }
    private sealed class Clock { internal int now; internal void Init(int value) { now = value; } }
    private sealed class Callback
    {
        internal Dictionary<string, object> mResponse;
        internal Clock mServerTime = new Clock();
        __RENAME__
        __STATUS__
        __DEVICE__
        __LANGUAGE__
        internal void ReadFailure()
        {
            Dictionary<string, object> response = mResponse;
            switch (DatabaseResult.NotEnoughGoldForChangeName) { __RENAME_FAILURE__ }
        }
        internal void ReadRename() { OnChangePlayerName(); }
        internal void ReadStatus() { OnSetPlayerStatus(); }
        internal void ReadEmpty() { OnUpdateDeviceToken(); OnChangeLanguage(); }
    }
    internal static int Price(int count, int price)
    {
        PlayerAnalytics.instance.data.renameCount = count;
        Singleton<GameVariables>.instance.constants.row.FLOATVALUE = price;
        return PlayerAnalytics.instance.renameGoldPrice;
    }
    internal static (int Count, int Spent, string Name) Rename(Dictionary<string, object> response, int oldCount)
    {
        Price(oldCount, 25);
        Singleton<Wallet>.instance.spent = 0;
        new Callback { mResponse = response }.ReadRename();
        return (PlayerAnalytics.instance.data.renameCount, Singleton<Wallet>.instance.spent,
            GameLoginManager.instance.name);
    }
    internal static int Status(Dictionary<string, object> response)
    {
        var callback = new Callback { mResponse = response };
        callback.ReadStatus();
        return callback.mServerTime.now;
    }
    internal static long RenameFailure(Dictionary<string, object> response)
    {
        new Callback { mResponse = response }.ReadFailure();
        return Singleton<Wallet>.instance.gold;
    }
    internal static void ReadEmptyCallbacks() { new Callback { mResponse = new() }.ReadEmpty(); }
}
"""
    for token, name in (("STATUS_ENUM", "StatusEnum"), ("PRICE", "RenamePrice"),
                        ("RENAME", "RenameCallback"), ("STATUS", "StatusCallback"),
                        ("DEVICE", "DeviceCallback"), ("LANGUAGE", "LanguageCallback"), ("RENAME_FAILURE", "RenameFailure")):
        template = template.replace(f"__{token}__", recovered[f"Profile.{name}"])
    return template
