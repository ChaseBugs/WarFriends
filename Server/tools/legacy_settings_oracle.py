"""Compile the reviewed Settings POCO/defaults; hash its builder and acknowledgement callback."""

from pathlib import Path


def extract(source, start, end):
    if source.count(start) != 1:
        raise ValueError("Settings source section must be unique: " + start)
    begin = source.index(start)
    return source[begin:source.index(end, begin)].strip()


def settings_sources(client: Path) -> dict[str, str]:
    manager = (client / "SettingsManager.cs").read_text(encoding="utf-8-sig")
    builder = (client / "BeanstalkServerManager.cs").read_text(encoding="utf-8-sig")
    callback = (client / "ServerResponseHandler.cs").read_text(encoding="utf-8-sig")
    return {
        "Settings.Model": extract(manager, "\tpublic class Settings\n", "\n\tprivate static SettingsManager"),
        "Settings.Defaults": extract(manager, "\tprotected override void LoadEmpty()", "\n\tprotected override void Awake()"),
        "Settings.Builder": extract(builder, "\tinternal void UpdateSettings(string settingsJson)",
                                    "\n\tinternal void FindSuggestedSquads("),
        "Settings.Callback": extract(callback, "\tprivate void OnSendSettings()", "\n\tprivate void OnRemoveLogin()"),
    }


def settings_oracle(recovered: dict[str, str]) -> str:
    template = """
internal static class RecoveredSettingsOracle
{
    __MODEL__
    private class Base
    {
        internal Settings data;
        protected virtual void LoadEmpty() { data = new Settings { maintenance = false }; }
    }
    private sealed class Manager : Base
    {
        __DEFAULTS__
        internal Settings Defaults() { LoadEmpty(); return data; }
    }
    internal static string SerializeDefaults() => Newtonsoft.Json.JsonConvert.SerializeObject(new Manager().Defaults());
    internal static string SerializeAllFalse() => Newtonsoft.Json.JsonConvert.SerializeObject(new Settings());
}
"""
    return template.replace("__MODEL__", recovered["Settings.Model"]) \
        .replace("__DEFAULTS__", recovered["Settings.Defaults"])
