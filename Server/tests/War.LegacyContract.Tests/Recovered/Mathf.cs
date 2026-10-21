namespace War.LegacyContract.Tests.Recovered;

/// <summary>Pure integer Max boundary used by the extracted Client lane getter; no native Unity call.</summary>
internal static class Mathf
{
    public static int Max(int first, int second) => Math.Max(first, second);
}
