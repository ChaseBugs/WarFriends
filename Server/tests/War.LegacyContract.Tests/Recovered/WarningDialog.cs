namespace War.LegacyContract.Tests.Recovered;

internal static class WarningDialog
{
    public static void ShowError(string message, string title, float delay, Action? callback,
        string label, bool useDialogBackground = false)
    {
        OracleTrace.Calls.Add("dialog");
        OracleTrace.Confirmation = callback;
    }
}
