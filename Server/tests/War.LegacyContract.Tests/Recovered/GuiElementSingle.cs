namespace War.LegacyContract.Tests.Recovered;

internal static class GuiElementSingle<T> where T : new()
{
    public static T instance { get; } = new();
}
