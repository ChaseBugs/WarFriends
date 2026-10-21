namespace War.LegacyContract.Tests.Recovered;

internal static class GuiScreenSingle<T> where T : new()
{
    public static T instance { get; } = new();
}
