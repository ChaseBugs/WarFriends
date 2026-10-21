namespace War.Battle.Tests.Support;

/// <summary>Recognizes the existing entry shapes that run the shared test prelude.</summary>
internal static class BattleSharedSuiteArguments
{
    internal const int InvalidArgumentsExitCode = 2;
    internal const string InvalidArgumentsMessage =
        "Invalid battle test arguments. Use no arguments for the full suite or a documented selector.";

    internal static bool CanRunSharedSuite(string[] arguments)
    {
        // Focused routes have already returned. Only these legacy entries continue into shared tests.
        if (arguments is [] or ["--allocation-inventory-only"])
        {
            return true;
        }
        if (arguments is ["--unity" or "--unity-rifle", string executable, string project])
        {
            return !string.IsNullOrWhiteSpace(executable) && !string.IsNullOrWhiteSpace(project);
        }
        return false;
    }
}
