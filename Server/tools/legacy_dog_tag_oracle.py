"""Compile reviewed 1.4.0 dog-tag arithmetic against instrumented clock/VIP/UI boundaries."""

from pathlib import Path


def section(source, start, end):
    if source.count(start) != 1:
        raise ValueError("Dog-tag source section must be unique: " + start)
    begin = source.index(start)
    return source[begin:source.index(end, begin)].strip()


def dog_tag_sources(client: Path) -> dict[str, str]:
    manager = (client / "DogTagManager.cs").read_text(encoding="utf-8-sig").rstrip()
    vip = (client / "VipManager.cs").read_text(encoding="utf-8-sig")
    builder = (client / "BeanstalkServerManager.cs").read_text(encoding="utf-8-sig")
    handler = (client / "ServerResponseHandler.cs").read_text(encoding="utf-8-sig")
    return {
        "DogTags.Manager": manager,
        "DogTags.VipActive": section(vip, "\tinternal bool IsVipActive()", "\n\tpublic void LoadNewPlayer()"),
        "DogTags.PayBuilder": section(builder, "\tpublic void PayOneDogtag()", "\n\tpublic void BuyPack("),
        "DogTags.RefillBuilder": section(builder, "\tinternal void RefillDogtags()", "\n\tpublic void BuyInApp("),
        "DogTags.PayCallback": section(handler, "\tprivate void OnPayOneDogTag()", "\n\tprivate void OnPromotePlayer()"),
        "DogTags.RefillCallback": section(handler, "\tprivate void OnRefillDogtags()", "\n\tprivate void OnSearchPlayers()"),
        "DogTags.VipCallback": section(handler, "\tprivate void OnVipExpired()", "\n\tprivate void OnRestorePacks()"),
    }


def dog_tag_oracle(recovered: dict[str, str]) -> str:
    manager = recovered["DogTags.Manager"]
    properties = ("dogtagRefillPrice", "mServerSeconds", "mVipSeconds", "mMaxSeconds", "mCurrentSeconds",
                  "mCurrentSecondsClamp", "mCurrentLocalSeconds", "currentDogtags", "maximumDogtags", "isFull")
    lines = []
    for name in properties:
        matches = [line.strip() for line in manager.splitlines() if f" {name} =>" in line]
        if len(matches) != 1:
            raise ValueError("Dog-tag property must be unique: " + name)
        lines.append(matches[0])
    pay = manager[manager.index("\tpublic void PayOneDogTag()"):manager.rfind("\n}")].strip()
    template = """
internal static class RecoveredDogTagOracle
{
    private static class Singleton<T> where T : new() { internal static T instance = new T(); }
    private static class GuiElementSingle<T> where T : new() { internal static T instance = new T(); }
    private sealed class HeaderDogtagButton { public void AnimateDogtagUse() { } }
    private static class Debug { internal static void Log(string message) { } }
    private static class Mathf { internal static int Clamp(int x, int min, int max) => Math.Min(max, Math.Max(min, x)); }
    private sealed class BeanstalkServerManager
    {
        public int currentTimestamp;
        public void PayOneDogtag() { }
    }
    private sealed class VipManager
    {
        public int vipExpiration;
        public int numberOfVIPDogtags;
        __VIP_ACTIVE__
    }
    private sealed class Manager
    {
        public int seconds, lastUpdate, max, mDogTagWaitingTime;
        private int mUsedDogtagsLocaly = 0;
        public Action<int> DogtagsChanged = null;
        __PROPERTIES__
        __PAY__
    }
    internal static (int Price, bool Full, int BaseAfterPenalty) Read(
        int seconds, int lastUpdate, int max, int period, int vipCount, int vipExpiration, int now)
    {
        Singleton<BeanstalkServerManager>.instance.currentTimestamp = now;
        Singleton<VipManager>.instance.vipExpiration = vipExpiration;
        Singleton<VipManager>.instance.numberOfVIPDogtags = vipCount;
        var manager = new Manager { seconds = seconds, lastUpdate = lastUpdate, max = max,
            mDogTagWaitingTime = period };
        int price = manager.dogtagRefillPrice;
        bool full = manager.isFull;
        manager.PayOneDogTag();
        return (price, full, manager.seconds + (now - lastUpdate));
    }
}
"""
    return template.replace("__VIP_ACTIVE__", recovered["DogTags.VipActive"]) \
        .replace("__PROPERTIES__", "\n".join(lines)).replace("__PAY__", pay)
