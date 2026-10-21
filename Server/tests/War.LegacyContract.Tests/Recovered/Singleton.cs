namespace War.LegacyContract.Tests.Recovered;

internal static class Singleton<T> where T : new()
{
    public static T instance { get; } = new();
}
